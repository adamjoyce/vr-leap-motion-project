using UnityEngine;
using System.Collections;

public class LightLevel : MonoBehaviour
{
    float light;
    AudioSource aSource;
	// Use this for initialization
	void Start ()
    {
        aSource = FindObjectOfType<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        light = aSource.pitch;
        light = (light - (0.0f)) / (1.5f - (0.0f));
        if (light > 0.0f && light < 1.0f)
        {
            if (light <= 0.0f)
                light = 0.1f;
            else if (light >= 1.0f)
                light = 0.99f;
            gameObject.GetComponent<Light>().intensity = light;
        }
	}
}
