using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour
{

    public float scrollSpeed = 1.0f;
    public float normalOffset;
    float rotate;
    float height;
    AudioSource aSource;
    public GameObject collisionSphere;

    public float minHeight = 7.0f;
    public float maxHeight = 75.0f;
    public float scaleFactor = 50.0f;


    // Use this for initialization
    void Start()
    {
        aSource = FindObjectOfType<AudioSource>();
        collisionSphere = GameObject.Find("CollisionSphere");
        height = collisionSphere.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        updateScrollSpeed();
        normalOffset += (Time.deltaTime * scrollSpeed) / 10.0f;
        if (normalOffset >= 1.0f)
            normalOffset = 0.0f;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_NormalTex", new Vector2(normalOffset, 0));
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryNormal", new Vector2(normalOffset, 0));

    }

    void updateScrollSpeed()
    {
        scrollSpeed = aSource.pitch;

        if (height > 7.0f && height < 75.0f)
        {
            height = aSource.pitch * scaleFactor;
            if (height <= 7.0f)
                height = 7.5f;
            else if (height >= 75.0f)
                height = 74.5f;
        }
        collisionSphere.transform.position = new Vector3(0, height, 0);
    }
}
