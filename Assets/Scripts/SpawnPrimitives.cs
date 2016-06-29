using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using VRStandardAssets.Utils;

public class SpawnPrimitives : MonoBehaviour {

    public LeapProvider provider;
    public List<Hand> hands;

    public float wristDistance = 2.0f;
    public float spawnDelay = 1.0f;
    public float kinematicDelay = 0.5f;
    public bool delay = false;

    public Material normalMaterial;
    public Material overMaterial;

    public GameObject bubbleSphere;
    public GameObject cloth;

    // Use this for initialization
    void Start() {
        //controller = GetComponent<LeapServiceProvider>().GetLeapController();
        //hands = new List<Hand>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        cloth = GameObject.Find("Cloth");
    }

    // Update is called once per frame
    void Update() {
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 1) {
            if (hands[0].WristPosition.DistanceTo(hands[1].WristPosition) < wristDistance && !delay) {
                StartCoroutine(SpawnSphere());
            }
            Debug.Log(hands[0].WristPosition.DistanceTo(hands[1].WristPosition));
        }
    }

    //
    private IEnumerator SpawnSphere() {
        Vector3 firstPalmPos = hands[0].PalmPosition.ToVector3();
        Vector3 secondPalmPos = hands[1].PalmPosition.ToVector3();
        Vector3 forwardDirection = GameObject.Find("CenterEyeAnchor").transform.forward;
        Vector3 spawnPos = /*GameObject.Find("CenterEyeAnchor").transform.position*/(firstPalmPos + secondPalmPos) * 0.5f; //+ forwardDirection * 1f;

        GameObject sphere = Instantiate(bubbleSphere, spawnPos, Quaternion.identity) as GameObject;

        sphere.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().useGravity = false;
        sphere.GetComponent<Rigidbody>().isKinematic = true;
        sphere.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;

        Physics.IgnoreCollision(sphere.GetComponent<Collider>(), GameObject.Find("CollisionSphere").GetComponent<Collider>());
        ClothSphereColliderPair sphereCollider = new ClothSphereColliderPair(sphere.GetComponent<SphereCollider>());

        int colliderNumber = cloth.GetComponent<Cloth>().sphereColliders.Length;
        ClothSphereColliderPair[] newColliders = new ClothSphereColliderPair[colliderNumber + 1];
        ClothSphereColliderPair[] currentColliders = cloth.GetComponent<Cloth>().sphereColliders;
        for (int i = 0; i < currentColliders.Length; i++) {
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

        delay = true;
        yield return new WaitForSeconds(spawnDelay);
        delay = false;
    }

    //
    private IEnumerator activeObject(GameObject sphere) {
        yield return new WaitForSeconds(kinematicDelay);
        sphere.GetComponent<Rigidbody>().isKinematic = false;
    }
}