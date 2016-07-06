using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public GameObject deathSphere;

    void Start() {
        deathSphere = GameObject.Find("DeathSphere");
    }

    void Update() {
        destroyOnRadius();
    }

    //
    private void destroyOnRadius() {
        if (Vector3.Distance(deathSphere.transform.position, transform.position) > deathSphere.GetComponent<SphereCollider>().radius) {
            Destroy(gameObject);
        }
    }
}
