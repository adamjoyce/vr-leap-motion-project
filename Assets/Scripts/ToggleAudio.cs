using UnityEngine;
using System.Collections;
using Leap.Unity;

public class ToggleAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public Material deselected;
    public Material selected;

    // Use this for initialization.
    void Start()
    {
        if (!audioSource)
        {
            audioSource = GetComponentInChildren<AudioSource>();
        }
        GetComponent<Renderer>().material = selected;
    }

    //
    private void OnTriggerEnter(Collider other)
    {
        if (IsMiddleFinger(other))
        {
            if (audioSource.volume != 0.0f)
            {
                audioSource.volume = 0.0f;
                GetComponent<Renderer>().material = deselected;
            }
            else
            {
                audioSource.volume = 1.0f;
                GetComponent<Renderer>().material = selected;
            }
        }
    }

    //
    private bool IsMiddleFinger(Collider other)
    {
        if (other.transform.parent.name == "middle")
            return true;
        else
            return false;
    }
}
