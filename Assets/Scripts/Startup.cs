using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Startup : MonoBehaviour 
{
    AudioSource aSource;
    List<Light> directionalLights;
    List<Light> pointLights;
    Lightning lightning;
    bool playingAudio = false, pointLightsActive = false;
	// Use this for initialization
	void Start () 
    {
        directionalLights = new List<Light>();
        pointLights = new List<Light>();
        aSource = GameObject.FindObjectOfType<AudioSource>();
        GameObject[] lights = GameObject.FindGameObjectsWithTag("StartsOff");
        foreach (GameObject light in lights)
        {
            Light lightComp = light.GetComponent<Light>();
            if (lightComp.type == LightType.Directional)
                directionalLights.Add(lightComp);
            else if (lightComp.type == LightType.Point)
                pointLights.Add(lightComp);

        }

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
        //Debug.Log(bSpheres);
        if (!playingAudio)
        {
            if (bSpheres > 5)
            {
                aSource.pitch = 1;
                aSource.UnPause();
                //Debug.Log("Playing now");
                playingAudio = true;
            }
        }

        if (!pointLightsActive)
        {
            if (aSource.isPlaying)
            {
                if (aSource.pitch < -0.5f)
                {
                    foreach (Light light in pointLights)
                        light.enabled = true;
                    pointLightsActive = true;
                }
            }
        }
	}
}
