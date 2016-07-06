using UnityEngine;
using System.Collections.Generic;

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
            List<ClothSphereColliderPair> clothColliders = new List<ClothSphereColliderPair>(cloth.GetComponent<Cloth>().sphereColliders);

            // Remove the cloth sphere collider pair related to this sphere's collider.
            int index = 0;
            bool notRemoved = true;
            while (notRemoved)
            {
                if (clothColliders[index].first == gameObject.GetComponent<SphereCollider>())
                {
                    clothColliders.RemoveAt(index);
                    notRemoved = false;
                }
                index++;
            }

            cloth.GetComponent<Cloth>().sphereColliders = clothColliders.ToArray();
            Debug.Log("Removed Index: " + index);

            Destroy(gameObject);
        }
        //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
    }
}
