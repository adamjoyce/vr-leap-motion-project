using UnityEngine;
using System.Collections;

public class ToggleCube : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.gameObject.tag == "ToneCube")
            {
                // Toggle audio on cube.
                AudioSource audio = hit.transform.gameObject.GetComponent<AudioSource>();
                if (audio.enabled)
                    audio.enabled = false;
                else
                    audio.enabled = true;
            }
        }
    }
}