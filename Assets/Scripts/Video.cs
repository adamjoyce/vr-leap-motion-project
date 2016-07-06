using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour
{
    public MovieTexture movTexture;
    public MovieTexture movTexture2;
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
        GetComponent<Renderer>().material.SetTexture("_SecondaryTex", movTexture2);
        movTexture2.Play();
    }
}