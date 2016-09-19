using UnityEngine;
using System.Collections;

public class AudioSpectrum : MonoBehaviour {
    float[] spectrum = new float[128];
    float average = 0;
    public float scale;
    AudioSource main;
    AudioSource[] sources;
    public GameObject terrain;
	// Use this for initialization
	void Start ()
    {
        //AudioSource[] gos = FindObjectsOfType<AudioSource>();
        //foreach(AudioSource asource in gos)
        //{
        //    if (asource.name == "AudioMain")
        //        main = asource;
        //}
	}
	
	// Update is called once per frame
	void Update ()
    {
        sources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in sources)
        {
            spectrum = source.GetSpectrumData(128, 0, FFTWindow.BlackmanHarris);
            for (int i = 0; i < 128; i++)
            {
                average += spectrum[i];
            }
            
            //Debug.Log(average);
        }
        average /= (128 * sources.Length);
        average *= scale;
        Debug.Log(average);
        terrain.GetComponent<Renderer>().material.SetFloat("_Depth", average);
        average = 0;
	}
}
