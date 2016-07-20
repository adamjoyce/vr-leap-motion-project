using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using VRStandardAssets.Utils;

public class SpawnPrimitives : MonoBehaviour
{
    public LeapProvider provider;
    public List<Hand> hands;

    public GameObject cloth;
    public GameObject bubbleSphere;

    public Transform[] collisionSpheres;

    public float wristDistance = 2.0f;
    public float spawnDelay = 1.0f;
    public float kinematicDelay = 0.5f;
    public bool delay = false;

    private GameObject sphere;

    // Use this for initialization.
    void Start()
    {
        // Ensure the public variables are assigned.
        if (!provider)
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        if (!cloth)
            cloth = GameObject.Find("Cloth");

        // Array of stability spheres to hold up the cloth.
        collisionSpheres = GameObject.Find("CollisionSpheres").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Update the hand information for this frame.
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 1)
        {
            if (hands[0].WristPosition.DistanceTo(hands[1].WristPosition) < wristDistance && !delay)
            {
                StartCoroutine(SpawnSphere());
            }
            //sphere.transform.position = (hands[0].PalmPosition.ToVector3() + hands[1].PalmPosition.ToVector3()) * 0.5f;
            //float scaleDistance = hands[0].WristPosition.DistanceTo(hands[1].WristPosition) * 0.6f;
            //Debug.Log(scaleDistance);
            //sphere.transform.localScale = new Vector3(scaleDistance, scaleDistance, scaleDistance);
            //Debug.Log(hands[0].WristPosition.DistanceTo(hands[1].WristPosition));
        }
    }

    // Setups up and spawns a new bubble sphere.
    private IEnumerator SpawnSphere()
    {
        // Calulate the spawn position from the players hands and forward direction.
        Vector3 firstPalmPos = hands[0].PalmPosition.ToVector3();
        Vector3 secondPalmPos = hands[1].PalmPosition.ToVector3();
        Vector3 spawnPos = (firstPalmPos + secondPalmPos) * 0.5f;

        GameObject.Find("AudioPop").GetComponent<AudioSource>().Play();
        sphere = Instantiate(bubbleSphere, spawnPos, Quaternion.identity) as GameObject;

        // Setup the bubble spheres rigidbody properties.
        sphere.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().useGravity = false;
        sphere.GetComponent<Rigidbody>().isKinematic = true;
        sphere.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Ignore collisions between the the new bubble sphere and the cloth's stability spheres.
        for (int i = 1; i < collisionSpheres.Length; i++)
            Physics.IgnoreCollision(sphere.GetComponent<Collider>(), collisionSpheres[i].gameObject.GetComponent<Collider>());

        ClothSphereColliderPair sphereCollider = new ClothSphereColliderPair(sphere.GetComponent<SphereCollider>());

        // Arrays to handle the sphere colliders which can interact with the cloth.
        int colliderNumber = cloth.GetComponent<Cloth>().sphereColliders.Length;
        ClothSphereColliderPair[] newColliders = new ClothSphereColliderPair[colliderNumber + 1];
        ClothSphereColliderPair[] currentColliders = cloth.GetComponent<Cloth>().sphereColliders;
        for (int i = 0; i < currentColliders.Length; i++)
        {
            newColliders[i] = currentColliders[i];
        }

        newColliders[colliderNumber] = sphereCollider;
        cloth.GetComponent<Cloth>().sphereColliders = newColliders;

        StartCoroutine(activeObject(sphere));

        //cube.AddComponent<VRInteractiveItem>();
        //cube.AddComponent<CubeInteractiveItem>().enabled = true;
        //cube.GetComponent<CubeInteractiveItem>().SetNormalMaterial(normalMaterial);
        //cube.GetComponent<CubeInteractiveItem>().SetOverMaterial(overMaterial);
        //cube.GetComponent<CubeInteractiveItem>().SetInterativeItem(GetComponent<VRInteractiveItem>());
        //cube.GetComponent<CubeInteractiveItem>().SetRenderer(GetComponent<Renderer>());

        // Enforce the spawn delays between spheres.
        delay = true;
        yield return new WaitForSeconds(spawnDelay);
        delay = false;
    }

    // Makes an object interactive after a delay.
    private IEnumerator activeObject(GameObject obj)
    {
        yield return new WaitForSeconds(kinematicDelay);
        obj.GetComponent<Rigidbody>().isKinematic = false;
    }
}