using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
        public string blendShapeName;
        public FingerAllocation finger;
    }

    public class MultiPinch : MonoBehaviour 
    {
        Controller controller;
        public List<CubeAssociation> associations;
        public SkinnedMeshRenderer skinMeshRend;
        public Mesh sharedmesh;
        public List<string> blendShapeNames;
        public 
	    // Use this for initialization
	    void Start () 
        {
            controller = FindObjectOfType<LeapServiceProvider>().GetLeapController();
            sharedmesh = skinMeshRend.sharedMesh;
            blendShapeNames = new List<string>();
            associations = new List<CubeAssociation>();
            for(int i= 0; i<sharedmesh.blendShapeCount; i++)
            {
                CubeAssociation temp = new CubeAssociation();
                temp.blendShapeName = sharedmesh.GetBlendShapeName(i);
                temp.finger = (FingerAllocation)i + 1;
                associations.Add(temp);
            }
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
	    void Update () 
        {
           
            //for( int i = 0; i < associations.Length; i++)
            //{
            //    if((int)associations[i].finger == getPinch())
            //    {
            //        //associations[i].cube.GetComponent<Renderer>().material = associations[i].pinchMat;
            //    }
            //    else
            //    {
            //        //associations[i].cube.GetComponent<Renderer>().material = associations[i].defMat;
            //    }
            //}
	    }
    }
}

