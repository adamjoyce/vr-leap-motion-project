using UnityEngine;
using System.Collections;

public class GizmoViewer : MonoBehaviour {
    PopBubble popBub;
    float radius;
	// Use this for initialization
	void Start () 
    {
        popBub = FindObjectOfType<PopBubble>();
        radius = popBub.explosionRadius;
	}
	
	// Update is called once per frame
	void Update () 
    {
        radius = popBub.explosionRadius;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}
