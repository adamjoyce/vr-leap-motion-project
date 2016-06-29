using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Pitch : MonoBehaviour {

    public LeapProvider provider;
    public GameObject audio;

    public List<Hand> hands;
    public Hand left, right;

    public Vector previousRightHandPosition;

    public float pinchDistance = 10.0f;

    public float pitchIncrement = 0.001f;
    public float pitchChange = 0.02f;

    // Use this for initialization
    void Start() {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        hands = new List<Hand>();
        audio = GameObject.Find("AudioSource");
        previousRightHandPosition = new Vector();
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

            GameObject pinchLight = GameObject.Find("PinchSphere");
            if (left.PinchDistance < pinchDistance) {
                AdjustPitch();
                Vector3 pinchLightPos = left.Fingers[0].TipPosition.ToVector3();
                pinchLight.transform.position = pinchLightPos;
                pinchLight.GetComponent<MeshRenderer>().enabled = true;
            } else {
                pinchLight.GetComponent<MeshRenderer>().enabled = false;
            }
            //Debug.Log(left.PinchDistance);

        previousRightHandPosition = right.PalmPosition;
        }
    }

    //
    private void AdjustPitch() {
        Debug.Log(right.PalmPosition);
        if (previousRightHandPosition == null) {
            // Do nothing.
        } else if (previousRightHandPosition.z < right.PalmPosition.z - pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch -= pitchChange;
        } else if (previousRightHandPosition.z > right.PalmPosition.z + pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch += pitchChange;
        }
    }
}