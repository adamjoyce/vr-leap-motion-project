using UnityEngine;
using System.Collections;

public class DistanceScaler : MonoBehaviour
{
    public GameObject player;

    public float distanceFromPlayer;
    public float scaleFactor;
    public float minScale = 0.1f;
    public float maxScale = 100.0f;
    public float startScalingDistance = 1.0f;

    private Transform haloLight;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("LMHeadMountedRig");
        haloLight = transform.Find("HaloLight");
        scaleFactor = 1.008f;
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    // Update is called once per frame.
    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, player.transform.position);
        if (currentDistance > startScalingDistance)
        {
            if (transform.localScale.x >= minScale && transform.localScale.x <= maxScale)
            {
                if (currentDistance > distanceFromPlayer)
                {
                    transform.localScale *= scaleFactor;
                    GetComponent<Rigidbody>().mass *= scaleFactor;
                    haloLight.GetComponent<Light>().range *= scaleFactor;
                }
            }
        }
        distanceFromPlayer = currentDistance;
    }
}