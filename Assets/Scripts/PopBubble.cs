using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class PopBubble : MonoBehaviour
{
    //public LeapProvider provider;
    public Controller leapController;

    //private List<Hand> hands;

    void Start()
    {
        //if (!provider)
        //    provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        leapController = GameObject.Find("LeapHandController").GetComponent<Controller>();

        //hands = new List<Hand>();
    }

    void Update()
    {
        if (leapController.IsConnected)
        {
            Frame frame = leapController.Frame();

            if (frame.Hands.Count > 0)
            {
                for (int i = 0; i < frame.Hands.Count; i++)
                {
                    Debug.DrawRay(frame.Hands[i].Fingers[1].TipPosition.ToVector3(), frame.Hands[i].Fingers[1].Direction.ToVector3(), Color.red);
                    Debug.Log(frame.Hands[i].Fingers[1].TipPosition.ToVector3());
                }
            }
        }


        //hands = provider.CurrentFrame.Hands;
        //if (hands.Count > 0)
        //{
        //    for (int i = 0; i < hands.Count; i++)
        //    {
        //        Debug.DrawRay(hands[i].Fingers[1].TipPosition.ToVector3(), hands[i].Fingers[1].Direction.ToVector3(), Color.red);
        //    }
        //}
    }
}