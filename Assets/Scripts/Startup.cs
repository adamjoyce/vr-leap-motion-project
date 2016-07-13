using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Startup : MonoBehaviour 
{
    AudioSource aSource;
    List<Light> directionalLights;
    List<Light> pointLights;
    Lightning lightning;
	// Use this for initialization
	void Start () 
    {
        directionalLights = new List<Light>();
        pointLights = new List<Light>();
        aSource = GameObject.FindObjectOfType<AudioSource>();
        Light[] lights = FindObjectsOfType<Light>();
        foreach(Light light in lights)
            if(light.type == LightType.Directional)
                directionalLights.Add(light);
            else if(light.type == LightType.Point)
                pointLights.Add(light);

        aSource.pitch = -0.5f;
        aSource.Pause();
        foreach (Light light in directionalLights)
            light.intensity = 0;
        foreach (Light light in pointLights)
            light.enabled = false;

        lightning = FindObjectOfType<Lightning>();
        lightning.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        int bSpheres = 0;
        bSpheres = GameObject.FindGameObjectsWithTag("BubbleSphere").Length;
        Debug.Log(bSpheres);
        if(bSpheres > 5)
        {
            aSource.pitch = 1;
            aSource.UnPause();
            Debug.Log("Playing now");
        }
	}
}
