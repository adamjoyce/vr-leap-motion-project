// THIS IS THE WORST CODE I HAVE EVER WRITTEN IN MY LIFE. IT NEEDS TO BE KILLED. MUCH LUV, ADAM.

using UnityEngine;
using System.Collections;

public class BeatTempo : MonoBehaviour
{
    public AudioClip audioClip;
    private GameObject tempoController;
    private bool firstBeat = true;

    // Use this for initialization
    void Start()
    {
        tempoController = GameObject.Find("Tempo");
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoController.GetComponent<TempoController>().secondBeat && firstBeat)
        {
            // Add audiosource.
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.clip = audioClip;
            audio.Play();
            firstBeat = false;
        }
        else if (!firstBeat)
        {
            StartCoroutine(TimeInterval(tempoController.GetComponent<TempoController>().beatTime));
        }
    }

    private IEnumerator TimeInterval(float time)
    {
        yield return new WaitForSeconds(time);
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = audioClip;
        audio.Play();
    }
}