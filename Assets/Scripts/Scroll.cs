using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    float scrollamount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        scrollamount += (Time.deltaTime * 0.3f) / 10.0f;
        if (scrollamount >= 1.0f)
            scrollamount = 0.0f;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(scrollamount, 0));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_DispTex", new Vector2(scrollamount, 0));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_NormalMap", new Vector2(scrollamount, 0));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryTex", new Vector2(scrollamount, 0));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryDisp", new Vector2(scrollamount, 0));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryNormal", new Vector2(scrollamount, 0));
	
	}
}
