using UnityEngine;
using System.Collections;

public class CrossFade : MonoBehaviour 
{
    private Texture newTex;
    private Texture replace;
    private Texture newNormal;
    private Texture replaceNormal;
    private Vector2 newOffset;
    private Vector2 replaceOffset;
    private Vector2 newTiling;
    private Vector2 replaceTiling;

    public float BlendSpeed = 3.0f;
    private bool trigger = false;
    private float fader = 0f;
	// Use this for initialization
	void Start () 
    {
        replace = gameObject.GetComponent<Renderer>().material.GetTexture("_MainTex");
        replaceOffset = gameObject.GetComponent<Renderer>().material.GetTextureOffset("_MainTex");
        replaceTiling = gameObject.GetComponent<Renderer>().material.GetTextureScale("_MainTex");
        replaceNormal = gameObject.GetComponent<Renderer>().material.GetTexture("_BumpMap");
        gameObject.GetComponent<Renderer>().material.SetFloat("_Blend", 0f);
        CrossFadeTo(gameObject.GetComponent<Renderer>().material.GetTexture("_SecondaryTex"), gameObject.GetComponent<Renderer>().material.GetTexture("_SecondaryBumpMap"), gameObject.GetComponent<Renderer>().material.GetTextureOffset("_SecondaryTex"), gameObject.GetComponent<Renderer>().material.GetTextureScale("_SecondaryTex"));
    }
	
	// Update is called once per frame
	void Update () 
    {
	    if(trigger)
        {
            fader += Time.deltaTime * BlendSpeed;
            gameObject.GetComponent<Renderer>().material.SetFloat("_Blend", fader);
            
            if(fader >= 1.0f)
            {
                trigger = false;
                fader = 0f;
                replace = gameObject.GetComponent<Renderer>().material.GetTexture("_MainTex");
                replaceNormal = gameObject.GetComponent<Renderer>().material.GetTexture("_BumpMap");
                replaceOffset = gameObject.GetComponent<Renderer>().material.GetTextureOffset("_MainTex");
                replaceTiling = gameObject.GetComponent<Renderer>().material.GetTextureScale("_MainTex");
                gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", newTex);
                gameObject.GetComponent<Renderer>().material.SetTexture("_BumpMap", newNormal);
                gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", newOffset);
                gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", newTiling);
                gameObject.GetComponent<Renderer>().material.SetFloat("_Blend", 0f);
                CrossFadeTo(replace, replaceNormal, replaceOffset, replaceTiling);
            }
        }
	}

    public void CrossFadeTo(Texture curTexture, Texture normalTexture, Vector2 offset, Vector2 tiling)
    {
        newOffset = offset;
        newNormal = normalTexture;
        newTiling = tiling;
        newTex = curTexture;
        gameObject.GetComponent<Renderer>().material.SetTexture("_SecondaryTex", curTexture);
        gameObject.GetComponent<Renderer>().material.SetTexture("_SecondaryBumpMap", newNormal);
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_SecondaryTex", newOffset);
        gameObject.GetComponent<Renderer>().material.SetTextureScale("_SecondaryTex", newTiling);
        trigger = true;
    }
}
