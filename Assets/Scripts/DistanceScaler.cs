using UnityEngine;
using System.Collections;

public class DistanceScaler : MonoBehaviour
{
    public GameObject player;

    public float distanceFromPlayer;
    public float scaleFactor;
    public float minScale = 0.05f;
    public float maxScale = 100.0f;

    private Transform haloLight;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("LMHeadMountedRig");
        haloLight = transform.Find("HaloLight");
        scaleFactor = 1.008f;
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < minScale || transform.localScale.x > maxScale)
        {
            // Do nuffin.
        }
        else
        {
            float currentDistance = Vector3.Distance(transform.position, player.transform.position);
            if (currentDistance > distanceFromPlayer)
            {
                transform.localScale *= scaleFactor;
                haloLight.GetComponent<Light>().range *= scaleFactor;
                //Color emission = GetComponent<Renderer>().material.GetColor("_EmissionColor");
                ////Debug.Log("Emission: " + emission.linear);
                //emission *= scaleFactor;
                //emission = (emission - 0.0f) / 
                //Debug.Log(emission);
                //GetComponent<Renderer>().material.SetColor("_EmissionColor", emission);
            }
            else if (currentDistance < distanceFromPlayer)
            {
                transform.localScale *= -scaleFactor;
                haloLight.GetComponent<Light>().range *= -scaleFactor;
            }
        }
    }
}