using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToneSelector : MonoBehaviour {
    public AudioClip[] clips;
    public AudioClip selected;
    [SerializeField]
    MeshRenderer pinchRenderer;
    int counter;
    bool pinched;
    public Text text;
	// Use this for initialization
	void Start () 
    {
        selected = clips[0];
        text.text = clips[counter].name;
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
            text.text = clips[counter].name;
        }

        if(pinchRenderer.enabled == true)
        {
            pinched = true;
            
        }

        if(pinched)
        {
            if(pinchRenderer.enabled == false)
            {
                counter++;
                if (counter > 4)
                {
                    counter = 0;
                }
                selected = clips[counter];
                text.text = clips[counter].name;
                pinched = false;
            }
        }
	}
}
