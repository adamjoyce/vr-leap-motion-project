using UnityEngine;
using System.Collections;

public class AudioSpectrum : MonoBehaviour {
    float[] spectrum = new float[128];
    float average = 0;
    public float scale;
    AudioSource main;
    public GameObject terrain;
	// Use this for initialization
	void Start ()
    {
        AudioSource[] gos = FindObjectsOfType<AudioSource>();
        foreach(AudioSource asource in gos)
        {
            if (asource.name == "AudioMain")
                main = asource;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        spectrum = main.GetSpectrumData(128, 0, FFTWindow.BlackmanHarris);
        for(int i = 0; i < 128; i++)
        {
            average += spectrum[i];
        }
        average *= scale;
        terrain.GetComponent<Renderer>().material.SetFloat("_Depth", -average);
        //Debug.Log(average);
        average = 0;
        
	}
}
