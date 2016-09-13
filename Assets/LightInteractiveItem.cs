using UnityEngine;
using VRStandardAssets.Utils;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class LightInteractiveItem : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private Renderer m_Renderer;
    public Material mat;
    public Material overMat;
    List<Hand> hands;
    LeapProvider provider;
	// Use this for initialization
	void Start () 
    {
        provider = FindObjectOfType<LeapProvider>();
	}

    void Update()
    {
        hands = provider.CurrentFrame.Hands;
        if(m_InteractiveItem.IsOver)
        {
            float lightIntensity = GetComponent<Light>().intensity;
            for (int i = 0; i < hands.Count; i++)
            {
                if (hands[i].IsLeft)
                {
                    float strength = 1 - hands[i].GrabStrength;
                    GetComponent<Light>().intensity = strength;
                }
            }
        }
    }

    private void OnEnable()
    {
        
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
    }

    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
    }

    private void HandleOver()
    {
        
        m_Renderer.material = overMat;
        //float lightIntensity = GetComponent<Light>().intensity;
        //for (int i = 0; i < hands.Count; i++)
        //{
        //    if (hands[i].IsLeft)
        //    {
        //        float strength = hands[i].GrabStrength;
        //        GetComponent<Light>().intensity = strength;
        //    }
        //}
        
    }

    private void HandleOut()
    {
        m_Renderer.material = mat;
    }

    // Sets the VR interactive item property.
    public void SetInterativeItem(VRInteractiveItem iteractiveItem)
    {
        m_InteractiveItem = iteractiveItem;
    }

    // Sets the object's renderer.
    public void SetRenderer(Renderer renderer)
    {
        m_Renderer = renderer;
    }
}
