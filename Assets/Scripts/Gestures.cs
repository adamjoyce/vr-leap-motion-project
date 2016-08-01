using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Gestures : MonoBehaviour {
    //[HideInInspector]
    public bool leftPinch, rightPinch;
    //[HideInInspector]
    public bool maestroMode;
    //[HideInInspector]
    public bool gunMode;

    //[HideInInspector]
    public bool rightHandPosX, righthandNegX, rightHandPosY, rightHandNegY;
    //[HideInInspector]
    public bool letHandPosX, leftHandNegX, leftHandPosY, leftHandNegY;

    LeapProvider provider;
    List<Hand> hands;
    Hand left, right;

    public float pinchDistance = 25.0f;
    public float minTriggerDistance = 0.05f;
    Vector previousRightHandPosition, previousLeftHandPosition;
	// Use this for initialization
	void Start () 
    {
        provider = FindObjectOfType<LeapProvider>();
        hands = new List<Hand>();
        previousLeftHandPosition = new Vector();
        previousRightHandPosition = new Vector();
	}
	
	// Update is called once per frame
	void Update () 
    {
        hands = provider.CurrentFrame.Hands;
        for (int i = 0; i < hands.Count; i++ )
        {
            if (hands[i].IsLeft)
                left = hands[i];
            else
                right = hands[i];
        }
        detectGestures();
        detectMovement();
        previousRightHandPosition = right.PalmPosition;
        previousLeftHandPosition = left.PalmPosition;
	}

    void detectGestures()
    {
        if(left.PinchDistance < pinchDistance && right.PinchDistance < pinchDistance)
        {
            maestroMode = true;
            leftPinch = rightPinch = false;
            Debug.Log("Maestro");
        }
        else
        {
            maestroMode = false;
            if(left.PinchDistance < pinchDistance)
            {
                leftPinch = true;
                Debug.Log("Left Pinched");
            }
            else
            {
                leftPinch = false;
            }
            if(right.PinchDistance < pinchDistance)
            {
                rightPinch = true;
                Debug.Log("Right Pinched");
            }
            else
            {
                rightPinch = false;
            }           
        }

        for(int i=0; i < hands.Count; i++)
        {
            float triggerDistance = Vector3.Distance(hands[i].Fingers[0].TipPosition.ToVector3(), hands[i].Fingers[1].Bone(Bone.BoneType.TYPE_PROXIMAL).Center.ToVector3());
            if(hands[i].Fingers[1].IsExtended && !hands[i].Fingers[2].IsExtended && !hands[i].Fingers[3].IsExtended && !hands[i].Fingers[4].IsExtended && triggerDistance < minTriggerDistance)
            {
                gunMode = true;

            }
            else
            {
                gunMode = false;
            }
        }
    }

    void detectMovement()
    {
        if(leftPinch)
        {
            //Do nothing
        }
        else if(rightPinch)
        {
            //Do nothing
        }
        else if(maestroMode)
        {
            for(int i = 0; i<hands.Count; i++)
            {
                xAxisMovement(hands[i]);
                yAxisMovement(hands[i]);
            }
        }
    }

    void yAxisMovement(Hand hand)
    {
        if(hand.IsLeft)
        {
            if(previousLeftHandPosition == null)
            {
                //Do nothing
            }
            else if(previousLeftHandPosition.y < left.PalmPosition.y - 0.001f)
            {
                leftHandPosY = true;
                leftHandNegY = false;
                Debug.Log("Moving up");
            }
            else if (previousLeftHandPosition.y > left.PalmPosition.y + 0.001f)
            {
                leftHandPosY = false;
                leftHandNegY = true;
                Debug.Log("Moving down");
            }
            else
            {
                leftHandPosY = false;
                leftHandNegY = false;
            }
        }
        else
        {
            if (previousRightHandPosition == null)
            {
                //Do nothing
            }
            else if (previousRightHandPosition.y < right.PalmPosition.y - 0.001f)
            {
                rightHandPosY = true;
                rightHandNegY = false;
                Debug.Log("Moving up");
            }
            else if (previousRightHandPosition.y > right.PalmPosition.y + 0.001f)
            {
                rightHandPosY = false;
                rightHandNegY = true;
                Debug.Log("Moving down");
            }
            else
            {
                rightHandPosY = false;
                rightHandNegY = false;
            }
        }
    }

    void xAxisMovement(Hand hand)
    {
        if (hand.IsLeft)
        {

        }
        else
        {

        }
    }
}
