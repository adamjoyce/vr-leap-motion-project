using UnityEngine;
using System.Collections;

public class ToneApplyer : MonoBehaviour {
    ToneSelector selector;
    float combined;
    float[] bubbleSpectrum = new float[128];
    Color color;
	// Use this for initialization
	void Start () 
    {
        selector = FindObjectOfType<ToneSelector>();
        GetComponent<AudioSource>().clip = selector.selected;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
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
        bubbleSpectrum = GetComponent<AudioSource>().GetSpectrumData(128, 0, FFTWindow.BlackmanHarris);
        for(int i=0; i < 128; i++)
        {
            combined += bubbleSpectrum[i];
        }
        combined *= 100;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color*combined);
        combined = 0;
	}
}
