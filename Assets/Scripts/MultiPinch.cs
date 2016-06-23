using UnityEngine;
using System.Collections;
using Leap;

namespace Leap.Unity
{
    public enum FingerAllocation
    {
        Index = 1,
        Middle = 2,
        Ring = 3,
        Pinky = 4,
    }

    [System.Serializable]
    public class CubeAssociation
    {
        public GameObject cube;
        public Material defMat, pinchMat;
        public FingerAllocation finger;
    }

    public class MultiPinch : MonoBehaviour {
        Controller controller;
        public CubeAssociation[] associations;

        public 
	    // Use this for initialization
	    void Start () {
            controller = FindObjectOfType<LeapServiceProvider>().GetLeapController();
	    }

        public int getPinch()
        {
            Frame frame = controller.Frame();
            //Debug.Log(frame.Id.ToString());
            foreach(Hand hand in frame.Hands)
            {
                Finger thumb = hand.Fingers[0];
                Vector3 thumbTip = thumb.TipPosition.ToVector3();
                for (int i = 1; i < hand.Fingers.Count; i++)
                {

                    Vector3 fingerTip = hand.Fingers[i].TipPosition.ToVector3();
                    float distance = Vector3.Distance(thumbTip, fingerTip);
                    if (distance < 50)
                    {
                        //Debug.Log(distance);
                        return (int) hand.Fingers[i].Type;
                        //Debug.Log((int)hand.Fingers[i].Type);
                    }
                }
            }
            return 0;
        }
	
	    // Update is called once per frame
	    void Update () {
           
            for( int i = 0; i < associations.Length; i++)
            {
                if((int)associations[i].finger == getPinch())
                {
                    associations[i].cube.GetComponent<Renderer>().material = associations[i].pinchMat;
                }
                else
                {
                    associations[i].cube.GetComponent<Renderer>().material = associations[i].defMat;
                }
            }
	    }
    }
}

