using UnityEngine;
using System.Collections;
using Leap;

namespace Leap.Unity
{
    public class HueChange : MonoBehaviour
    {
        LeapProvider provider;
        Light light;
        public float delay = 0.005f;
        float hue = 0.0f, sat = 1.0f, val = 1.0f;
        // Use this for initialization
        void Start()
        {
            light = GetComponent<Light>();
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;
            Color.RGBToHSV(light.color, out hue, out sat, out val);
        }

        // Update is called once per frame
        void Update()
        {
            if (hue < 1)
            {
                hue = hue + delay;
            }
            else
            {
                hue = 0;
            }
            light.color = Color.HSVToRGB(hue, sat, val);

            //Frame frame = provider.CurrentFrame;
            //foreach (Hand hand in frame.Hands)
            //{
            //    if (hand.IsRight)
            //    {
            //        Vector3 position = hand.Direction.ToVector3() + hand.PalmNormal.ToVector3() * (transform.localScale.y * .5f + 0.2f);
            //        transform.rotation = Quaternion.LookRotation(position);
            //    }
            //}
        }
    }
}