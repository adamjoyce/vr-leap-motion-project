using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class PopBubble : MonoBehaviour
{
    public LeapProvider provider;
    public Camera mainCamera;

    public float reloadTriggerDistance = 0.06f;
    public float minTriggerDistance = 0.03f;

    public int explosionPower = 10000;
    public int explosionRadius = 5;

    private List<Hand> hands;
    private bool[] needReload;

    private float triggerDistance = 0.0f;

    void Start()
    {
        if (!provider)
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        if (!mainCamera)
            mainCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();

        hands = new List<Hand>();
        needReload = new bool[2];
    }

    void Update()
    {
        hands = provider.CurrentFrame.Hands;
        if (hands.Count > 0)
        {
            if (!provider.GetComponent<SpawnPrimitives>().sphereAttached)
            {
                for (int i = 0; i < hands.Count; i++)
                {
                    if (HandGunShape(hands[i]) && !needReload[i])
                    {
                        Ray ray = new Ray(mainCamera.transform.position, (hands[i].Fingers[1].TipPosition.ToVector3() - mainCamera.transform.position));
                        RaycastHit hit;
                        
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.tag == "BubbleSphere" && !hit.collider.gameObject.GetComponent<DestroyPrimitive>().beingDestroyed)
                            {
                                GameObject sphere = hit.collider.gameObject;
                                // Play explode animation and destroy bubble.
                                StartCoroutine(DestroyAfterAudioFinished(sphere));
                                //applyExplosionForce(sphere.transform.position, explosionPower);
                                //Debug.Log("BANG!");
                            }
                        }
                        Debug.DrawRay(ray.origin, ray.direction, Color.red);
                        needReload[i] = true;
                        //Debug.Log("TRIGGER PULLED! DISTANCE: " + triggerDistance);
                    }

                    if (triggerDistance >= reloadTriggerDistance)
                    {
                        needReload[i] = false;
                        //Debug.Log("RELOADED! DISTANCE: " + triggerDistance);
                    }
                }
            }
        }
    }

    // Returns true if a hand is in the gun shape.
    private bool HandGunShape(Hand hand)
    {
        triggerDistance = Vector3.Distance(hand.Fingers[0].TipPosition.ToVector3(), hand.Fingers[1].Bone(Bone.BoneType.TYPE_PROXIMAL).Center.ToVector3());
        //Debug.Log(triggerDistance);
        if (hand.Fingers[1].IsExtended && !hand.Fingers[2].IsExtended && !hand.Fingers[3].IsExtended && !hand.Fingers[4].IsExtended && triggerDistance < minTriggerDistance)
        {
            return true;
        }
        return false;
    }

    //
    private IEnumerator DestroyAfterAudioFinished(GameObject bubbleSphere)
    {
        Light[] lights = bubbleSphere.GetComponentsInChildren<Light>();
        for (int i = 0; i < lights.Length; i++)
            lights[i].enabled = false;

        bubbleSphere.GetComponent<AudioSource>().Play();
        bubbleSphere.GetComponent<MeshRenderer>().enabled = false;
        Transform[] trans = bubbleSphere.GetComponentsInChildren<Transform>();
        foreach (Transform t in trans)
            if (t.tag == "Flare")
                t.GetComponent<SpriteRenderer>().enabled = false;
        bubbleSphere.GetComponent<DestroyPrimitive>().beingDestroyed = true;
        bubbleSphere.GetComponent<Explosion>().enabled = true;
        
        applyExplosionForce(bubbleSphere);


        yield return new WaitForSeconds(bubbleSphere.GetComponent<AudioSource>().clip.length);
        if (bubbleSphere != null)
            bubbleSphere.GetComponent<DestroyPrimitive>().DestroySphere();
    }

    //
    public void applyExplosionForce(GameObject sphere)
    {
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            //if (hit.tag == "BubbleSphere" && hit.GetComponent<Collider>() != sphere.GetComponent<SphereCollider>())
            if (hit.tag == "BubbleSphere")
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    float distance = Vector3.Distance(sphere.transform.position, hit.transform.position);
                    float powerScaler = -((distance - explosionRadius) / (explosionRadius - 0));
                    rb.AddExplosionForce(explosionPower * powerScaler, sphere.transform.position, explosionRadius * sphere.transform.localScale.x);
                    Debug.Log(explosionRadius);
                }
            }
        }

        //List<Collider> colliders = sphere.GetComponentInChildren<TriggerZone>().collidersInTriggerZone;
        //float radius = sphere.transform.localScale.x * sphere.GetComponentInChildren<SphereCollider>().radius;
        //Debug.Log(radius);
        //for (int i = 0; i < colliders.Count; i++)
        //{
        //    if (colliders[i] != null)
        //    {
        //        Rigidbody rb = colliders[i].gameObject.GetComponent<Rigidbody>();
        //        if (rb != null)
        //            rb.AddExplosionForce(explosionPower, sphere.transform.position, radius);
        //    }
        //    else
        //    {
        //        continue;
        //    }
        //}
    }
}