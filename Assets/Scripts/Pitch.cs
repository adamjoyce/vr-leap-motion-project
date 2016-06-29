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

    public float pinchDistance = 25.0f;

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

            if (displayPinches()) {
                AdjustPitch();
            }

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

    // Displays the pinch spheres and returns true if both hands are pinched.
    private bool displayPinches() {
        bool leftPinched = false;
        bool rightPinched = false;

        // Left.
        GameObject leftPinchSphere = GameObject.Find("LeftPinchSphere");
        if (left.PinchDistance < pinchDistance) {
            Vector3 leftPinchSpherePos = left.Fingers[0].TipPosition.ToVector3();
            leftPinchSphere.transform.position = leftPinchSpherePos;
            leftPinchSphere.GetComponent<MeshRenderer>().enabled = true;
            leftPinched = true;
        } else {
            leftPinchSphere.GetComponent<MeshRenderer>().enabled = false;
        }

        // Right.
        GameObject rightPinchSphere = GameObject.Find("RightPinchSphere");
        if (right.PinchDistance < pinchDistance) {
            Vector3 rightPinchSpherePos = right.Fingers[0].TipPosition.ToVector3();
            rightPinchSphere.transform.position = rightPinchSpherePos;
            rightPinchSphere.GetComponent<MeshRenderer>().enabled = true;
            rightPinched = true;
        } else {
            rightPinchSphere.GetComponent<MeshRenderer>().enabled = false;
        }

        return leftPinched && rightPinched;
    }
}