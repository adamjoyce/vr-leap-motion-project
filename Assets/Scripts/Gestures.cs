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

    public float pinchDistance = 25.0f;
    public float minTriggerDistance = 0.05f;
	// Use this for initialization
	void Start () 
    {
        provider = FindObjectOfType<LeapProvider>();
        hands = new List<Hand>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        hands = provider.CurrentFrame.Hands;
        detectGestures();
	}

    void detectGestures()
    {
        if(hands[0].PinchDistance < pinchDistance && hands[1].PinchDistance < pinchDistance)
        {
            maestroMode = true;
            leftPinch = rightPinch = false;
            Debug.Log("Maestro");
        }
        else
        {
            maestroMode = false;
            for (int i = 0; i < hands.Count; i++ )
            {
                if (hands[i].IsLeft)
                {
                    if (hands[i].PinchDistance < pinchDistance)
                    {
                        leftPinch = true;
                        Debug.Log("Left Pinched");
                    }
                    else
                    {
                        leftPinch = false;
                    }
                }
                else
                {
                    if(hands[i].PinchDistance < pinchDistance)
                    {
                        rightPinch = true;
                        Debug.Log("Right Pinched");
                    }
                    else
                    {
                        rightPinch = false;
                    }
                }
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
}
