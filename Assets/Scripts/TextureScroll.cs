using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour {

    public float scrollSpeed = 1.0f;
    float offset;
    float rotate;
    float height;
    AudioSource aSource;
    public GameObject collisionSphere;

	// Use this for initialization
	void Start () {
        aSource = FindObjectOfType<AudioSource>();
        collisionSphere = GameObject.Find("CollisionSphere");
        height = collisionSphere.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        updateScrollSpeed();
        offset += (Time.deltaTime * scrollSpeed) / 5.0f;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_DetailAlbedoMap", new Vector2(offset, 0));
	
	}

    void updateScrollSpeed()
    {
        scrollSpeed = aSource.pitch;
        if (height > 7.0f && height < 75.0f)
            height = aSource.pitch * 50.0f;
        else if (height <= 7.0f)
            height = 7.5f;
        else if (height >= 75.0f)
            height = 74.5f;
        collisionSphere.transform.position = new Vector3(0, height, 0);
    }
}
