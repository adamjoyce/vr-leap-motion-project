using UnityEngine;
using System.Collections;

public class DestroyPrimitive : MonoBehaviour
{

    public GameObject player;
    public GameObject cloth;

    public float destroyDistance = 100.0f;

    void Start()
    {
        player = GameObject.Find("LMHeadMountedRig");
        cloth = GameObject.Find("Cloth");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > destroyDistance)
        {
            Destroy(gameObject);

            // Remove the sphere collider from the cloth component.
        }
        //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
    }
}
