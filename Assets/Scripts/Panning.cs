using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Panning : MonoBehaviour {

    public Controller controller;
    public List<Hand> hands;
    public GameObject audio;

    public Vector previousLeftHandPosition;

    private float pitchIncrement = 1.0f;

    // Use this for initialization
    void Start() {
        controller = GetComponent<LeapServiceProvider>().GetLeapController();
        hands = new List<Hand>();
        audio = GameObject.Find("AudioSource");
    }

    // Update is called once per frame
    void Update() {
        // Update the hand information for this frame.
        Frame frame = controller.Frame();
        if (frame.Hands.Count > 0) {
            hands = frame.Hands;
            AdjustPitch();
            previousLeftHandPosition = hands[0].PalmPosition;
        }
    }

    //
    private void AdjustPitch() {
        if (previousLeftHandPosition == null) {
            // Do nothing.
        } else if (previousLeftHandPosition.z < hands[0].PalmPosition.z - pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch -= 0.005f;
        } else if (previousLeftHandPosition.z > hands[0].PalmPosition.z + pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch += 0.005f;
        }
    }
}