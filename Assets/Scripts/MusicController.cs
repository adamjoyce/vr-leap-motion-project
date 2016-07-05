using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class MusicController : MonoBehaviour
{
    public LeapProvider provider;
    public GameObject audioSource;
    public GameObject reverbZone;

    public List<Hand> hands;
    public Hand left, right;

    public Vector previousRightHandPosition;

    public Light[] lights;

    public float pinchDistance = 25.0f;

    public float pitchIncrement = 0.001f;
    public float pitchChange = 0.015f;
    public float pitchMin = -1.5f;
    public float pitchMax = 1.5f;

    public float reverbIncrement = 0.001f;
    public int reverbChange = 1;

    // Use this for initialization.
    void Start()
    {
        // Ensure the public variables are assigned.
        if (!provider)
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        if (!audioSource)
            audioSource = GameObject.Find("AudioSource");
        if (!reverbZone)
            reverbZone = GameObject.Find("ReverbZone");

        hands = new List<Hand>();
        previousRightHandPosition = new Vector();

        lights = GameObject.Find
    }

    // Update is called once per frame.
    void Update()
    {
        // Update the hand information for this frame.
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 1)
        {
            for (int i = 0; i < hands.Count; i++)
            {
                if (hands[i].IsLeft)
                {
                    left = hands[i];
                }
                else
                {
                    right = hands[i];
                }
            }

            if (displayPinches())
            {
                AdjustPitch();
                AdjustReverb();
            }

            previousRightHandPosition = right.PalmPosition;
        }
    }

    // Displays the pinch spheres and returns true if both hands are pinched.
    private bool displayPinches()
    {
        bool leftPinched = false;
        bool rightPinched = false;

        // Left.
        GameObject leftPinchSphere = GameObject.Find("LeftPinchSphere");
        if (handPinched(left))
        {
            Vector3 leftPinchSpherePos = left.Fingers[0].TipPosition.ToVector3();
            leftPinchSphere.transform.position = leftPinchSpherePos;
            leftPinchSphere.GetComponent<MeshRenderer>().enabled = true;
            leftPinched = true;
        }
        else
        {
            leftPinchSphere.GetComponent<MeshRenderer>().enabled = false;
        }

        // Right.
        GameObject rightPinchSphere = GameObject.Find("RightPinchSphere");
        if (handPinched(right))
        {
            Vector3 rightPinchSpherePos = right.Fingers[0].TipPosition.ToVector3();
            rightPinchSphere.transform.position = rightPinchSpherePos;
            rightPinchSphere.GetComponent<MeshRenderer>().enabled = true;
            rightPinched = true;
        }
        else
        {
            rightPinchSphere.GetComponent<MeshRenderer>().enabled = false;
        }

        return leftPinched && rightPinched;
    }

    // Returns true if the hand is pinched.
    private bool handPinched(Hand hand)
    {
        if (hand.PinchDistance < pinchDistance)
        {
            return true;
        }
        return false;
    }

    // Adjusts the pitch of the music based on palm position of the right hand.
    private void AdjustPitch()
    {
        if (previousRightHandPosition == null)
        {
            // Do nothing.
        }
        else if (previousRightHandPosition.y < right.PalmPosition.y - pitchIncrement)
        {
            //// Rounds to the nearest integer if pitch it at or past the minimum or maximum.
            //if (audioSource.GetComponent<AudioSource>().pitch > pitchMax || audioSource.GetComponent<AudioSource>().pitch < pitchMin)
            //{
            //    audioSource.GetComponent<AudioSource>().pitch = Mathf.Round(audioSource.GetComponent<AudioSource>().pitch);
            //}
            //else
            //{

            audioSource.GetComponent<AudioSource>().pitch = Mathf.Clamp((audioSource.GetComponent<AudioSource>().pitch += pitchChange), pitchMin, pitchMax);
            //}
        }
        else if (previousRightHandPosition.y > right.PalmPosition.y + pitchIncrement)
        {
            //// Rounds to the nearest integer if pitch it at or past the minimum or maximum.
            //if (audioSource.GetComponent<AudioSource>().pitch > pitchMax || audioSource.GetComponent<AudioSource>().pitch < pitchMin)
            //{
            //    audioSource.GetComponent<AudioSource>().pitch = Mathf.Round(audioSource.GetComponent<AudioSource>().pitch);
            //}
            //else
            //{
                
            audioSource.GetComponent<AudioSource>().pitch = Mathf.Clamp((audioSource.GetComponent<AudioSource>().pitch -= pitchChange), pitchMin, pitchMax);
            //}
        }
        //Debug.Log(right.PalmPosition);
    }

    // Adjusts the reverb of the music based on palm position of the right hand.
    private void AdjustReverb()
    {
        if (previousRightHandPosition == null)
        {
            // Do nothing.
        }
        else if (previousRightHandPosition.x < right.PalmPosition.x - reverbIncrement)
        {
            reverbZone.GetComponent<AudioReverbZone>().reverb += reverbChange;
        }
        else if (previousRightHandPosition.x > right.PalmPosition.x + reverbIncrement && reverbZone.GetComponent<AudioReverbZone>().reverb >= 0)
        {
            reverbZone.GetComponent<AudioReverbZone>().reverb -= reverbChange;
        }
        //Debug.Log(right.PalmPosition);
    }
}