using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour {
    public float scrollSpeed = 1.0f;
    float offset;
    float rotate;
    AudioSource aSource;
	// Use this for initialization
	void Start () {
        aSource = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        updateScrollSpeed();
        offset += (Time.deltaTime * scrollSpeed) / 10.0f;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(offset, 0));
	
	}

    void updateScrollSpeed()
    {
        scrollSpeed = aSource.pitch;
    }
}
