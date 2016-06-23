using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour {
    float scrollSpeed = 1.0f;
    float offset;
    float rotate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        offset += (Time.deltaTime * scrollSpeed) / 10.0f;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(offset, 0));
	
	}
}
