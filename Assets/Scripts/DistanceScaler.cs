using UnityEngine;
using System.Collections;

public class DistanceScaler : MonoBehaviour
{
    public GameObject player;

    public float distanceFromPlayer;
    public float scaleFactor;
    public float minScale = 0.05f;
    public float maxScale = 10.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("LMHeadMountedRig");
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
            }
            else if (currentDistance < distanceFromPlayer)
            {
                transform.localScale *= -scaleFactor;
            }
        }
    }
}