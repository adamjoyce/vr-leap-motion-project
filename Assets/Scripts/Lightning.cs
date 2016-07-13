using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lightning : MonoBehaviour 
{
    List<Light> pointLights;
    float minTime = 0.1f;
    float threshold = 0.5f;
    int pickedLight;

    private float lastTime = 0.0f;
	// Use this for initialization
	void Start () 
    {
        pointLights = new List<Light>();
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
            if (light.type == LightType.Point)
                pointLights.Add(light);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if((Time.time - lastTime ) > minTime)
            
            if(Random.value > threshold)
            {
                pickedLight = Random.Range(0, pointLights.Count);
                float lightIntensity = Random.Range(2.75f, 8.5f);
                pointLights[pickedLight].enabled = true;
                pointLights[pickedLight].intensity = lightIntensity;
            }
            else
            {
                foreach (Light light in pointLights)
                    light.enabled = false;
                lastTime = Time.time;
            }
	}
}
