using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class ModifyLand : MonoBehaviour
{
    public LeapProvider provider;
    public List<Hand> hands;

    private Vector3 handPos;

    // Use this for initialization
    void Start()
    {
        // Ensure the public variables are assigned.
        if (!provider)
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        handPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the hand information for this frame.
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 1)
        {
            Debug.Log("Old: " + handPos);
            Debug.Log("Current: " + hands[0].PalmPosition.ToVector3());
            if (handPos == null)
            {
                // DO nuffin.
            }
            else if (handPos.z < hands[0].PalmPosition.ToVector3().z)
            {
                GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, Mathf.Lerp(GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0), GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) - 1f, Time.deltaTime));
            }
            else if (handPos.z > hands[0].PalmPosition.ToVector3().z)
            {
                GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, Mathf.Lerp(GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0), GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) + 1f, Time.deltaTime));
            }
            handPos = hands[0].PalmPosition.ToVector3();
        }
    }
}

