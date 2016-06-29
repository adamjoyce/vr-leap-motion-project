using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Pitch : MonoBehaviour {

    public LeapProvider provider;

    public Controller controller;
    public GameObject audio;

    public List<Hand> hands;
    public Hand left, right;

    public Vector previousRightHandPosition;

    private float pitchIncrement = 1.0f;
    private GameObject musicState;

    // Use this for initialization
    void Start() {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        controller = GetComponent<LeapServiceProvider>().GetLeapController();
        hands = new List<Hand>();
        audio = GameObject.Find("AudioSource");
        musicState = GameObject.Find("MusicState");
    }

    // Update is called once per frame
    void Update() {
        // Update the hand information for this frame.
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 1) {
            for (int i = 0; i < hands.Count; i++) {
                if (hands[i].IsLeft) {
                    left = hands[i];
                } else {
                    right = hands[i];
                }
            }

            if (left.PinchDistance < 10.0f) {
                AdjustPitch();

                Vector3 pinchLightPos = left.Fingers[0].TipPosition.ToVector3();
                GameObject pinchLight = GameObject.Find("PinchLight");
                pinchLight.transform.position = pinchLightPos;
                pinchLight.GetComponent<MeshRenderer>().enabled = true;
            } else {
                GameObject.Find("PinchLight").GetComponent<MeshRenderer>().enabled = false;
            }
            Debug.Log(hands[0].PinchDistance);

            previousRightHandPosition = right.PalmPosition;
        }
    }

    //
    private void AdjustPitch() {
        if (previousRightHandPosition == null) {
            // Do nothing.
        } else if (previousRightHandPosition.z < right.PalmPosition.z - pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch -= 0.02f;
        } else if (previousRightHandPosition.z > right.PalmPosition.z + pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch += 0.02f;
        }
    }
}