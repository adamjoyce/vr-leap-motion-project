using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour
{
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<Renderer>().material.SetTexture("_Emission", movTexture);
        movTexture.Play();
        movTexture.loop = true;
    }
}