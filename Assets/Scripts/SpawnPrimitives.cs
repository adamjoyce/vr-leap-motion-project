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

    public float minSphereSize = 0.1f;
    public float maxSphereSize = 0.35f;

    public bool delay = false;
    public bool sphereAttached = false;

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
            // Makes the sphere suspectable to physics.
            if (sphere && sphere.GetComponent<Rigidbody>().isKinematic)
                sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (hands[0].WristPosition.DistanceTo(hands[1].WristPosition) < wristDistance && !delay && !sphereAttached)
            {
                StartCoroutine(SpawnSphere());
                sphereAttached = true;
            }
            else if (sphereAttached)
            {
                sphere.transform.position = (hands[0].PalmPosition.ToVector3() + hands[1].PalmPosition.ToVector3()) * 0.5f;
                float scaleDistance = hands[0].WristPosition.DistanceTo(hands[1].WristPosition) * 0.6f;

                if (sphere.transform.localScale.x <= minSphereSize)
                {
                    Vector3 newScale = new Vector3(scaleDistance, scaleDistance, scaleDistance);
                    if (newScale.x >= sphere.transform.localScale.x)
                        sphere.transform.localScale = new Vector3(scaleDistance, scaleDistance, scaleDistance);
                }
                else if (sphere.transform.localScale.x >= maxSphereSize)
                {
                    Vector3 newScale = new Vector3(scaleDistance, scaleDistance, scaleDistance);
                    if (newScale.x <= sphere.transform.localScale.x)
                        sphere.transform.localScale = new Vector3(scaleDistance, scaleDistance, scaleDistance);
                }
                else
                {
                    sphere.transform.localScale = new Vector3(scaleDistance, scaleDistance, scaleDistance);
                }

                if (!hands[1].Fingers[0].IsExtended && !hands[1].Fingers[1].IsExtended && !hands[1].Fingers[2].IsExtended && !hands[1].Fingers[3].IsExtended && !hands[1].Fingers[4].IsExtended &&
                    !hands[0].Fingers[0].IsExtended && !hands[0].Fingers[1].IsExtended && !hands[0].Fingers[2].IsExtended && !hands[0].Fingers[3].IsExtended && !hands[0].Fingers[4].IsExtended)
                {
                    sphereAttached = false;
                    if (sphere.transform.localScale.x < minSphereSize) 
                        sphere.transform.localScale = new Vector3(minSphereSize, minSphereSize, minSphereSize);
                }
            }
        }
        else
        {
            // Make any sphere that is being generated static.
            if (sphere && sphereAttached)
            {
                sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
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