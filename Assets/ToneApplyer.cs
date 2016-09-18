using UnityEngine;
using System.Collections;

public class ToneApplyer : MonoBehaviour {
    ToneSelector selector;
    float combined;
    float[] bubbleSpectrum = new float[128];
	// Use this for initialization
	void Start () 
    {
        selector = FindObjectOfType<ToneSelector>();
        GetComponent<AudioSource>().clip = selector.selected;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
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
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white*combined);
        combined = 0;
	}
}
