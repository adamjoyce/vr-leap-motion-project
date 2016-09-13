using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlareScaler : MonoBehaviour {
    List<Transform> flares;
    Color sphereColor;
    SpawnPrimitives sphereCreation;
    Material mat;
	// Use this for initialization
	void Start ()
    {
        sphereCreation = FindObjectOfType<SpawnPrimitives>();
        mat = GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material = mat;
        sphereColor = mat.GetColor("_EmissionColor");
        float highestValue;
        if (sphereColor.r > sphereColor.g)
            highestValue = sphereColor.r;
        else
            highestValue = sphereColor.g;
        if(sphereColor.g > sphereColor.b)
            highestValue = sphereColor.g;
        else
            highestValue = sphereColor.b;
        sphereColor = new Color(sphereColor.r / highestValue, sphereColor.g / highestValue, sphereColor.b / highestValue);
        Transform[] allTrans = gameObject.GetComponentsInChildren<Transform>();
        flares = new List<Transform>();
        foreach(Transform t in allTrans)
        {
            if(t.tag == "Flare")
            {
                flares.Add(t);
            }
        }
        //Debug.Log(flares.Count);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (sphereCreation.sphereAttached)
        {
            foreach (Transform flare in flares)
            {
                Vector3 gameObjectScale = gameObject.GetComponent<Transform>().localScale;
                float newScale = (gameObjectScale.x - 0.1f) / (0.35f - 0.1f);
                if (newScale < 0.0)
                    newScale = 0.0f;
                else if (newScale > 1.0f)
                    newScale = 1.0f;
                flare.localScale = new Vector3(newScale + 1, newScale + 1, newScale + 1);
                //GetComponent<Renderer>().material.SetColor("_EmissionColor", sphereColor * (newScale * 10));
            }
        }
        else if(!sphereCreation.sphereAttached)
        {
            foreach (Transform flare in flares)
                flare.gameObject.SetActive(false);
        }
	}
}
