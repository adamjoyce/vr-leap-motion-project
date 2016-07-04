using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour
{
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    }
}