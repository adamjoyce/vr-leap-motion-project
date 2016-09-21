﻿using UnityEngine;
using VRStandardAssets.Utils;
using System.Collections;

public class SphereInteractiveItemVR : MonoBehaviour
{
    //[SerializeField] private Material m_NormalMaterial;
    //[SerializeField] private Material m_OverMaterial;
    //[SerializeField] private Material m_ClickedMaterial;
    //[SerializeField] private Material m_DoubleClickedMaterial;
    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;
    [SerializeField]
    private Renderer m_Renderer;
    Material sphereMat;
    private Transform haloLight;
    Color color;
    public bool selected;

    private void Awake()
    {
        //m_Renderer.material = m_NormalMaterial;
        //haloLight = transform.Find("HaloLight");
        //sphereMat = gameObject.GetComponent<Renderer>().material;
        //emissiColor = new Color(2.5f, 15.7f, 17.6f);
    }

    private void Start()
    {
        //haloLight = transform.Find("HaloLight");
        color = GetComponent<Renderer>().material.GetColor("_EmissionColor");
        float highestValue;
        if (color.r > color.g)
            highestValue = color.r;
        else
            highestValue = color.g;
        if (color.g > color.b)
            highestValue = color.g;
        else
            highestValue = color.b;
        color = new Color(color.r / highestValue, color.g / highestValue, color.b / highestValue);
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        //m_InteractiveItem.OnClick += HandleClick;
        //m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
    }

    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        //m_InteractiveItem.OnClick -= HandleClick;
        //m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }

    //Handle the Over event
    private void HandleOver()
    {
        //Debug.Log("Show over state");
        //m_Renderer.material = m_OverMaterial;
        //haloLight.GetComponent<Light>().enabled = true;
        selected = true;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * 20.0f);
    }

    //Handle the Out event
    private void HandleOut()
    {
        //Debug.Log("Show out state");
        //m_Renderer.material = m_NormalMaterial;
        //haloLight.GetComponent<Light>().enabled = false;
        selected = false;
    }

    //Handle the Click event
    //private void HandleClick() {
    //    Debug.Log("Show click state");
    //    m_Renderer.material = m_ClickedMaterial;
    //}

    //Handle the DoubleClick event
    //private void HandleDoubleClick() {
    //    Debug.Log("Show double click");
    //    m_Renderer.material = m_DoubleClickedMaterial;
    //}

    // Sets the normal material.
    //public void SetNormalMaterial(Material normal) {
    //    //m_NormalMaterial = normal;
    //}

    // Sets the over material.
    //public void SetOverMaterial(Material over) {
    //    m_OverMaterial = over;
    //}

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