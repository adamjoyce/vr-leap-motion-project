using UnityEngine;
using System.Collections;

public class LightIntensity : MonoBehaviour
{
    private GameObject[] lights;
    private GameObject provider;
    private AudioSource audioSource;

    private float minPitch;
    private float maxPitch;

    private float minIntensity = -1.5f;
    private float maxIntensity = 3.0f;

    // Use this for initialization
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("PitchControlledLights");
        audioSource = GameObject.Find("AudioMain").GetComponent<AudioSource>();
        provider = GameObject.Find("LeapHandController");
        minPitch = provider.GetComponent<MusicController>().pitchMin;
        maxPitch = provider.GetComponent<MusicController>().pitchMax;
    }

    // Update is called once per frame
    void Update()
    {
        float normalisedPitch = (audioSource.pitch - minPitch) / (maxPitch - minPitch);
        Debug.Log(minPitch);
        float scaledIntensity = audioSource.pitch * (maxIntensity - minIntensity) + minIntensity;
        //Debug.Log(normalisedIntensity);
        for (int i = 0; i < lights.Length; i++)
            lights[i].GetComponent<Light>().intensity = scaledIntensity;
    }
}
