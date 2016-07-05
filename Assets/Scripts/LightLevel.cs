using UnityEngine;
using System.Collections;

public class LightLevel : MonoBehaviour
{
    Light light;
    AudioSource aSource;
	// Use this for initialization
	void Start ()
    {
        aSource = FindObjectOfType<AudioSource>();
        light = gameObject.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        changeLightLevel();
	}

    void changeLightLevel()
    {
        if(light.intensity > 0.0f && light.intensity < 1.0f)
        {
            if (light.intensity <= 0.0f)
                light.intensity = 0.1f;
            else if (light.intensity >= 1.0f)
                light.intensity = 0.99f;
            else
                light.intensity = aSource.pitch;
        }
    }
}
