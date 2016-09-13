using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour
{
    public MovieTexture movTexture;
    public MovieTexture secMovTex;
    void Start()
    {
        GetComponent<Renderer>().material.SetTexture("_Emission", movTexture);
        movTexture.Play();
        movTexture.loop = true;
        GetComponent<Renderer>().material.SetTexture("_EmissionSecond", secMovTex);
        secMovTex.Play();
        secMovTex.loop = true;
    }
}