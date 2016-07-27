using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

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
    float normalOffset1;
    float normalOffset2;
    float displacementOffset;
    float fade;

    float minHeight = 7.0f;
    float maxHeight = 75.0f;
    float scaleFactor = 50.0f;
    public float blendSpeed = 0.5f;

    public float minOffsetSpeed1;
    public float minOffsetSpeed2;
    public float maxOffsetSpeed1;
    public float maxOffsetSpeed2;
    
    AudioSource aSource;
    AudioReverbZone aReverbZone;
    GameObject mainSphere;
    Material mat;

    LeapProvider provider;
    MusicController MC;

	// Use this for initialization
	void Start () 
    {
        mat = gameObject.GetComponent<Renderer>().material;
        aSource = FindObjectOfType<AudioSource>();
        aReverbZone = FindObjectOfType<AudioReverbZone>();
        provider = FindObjectOfType<LeapProvider>();
        MC = FindObjectOfType<MusicController>();
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
        float offsetScale1 = (maxOffsetSpeed1 - minOffsetSpeed1) / (MC.pitchMax - MC.pitchMin);
        float offsetScale2 = (maxOffsetSpeed2 - minOffsetSpeed2) / (MC.pitchMax - MC.pitchMin);
        float smoothnessValue = aReverbZone.reverb * 0.0005f;
        fade = MC.texFade;
        speed = aSource.pitch;
        texOffset = displacementOffset += (Time.deltaTime * speed) / 10.0f;

        normalOffset1 += (Time.deltaTime * (MC.texChange * offsetScale1)) / 10.0f;
        normalOffset2 += (Time.deltaTime * (aSource.pitch * offsetScale2)) / 10.0f;

        mat.SetFloat("_Glossiness", smoothnessValue);

        if (texOffset >= 1.0f)
            texOffset = 0.0f;

        if (normalOffset2 >= 5.0f)
            normalOffset2 = 0.0f;

        if (displacementOffset >= 1.0f)
            displacementOffset = 0.0f;

        if(texture)
        {
            mat.SetTextureOffset("_MainTex", new Vector2(texOffset, 0));
            mat.SetTextureOffset("_SecondaryTex", new Vector2(texOffset, 0));
        }

        if(normal)
        {
            mat.SetTextureOffset("_NormalTex", new Vector2(normalOffset1, 0));
            mat.SetTextureOffset("_SecondaryNormal", new Vector2(normalOffset2, 0));
        }

        if(displacement)
        {
            mat.SetTextureOffset("_DispTex", new Vector2(displacementOffset, 0));
            mat.SetTextureOffset("_SecondaryDisp", new Vector2(displacementOffset, 0));
        }

        if(crossFade)
        {
            //fade += Time.deltaTime * blendSpeed;
            mat.SetFloat("_Blend", fade);
            //if (pos)
            //{
            //    if (fade >= 1.0f)
            //    {
            //        blendSpeed = -blendSpeed;
            //        pos = !pos;
            //    }
            //}
            //else if(!pos)
            //{
            //    if (fade <= 0.0f)
            //    {
            //        blendSpeed = -blendSpeed;
            //        pos = !pos;
            //    }
            //}

        }
    }
}
