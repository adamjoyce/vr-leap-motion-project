using UnityEngine;
using System.Collections;

public class MorphController : MonoBehaviour
{
    SkinnedMeshRenderer morphMesh;
    float minMorphValue = 1.0f;
    float maxMorphValue = 100.0f;
    float time = 0.0f;

    // Use this for initialization
    void Start()
    {
        morphMesh = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        morphMesh.SetBlendShapeWeight(0, Mathf.Lerp(minMorphValue, maxMorphValue, time));
        morphMesh.SetBlendShapeWeight(1, Mathf.Lerp(minMorphValue, maxMorphValue, time));
        morphMesh.SetBlendShapeWeight(2, Mathf.Lerp(minMorphValue, maxMorphValue, time));
        time += 0.5f * Time.deltaTime;

        if (time > 1.0f)
        {
            float temp = minMorphValue;
            minMorphValue = maxMorphValue;
            maxMorphValue = temp;
            time = 0.0f;
        }
    }
}