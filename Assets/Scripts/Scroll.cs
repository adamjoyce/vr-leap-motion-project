using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    float scrollamount;
    public float speedOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        scrollamount += (Time.deltaTime * 0.5f) / speedOffset;
        if (scrollamount >= 1.0f)
            scrollamount = 0.0f;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -scrollamount));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_DispTex", new Vector2(0, -scrollamount));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_NormalMap", new Vector2(0, -scrollamount));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryTex", new Vector2(0, -scrollamount));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryDisp", new Vector2(0, -scrollamount));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryNormal", new Vector2(0, -scrollamount));
	
	}
}
