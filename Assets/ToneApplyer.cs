using UnityEngine;
using System.Collections;

public class ToneApplyer : MonoBehaviour {
    ToneSelector selector;
	// Use this for initialization
	void Start () 
    {
        selector = FindObjectOfType<ToneSelector>();
        GetComponent<AudioSource>().clip = selector.selected;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
