using UnityEngine;
using VRStandardAssets.Utils;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class LightInteractiveItem : MonoBehaviour
{

    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;
    [SerializeField]
    private Renderer m_Renderer;
    public Material mat;
    public Material overMat;
    List<Hand> hands;
    LeapProvider provider;
    Behaviour halo;
    public bool grab;
    public bool height;
    float leftHandHeight;
    // Use this for initialization
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>();
    }

    void Update()
    {
        hands = provider.CurrentFrame.Hands;
        if (m_InteractiveItem.IsOver)
        {
            //Debug.Log("Hitting: " + m_InteractiveItem.gameObject.name);
            float lightIntensity = GetComponent<Light>().intensity;
            for (int i = 0; i < hands.Count; i++)
            {
                if(grab)
                {
                    if (hands[i].IsLeft)
                    {
                        float strength = 1 - hands[i].GrabStrength;
                        GetComponent<Light>().intensity = strength;
                    }
                }
                else if(height)
                {
                    if(hands[i].IsLeft)
                    {
                        if(leftHandHeight > hands[i].PalmPosition.y + 0.001f)
                        {
                            lightIntensity -= 0.1f;
                            GetComponent<Light>().intensity = lightIntensity;
                        }
                        else if (leftHandHeight < hands[i].PalmPosition.y - 0.001f)
                        {
                            lightIntensity += 0.1f;
                            GetComponent<Light>().intensity = lightIntensity;
                        }
                    }
                    leftHandHeight = hands[i].PalmPosition.y;
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

        halo = (Behaviour)m_InteractiveItem.gameObject.GetComponent("Halo");        
        halo.enabled = true;
        //m_Renderer.material = overMat;
        //float lightIntensity = GetComponent<Light>().intensity;
        //for (int i = 0; i < hands.Count; i++)
        //{
        //    }
        //    if (hands[i].IsLeft)
        //    {
        //        float strength = hands[i].GrabStrength;
        //        GetComponent<Light>().intensity = strength;
        //}

    }

    private void HandleOut()
    {
        //m_Renderer.material = mat;
        halo = (Behaviour)m_InteractiveItem.gameObject.GetComponent("Halo");
        halo.enabled = false;
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