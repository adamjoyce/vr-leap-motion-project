using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class PopBubble : MonoBehaviour
{
    public LeapProvider provider;
    public Camera mainCamera;

    private List<Hand> hands;

    void Start()
    {
        if (!provider)
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        if (!mainCamera)
            mainCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();

        hands = new List<Hand>();
    }

    void Update()
    {
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 0)
        {
            for (int i = 0; i < hands.Count; i++)
            {
                Ray ray = new Ray(mainCamera.transform.position, (hands[i].Fingers[1].TipPosition.ToVector3() - mainCamera.transform.position));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "BubbleSphere")
                       Debug.Log("HIT");
                }
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                //Debug.Log("Direction: " + ray.direction + " FingerTip: " + hands[i].Fingers[1].TipPosition.ToVector3());
            }
        }
    }
}