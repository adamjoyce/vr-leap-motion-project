using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Startup : MonoBehaviour {
    public GameObject flocking;
    Bloom bloomScript;
    float bloomIntensityChange;
    float bloomThresholdChange;
	// Use this for initialization
	void Start () {
        bloomScript = FindObjectOfType<Bloom>();
        bloomScript.bloomIntensity = 0.5f;
        bloomScript.bloomThreshold = 3.0f;
        bloomIntensityChange = 0.5f;
        bloomThresholdChange = -0.25f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("BubbleSphere");
        int bubbleCount = gos.Length;
        bloomScript.bloomIntensity = 0.5f + (bloomIntensityChange * bubbleCount);
        bloomScript.bloomThreshold = 1.5f + (bloomThresholdChange * bubbleCount);
        if(bubbleCount > 5)
        {
            flocking.SetActive(true);
        }
	}
}
