using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class RaycastToCube : MonoBehaviour
{
    public GameObject[] gos;
    LeapProvider provider;
    List<Hand> hands;
    public Material defaultMat;
    public Material mat;
    float lightIntensity;
    // Use this for initialization
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        hands = provider.CurrentFrame.Hands;
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 5, Color.blue, 1);
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = mat;
            Debug.Log("Looking at: " + hit.collider.gameObject.name);
            lightIntensity = hit.collider.gameObject.GetComponent<Light>().intensity;
            for (int i = 0; i < hands.Count; i++)
            {
                if (hands[i].IsLeft)
                {
                    float strength = 1 - hands[i].GrabStrength;
                    hit.collider.gameObject.GetComponent<Light>().intensity = strength;
                }

                if (hands[i].IsLeft)
                {

                }
            }
        }
        else
        {
            foreach (GameObject go in gos)
            {
                go.GetComponent<Renderer>().material = defaultMat;
            }
        }
    }
}
