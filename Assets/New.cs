using UnityEngine;
using System.Collections;

public class New : MonoBehaviour {
    public MovieTexture mainTex;
	// Use this for initialization
	void Start () 
    {
        gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", mainTex);
        mainTex.Play();
        mainTex.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
