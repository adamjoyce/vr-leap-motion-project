// THIS IS THE WORST CODE I HAVE EVER WRITTEN IN MY LIFE. IT NEEDS TO BE KILLED. MUCH LUV, ADAM.

using UnityEngine;
using System.Collections;

public class TempoController : MonoBehaviour
{
    public AudioClip audioClip;

    public float beatTime = 0.0f;
    private float initialBeatTime = 0.0f;
    private float endBeatTime = 0.0f;
    private bool firstBeat = true;
    public bool secondBeat = false;

    private GameObject beatObject;

    // 
    void Start()
    {
        beatObject = GameObject.Find("Beat");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.gameObject.tag == "TempoCube")
            {
                if (firstBeat)
                {
                    // Create audiosource.
                    AudioSource audio = gameObject.AddComponent<AudioSource>();
                    audio.clip = audioClip;
                    audio.Play();
                    initialBeatTime = Time.time;
                    StartCoroutine(DestroyAfterAudioFinished(audio));
                    firstBeat = false;
                }
                else
                {
                    // Create audiosource.
                    AudioSource audio = gameObject.AddComponent<AudioSource>();
                    audio.clip = audioClip;
                    audio.Play();
                    endBeatTime = Time.time;
                    StartCoroutine(DestroyAfterAudioFinished(audio));
                    secondBeat = true;
                }

                if (secondBeat)
                {
                    beatTime = calculateBeatTime(initialBeatTime, endBeatTime);
                    Debug.Log(beatTime);
                }
            }
        }
    }

    //
    private float calculateBeatTime(float startTime, float endTime)
    {
        float time = endTime - startTime;
        return time;
    }

    //
    private IEnumerator DestroyAfterAudioFinished(AudioSource audio)
    {
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(audio);
    }
}