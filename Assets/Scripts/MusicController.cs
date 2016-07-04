using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class MusicController : MonoBehaviour {

    public LeapProvider provider;
    public GameObject audio;
    public GameObject reverb;

    public List<Hand> hands;
    public Hand left, right;

    public Vector previousRightHandPosition;

    public float pinchDistance = 25.0f;

    public float pitchIncrement = 0.001f;
    public float pitchChange = 0.015f;

    public float reverbIncrement = 0.001f;
    public int reverbChange = 1;

    // Use this for initialization
    void Start() {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        if (!provider) {
            Debug.Log("Error: A LeapProvider could not be found in the scene.");
            return;
        }

        audio = GameObject.Find("AudioSource");
        if (!audio) {
            Debug.Log("Error: \"AudioSource\" could not be found in the scene.");
            return;
        }

        reverb = GameObject.Find("ReverbZone");
        if (!reverb) {
            Debug.Log("Error: \"ReverbZone\" could not be found in the scene.");
            return;
        }

        hands = new List<Hand>();
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
                AdjustReverb();
            }

            previousRightHandPosition = right.PalmPosition;
        }
    }

    // Displays the pinch spheres and returns true if both hands are pinched.
    private bool displayPinches() {
        bool leftPinched = false;
        bool rightPinched = false;

        // Left.
        GameObject leftPinchSphere = GameObject.Find("LeftPinchSphere");
        if (handPinched(left)) {
            Vector3 leftPinchSpherePos = left.Fingers[0].TipPosition.ToVector3();
            leftPinchSphere.transform.position = leftPinchSpherePos;
            leftPinchSphere.GetComponent<MeshRenderer>().enabled = true;
            leftPinched = true;
        } else {
            leftPinchSphere.GetComponent<MeshRenderer>().enabled = false;
        }

        // Right.
        GameObject rightPinchSphere = GameObject.Find("RightPinchSphere");
        if (handPinched(right)) {
            Vector3 rightPinchSpherePos = right.Fingers[0].TipPosition.ToVector3();
            rightPinchSphere.transform.position = rightPinchSpherePos;
            rightPinchSphere.GetComponent<MeshRenderer>().enabled = true;
            rightPinched = true;
        } else {
            rightPinchSphere.GetComponent<MeshRenderer>().enabled = false;
        }

        return leftPinched && rightPinched;
    }

    // Returns true if the hand is pinched.
    private bool handPinched(Hand hand) {
        if (hand.PinchDistance < pinchDistance) {
            return true;
        }
        return false;
    }

    // Adjusts the pitch for the music according to palm position.
    private void AdjustPitch() {
        //Debug.Log(right.PalmPosition);
        if (previousRightHandPosition == null) {
            // Do nothing.
        } else if (previousRightHandPosition.y < right.PalmPosition.y - pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch += pitchChange;
        } else if (previousRightHandPosition.y > right.PalmPosition.y + pitchIncrement) {
            audio.GetComponent<AudioSource>().pitch -= pitchChange;
        }
    }

    //
    private void AdjustReverb() {
        Debug.Log(right.PalmPosition);
        if (previousRightHandPosition == null) {
            // Do nothing.
        } else if (previousRightHandPosition.x < right.PalmPosition.x - reverbIncrement) {
            reverb.GetComponent<AudioReverbZone>().reverb += reverbChange;
        } else if (previousRightHandPosition.x > right.PalmPosition.x + reverbIncrement && reverb.GetComponent<AudioReverbZone>().reverb >= 0) {
            reverb.GetComponent<AudioReverbZone>().reverb -= reverbChange;
        }
    }
}