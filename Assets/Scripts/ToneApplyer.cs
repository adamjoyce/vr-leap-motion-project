using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class ToneApplyer : MonoBehaviour {
    ToneSelector selector;
    float combined;
    float[] bubbleSpectrum = new float[128];
    Color color;
    SphereInteractiveItemVR sphIntItemVR;
    LeapProvider provider;
    List<Hand> hands;
    public bool pinched;
	// Use this for initialization
	void Start () 
    {
        selector = FindObjectOfType<ToneSelector>();
        GetComponent<AudioSource>().clip = selector.selected;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        sphIntItemVR = GetComponent<SphereInteractiveItemVR>();
        provider = FindObjectOfType<LeapProvider>();
        color = GetComponent<Renderer>().material.GetColor("_EmissionColor");
        float highestValue;
        if (color.r > color.g)
            highestValue = color.r;
        else
            highestValue = color.g;
        if (color.g > color.b)
            highestValue = color.g;
        else
            highestValue = color.b;
        color = new Color(color.r / highestValue, color.g / highestValue, color.b / highestValue);
	}
	
	// Update is called once per frame
	void Update () 
    {
        hands = provider.CurrentFrame.Hands;
        if (!sphIntItemVR.selected)
        {
            bubbleSpectrum = GetComponent<AudioSource>().GetSpectrumData(128, 0, FFTWindow.BlackmanHarris);
            for (int i = 0; i < 128; i++)
            {
                combined += bubbleSpectrum[i];
            }
            combined *= 100;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color * combined);
            combined = 0;
        }
        else if(sphIntItemVR.selected)
        {
            for(int i = 0; i<hands.Count; i++)
            {
                if(hands[i].IsRight)
                {
                    if(!pinched)
                    {
                        if(hands[i].PinchDistance < 25.0f)
                        {
                            if(GetComponent<AudioSource>().isPlaying)
                            {
                                GetComponent<AudioSource>().Pause();
                            }
                            else if(!GetComponent<AudioSource>().isPlaying)
                            {
                                GetComponent<AudioSource>().UnPause();
                            }
                            pinched = true;
                        }
                    }

                    else if(pinched)
                    { 
                        if(hands[i].PinchDistance > 35.0f)
                        {
                            pinched = false;
                        }
                    }
                }
            }
        }
	}
}
