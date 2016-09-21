using UnityEngine;
using System.Collections;

public class ToneSelector : MonoBehaviour {
    public AudioClip[] clips;
    public AudioClip selected;
    int counter;
	// Use this for initialization
	void Start () 
    {
        selected = clips[0];
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            counter++;
            if(counter > 4)
            {
                counter = 0;
            }
            selected = clips[counter];
        }
	}
}
