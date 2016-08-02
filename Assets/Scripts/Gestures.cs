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
    public bool leftGunMode, rightGunMode;

    //[HideInInspector]
    public bool rightHandPosX, rightHandNegX, rightHandPosY, rightHandNegY;
    //[HideInInspector]
    public bool leftHandPosX, leftHandNegX, leftHandPosY, leftHandNegY;

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
        detectMaestro();
        detectPinch();
        detectGun();
        detectMovement();
        if (left != null && right != null)
        {
            previousRightHandPosition = right.PalmPosition;
            previousLeftHandPosition = left.PalmPosition;
        }
	}
    
    void detectMaestro()
    {
        if(left != null && right != null)
        {
            if (left.PinchDistance < pinchDistance && right.PinchDistance < pinchDistance)
            {
                maestroMode = true;
                leftPinch = rightPinch = false;
                //Debug.Log("Maestro");
            }

            else
            {
                maestroMode = false;
            }
        }
    }

    void detectPinch()
    {
        if(maestroMode == false)
        {
            if (left != null)
            {
                if (left.PinchDistance < pinchDistance)
                {
                    leftPinch = true;
                    //Debug.Log("Left Pinched");
                }
                else
                {
                    leftPinch = false;
                }
            }

            if (right != null)
            {
                if (right.PinchDistance < pinchDistance)
                {
                    rightPinch = true;
                    //Debug.Log("Right Pinched");
                }
                else
                {
                    rightPinch = false;
                }
            }
        }
    }

    void detectGun()
    {
        if(left != null)
        {
            float triggerDistance = Vector3.Distance(left.Fingers[0].TipPosition.ToVector3(), left.Fingers[1].Bone(Bone.BoneType.TYPE_PROXIMAL).Center.ToVector3());
            if(left.Fingers[1].IsExtended && !left.Fingers[2].IsExtended && !left.Fingers[3].IsExtended && !left.Fingers[4].IsExtended && triggerDistance < minTriggerDistance)
            {
                leftGunMode = true;
            }

            else
            {
                leftGunMode = false;
            }
        }

        if( right != null)
        {
            float triggerDistance = Vector3.Distance(right.Fingers[0].TipPosition.ToVector3(), right.Fingers[1].Bone(Bone.BoneType.TYPE_PROXIMAL).Center.ToVector3());
            if (right.Fingers[1].IsExtended && !right.Fingers[2].IsExtended && !right.Fingers[3].IsExtended && !right.Fingers[4].IsExtended && triggerDistance < minTriggerDistance)
            {
                rightGunMode = true;
            }
            else
            {
                rightGunMode = false;
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
                //Debug.Log("Moving up");
            }
            else if (previousLeftHandPosition.y > left.PalmPosition.y + 0.001f)
            {
                leftHandPosY = false;
                leftHandNegY = true;
                //Debug.Log("Moving down");
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
                //Debug.Log("Moving up");
            }
            else if (previousRightHandPosition.y > right.PalmPosition.y + 0.001f)
            {
                rightHandPosY = false;
                rightHandNegY = true;
                //Debug.Log("Moving down");
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
            if (previousLeftHandPosition == null)
            {
                //Do nothing
            }
            else if (previousLeftHandPosition.x < left.PalmPosition.x - 0.001f)
            {
                leftHandPosX = true;
                leftHandNegX = false;
                //Debug.Log("Moving right");
            }
            else if (previousLeftHandPosition.x > left.PalmPosition.x + 0.001f)
            {
                leftHandPosX = false;
                leftHandNegX = true;
                //Debug.Log("Moving left");
            }
            else
            {
                leftHandPosX = false;
                leftHandNegX = false;
            }
        }
        else
        {
            if (previousRightHandPosition == null)
            {
                //Do nothing
            }
            else if (previousRightHandPosition.x < right.PalmPosition.x - 0.001f)
            {
                rightHandPosX = true;
                rightHandNegX = false;
                //Debug.Log("Moving left");
            }
            else if (previousRightHandPosition.x > right.PalmPosition.x + 0.001f)
            {
                rightHandPosX = false;
                rightHandNegX = true;
                //Debug.Log("Moving right");
            }
            else
            {
                rightHandPosX = false;
                rightHandNegX = false;
            }
        }
    }
}
