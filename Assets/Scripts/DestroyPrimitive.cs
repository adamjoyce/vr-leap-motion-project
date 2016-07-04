using UnityEngine;
using System.Collections;

public class DestroyPrimitive : MonoBehaviour {

    public GameObject deathSphere;

    void Start() {
        deathSphere = GameObject.Find("DeathSphere");
    }

    void Update() {
        destroyOnRadius();
    }

    //
    private void destroyOnRadius() {
        if (Vector3.Distance(transform.position, deathSphere.transform.position) > deathSphere.GetComponent<SphereCollider>().radius) {
            Destroy(gameObject);
        }
    }
}
