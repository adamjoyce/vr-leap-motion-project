using UnityEngine;
using System.Collections;

public class DistanceScaler : MonoBehaviour
{
    public GameObject player;

    public float distanceFromPlayer;
    public float scaleFactor;
    public float minScale = 0.1f;
    public float maxScale = 100.0f;
    public float scaleThresholdDistance = 1.0f;

    private Transform haloLight;
    Material mat;
    // Use this for initialization
    void Start()
    {
        mat = new Material(GetComponent<Renderer>().material);
        player = GameObject.Find("LMHeadMountedRig");
        haloLight = transform.Find("HaloLight");
        scaleFactor = 1.008f;
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        GetComponent<Renderer>().material = mat;
    }

    // Update is called once per frame.
    void Update()
    {
        // Once the sphere passes the threshold distance it is scaled.
        float currentDistance = Vector3.Distance(transform.position, player.transform.position);
        if (currentDistance > scaleThresholdDistance)
        {
            if (transform.localScale.x >= minScale && transform.localScale.x <= maxScale)
            {
                if (currentDistance > distanceFromPlayer)
                {
                    transform.localScale *= scaleFactor;
                    GetComponent<Rigidbody>().mass *= scaleFactor;
                    haloLight.GetComponent<Light>().range *= scaleFactor;
                    Color color = mat.GetColor("_EmissionColor");
                    mat.SetColor("_EmissionColor", color * 0.93f);
                    GetComponent<Renderer>().material.SetColor("_EmissionColor", color *= 0.93f);
                }
            }
        }
        distanceFromPlayer = currentDistance;
    }
}