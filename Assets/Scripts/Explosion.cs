using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public GameObject explosionPrefab;
    GameObject explosionGameObj;
    bool pos;
	// Use this for initialization
	void Start ()
    {
        explosionGameObj = (GameObject)Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        pos = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float exscale = explosionGameObj.transform.localScale.x;
        if (pos)
        {
            exscale += 1.0f;
            explosionGameObj.GetComponent<Transform>().localScale = new Vector3(exscale, exscale, exscale);
            if (exscale > 20.0f)
            {
                pos = !pos;
            }
        }
        else
        {
            exscale -= 1.0f;
            explosionGameObj.GetComponent<Transform>().localScale = new Vector3(exscale, exscale, exscale);
            if (exscale < 0.0f)
            {
                Destroy(explosionGameObj);
            }
        }
    }
}
