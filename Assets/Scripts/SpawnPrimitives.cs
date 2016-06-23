﻿using UnityEngine;
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
    public bool delay = false;

    public Material normalMaterial;
    public Material overMaterial;

    // Use this for initialization
    void Start() {
        //controller = GetComponent<LeapServiceProvider>().GetLeapController();
        //hands = new List<Hand>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Update is called once per frame
    void Update() {
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 1) {
            if (hands[0].WristPosition.DistanceTo(hands[1].WristPosition) < wristDistance && !delay) {
                StartCoroutine(SpawnCube());
            }
            Debug.Log(hands[0].WristPosition.DistanceTo(hands[1].WristPosition));
        }
    }

    //
    private IEnumerator SpawnCube() {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = (hands[0].PalmPosition.ToVector3() + hands[1].PalmPosition.ToVector3()) * 0.5f;
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //cube.AddComponent<Rigidbody>();

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
}