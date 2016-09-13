using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Startup : MonoBehaviour {
    Light memLight;
    Light terLight;
    public float memlightLow;
    public float memlightHigh;
    public float terlightLow;
    public float terlightHigh;
    public float bloomIntensityLow;
    public float bloomIntensityHigh;
    public float bloomThresholdLow;
    public float bloomThresholdHigh;
    public float maxemission = 1.0f;
    public float mindepth = -25.2f;
    public float maxdepth = 9.0f;
    public float depthoffset = 1.0f;
    public float facetWaitTime = 10.0f;
    public float memLightWaitTime = 20.0f;
    bool pos = true;
    AudioSource asource;
    float facetCounter;
    float memCounter;
    Material facet;
    float lengthOfSong;
    float lastMinute;
    float terLightChangeValue;
    float memLightChangeValue;
    Bloom bloomScript;
    float bloomIntensityChange;
    float bloomThresholdChange;
	// Use this for initialization
	void Start () {
        memLight = GameObject.Find("MembraneLight").GetComponent<Light>();
        terLight = GameObject.Find("TerrainLight").GetComponent<Light>();
        bloomScript = FindObjectOfType<Bloom>();
        memLight.intensity = memlightLow;
        terLight.intensity = terlightLow;
        GameObject.Find("Cloth").GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
        asource = GameObject.Find("AudioMain").GetComponent<AudioSource>();
        facet = GameObject.Find("faceted Valley").GetComponent<Renderer>().material;
        facet.SetFloat("_Depth", -25.2f);
        lengthOfSong = asource.clip.length;
        lastMinute = lengthOfSong - 40f;
        terLightChangeValue = terlightHigh / (120 * 15);
        memLightChangeValue = memlightHigh / (30f * 30);
        bloomScript.bloomIntensity = 0.5f;
        bloomScript.bloomThreshold = 3.0f;
        bloomIntensityChange = 3.5f / (60f * 30);
        bloomThresholdChange = 3.0f / (60f * 30);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Color color = GameObject.Find("Cloth").GetComponent<Renderer>().material.GetColor("_EmissionColor");
	    if(asource.pitch > 0.45f)
        {
            if (memCounter < memLightWaitTime)
                memCounter = asource.time;
            if(memCounter >= memLightWaitTime)
            {
                if (memLight.intensity < memlightHigh)
                    memLight.intensity += memLightChangeValue;
            }
            if (terLight.intensity < terlightHigh)
                terLight.intensity += terLightChangeValue;
            
        }
        if(asource.pitch > 0.75f)
        {
            
            if (color.r < 1)
            {
                color += new Color(0.01f, 0.01f, 0.01f, 0.01f);
                GameObject.Find("Cloth").GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            }
        }
        
        if(color.r >=1.0f)
        {
            if(facetCounter < facetWaitTime)
                facetCounter += Time.deltaTime;
            if(facetCounter >= facetWaitTime)
            {
                float facetDepth = facet.GetFloat("_Depth");
                if(pos)
                {
                    if (facetDepth >= maxdepth)
                        pos = !pos;
                    facetDepth += depthoffset;
                }
                else if(!pos)
                {
                    if (facetDepth <= mindepth)
                        pos = !pos;
                    facetDepth -= depthoffset;
                }
                facet.SetFloat("_Depth", facetDepth);
            }
        }

        if(Time.time >= 140)
        {
            bloomScript.bloomIntensity += bloomIntensityChange;
            bloomScript.bloomThreshold -= bloomThresholdChange;
        }
	}
}
