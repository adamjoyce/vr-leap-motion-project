using UnityEngine;
using System.Collections;

public class ToneSelector : MonoBehaviour {
    public AudioClip[] clips;
	// Use this for initialization
	void Start () 
    {
        GetComponent<AudioSource>().clip = clips[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
