using UnityEngine;
using System.Collections;

public class NewScrollScript : MonoBehaviour {
    public bool texture;
    public bool normal;
    public bool displacement;
    public bool crossFade;
    bool hasAudioSource;
    bool changeTexture;
    bool pos = true;

    float height;
    float speed;
    float texOffset;
    float normalOffset;
    float displacementOffset;
    float fade;

    float minHeight = 7.0f;
    float maxHeight = 75.0f;
    float scaleFactor = 50.0f;
    public float blendSpeed = 0.5f;

    AudioSource aSource;
    GameObject mainSphere;
    Material mat;

	// Use this for initialization
	void Start () 
    {
        mat = gameObject.GetComponent<Renderer>().material;
        aSource = FindObjectOfType<AudioSource>();
        if(gameObject.name == "Cloth")
        {
            mainSphere = GameObject.Find("CollisionSphere");
            height = mainSphere.transform.position.y;
            hasAudioSource = true;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        speed = aSource.pitch;
	    if(hasAudioSource)
        {
            heightUpdate();
            materialUpdate();
        }

        else
        {
            materialUpdate();
        }
	}

    void heightUpdate()
    {
        if(height > 7.0f && height < 75.0f)
        {
            height = aSource.pitch * scaleFactor;
            if (height <= 7.0f)
                height = 7.5f;
            else if (height >= 75.0f)
                height = 74.5f;
        }
        mainSphere.transform.position = new Vector3(0, height, 0);
    }

    void materialUpdate()
    {
        texOffset = normalOffset = displacementOffset += (Time.deltaTime * speed) / 10.0f; 

        if (texOffset >= 1.0f)
            texOffset = 0.0f;

        if (normalOffset >= 1.0f)
            normalOffset = 0.0f;

        if (displacementOffset >= 1.0f)
            displacementOffset = 0.0f;

        if(texture)
        {
            mat.SetTextureOffset("_MainTex", new Vector2(texOffset, 0));
            mat.SetTextureOffset("_SecondaryTex", new Vector2(texOffset, 0));
        }

        if(normal)
        {
            mat.SetTextureOffset("_NormalTex", new Vector2(normalOffset, 0));
            mat.SetTextureOffset("_SecondaryNormal", new Vector2(normalOffset, 0));
        }

        if(displacement)
        {
            mat.SetTextureOffset("_DispTex", new Vector2(displacementOffset, 0));
            mat.SetTextureOffset("_SecondaryDisp", new Vector2(displacementOffset, 0));
        }

        if(crossFade)
        {
            fade += Time.deltaTime * blendSpeed;
            mat.SetFloat("_Blend", fade);
            if (pos)
            {
                if (fade >= 1.0f)
                {
                    blendSpeed = -blendSpeed;
                    pos = !pos;
                }
            }
            else if(!pos)
            {
                if (fade <= 0.0f)
                {
                    blendSpeed = -blendSpeed;
                    pos = !pos;
                }
            }

        }
    }
}
