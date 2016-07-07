using UnityEngine;
using System.Collections;

public class LightLevel : MonoBehaviour
{
    float light;
    public float min = 0.0f, max = 1.5f;
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
        light = (light - (min)) / (max - (min));
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
