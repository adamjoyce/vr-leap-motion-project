using UnityEngine;
using System.Collections;

public class BubbleEmission : MonoBehaviour {
    Renderer bubbleRend;
    Material bubbleMat;
    Color emissionColor;
    public float emissionStrength;
	// Use this for initialization
	void Start () 
    {
        bubbleRend = gameObject.GetComponent<Renderer>();
        bubbleMat = bubbleRend.material;
        emissionColor = new Color(0.14f,0.89f,1.0f);

        emissionStrength = 17.6f;
        bubbleMat.SetColor("_EmissionColor", emissionColor * emissionStrength);
	}
	
	// Update is called once per frame
	void Update () 
    {
        bubbleMat.SetColor("_EmissionColor", emissionColor * emissionStrength);
        // emission strength set to value of B channel
	}
}
