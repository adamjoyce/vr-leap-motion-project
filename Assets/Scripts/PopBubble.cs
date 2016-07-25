using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class PopBubble : MonoBehaviour
{
    public LeapProvider provider;
    public Camera mainCamera;
    public float minTriggerDistance = 0.03f;

    private List<Hand> hands;

    void Start()
    {
        if (!provider)
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        if (!mainCamera)
            mainCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();

        hands = new List<Hand>();
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
                    if (HandGunShape(hands[i]))
                    {
                        Ray ray = new Ray(mainCamera.transform.position, (hands[i].Fingers[1].TipPosition.ToVector3() - mainCamera.transform.position));
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.tag == "BubbleSphere" && !hit.collider.gameObject.GetComponent<DestroyPrimitive>().beingDestroyed)
                            {
                                // Play explode animation and destroy bubble.
                                StartCoroutine(DestroyAfterAudioFinished(hit.collider.gameObject));
                                //Debug.Log("BANG!");
                            }
                        }
                        Debug.DrawRay(ray.origin, ray.direction, Color.red);
                    }
                }
            }
        }
    }

    // Returns true if a hand is in the gun shape.
    private bool HandGunShape(Hand hand)
    {
        float triggerDistance = Vector3.Distance(hand.Fingers[0].TipPosition.ToVector3(), hand.Fingers[1].Bone(Bone.BoneType.TYPE_PROXIMAL).Center.ToVector3());
        Debug.Log(triggerDistance);
        if (hand.Fingers[1].IsExtended && !hand.Fingers[2].IsExtended && !hand.Fingers[3].IsExtended && !hand.Fingers[4].IsExtended && triggerDistance < minTriggerDistance)
        {
            return true;
        }
        return false;
    }

    //
    private IEnumerator DestroyAfterAudioFinished(GameObject bubbleSphere)
    {
        bubbleSphere.GetComponent<AudioSource>().Play();
        bubbleSphere.GetComponent<MeshRenderer>().enabled = false;
        bubbleSphere.GetComponent<DestroyPrimitive>().beingDestroyed = true;
        yield return new WaitForSeconds(bubbleSphere.GetComponent<AudioSource>().clip.length);
        bubbleSphere.GetComponent<DestroyPrimitive>().DestroySphere();
    }
}