using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class ParticleAttacher : MonoBehaviour {
    public GameObject particleSystem;
    GameObject rightHand, leftHand;
    Transform[] leftFingers, rightFingers;
    bool leftVisible, rightVisible;
    LeapProvider provider;
    Hand left, right;
	// Use this for initialization
	void Start () 
    {
        provider = FindObjectOfType<LeapProvider>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        List<Hand> hands = provider.CurrentFrame.Hands;
        for (int i = 0; i < hands.Count; i++ )
        {
            if (hands[i].IsLeft)
                left = hands[i];
            else
                right = hands[i];
        }
        addParticles();
	}

    void addParticles()
    {
        if(left != null)
        {
            if (!leftVisible)
            {
                leftHand = GameObject.Find("RigidRoundHand_L");
                leftFingers = leftHand.GetComponentsInChildren<Transform>();
                foreach (Transform t in leftFingers)
                    if (t.name == "bone3")
                    {
                        GameObject particle = (GameObject)Instantiate(particleSystem, t.transform.position, Quaternion.identity);
                    }
                leftVisible = true;
            }
            
        }
        else
        {
            leftVisible = false;
        }

        if(right != null)
        {
            if (!rightVisible)
            {
                rightHand = GameObject.Find("RigidRoundHand_R");
                rightFingers = rightHand.GetComponentsInChildren<Transform>();
                foreach (Transform t in rightFingers)
                    if (t.name == "bone3")
                    {
                        GameObject particle = (GameObject)Instantiate(particleSystem, t.transform.position, Quaternion.identity);
                    }
                rightVisible = true;
            }
            
        }
        else
        {
            rightVisible = false;
        }
        
    }
}
