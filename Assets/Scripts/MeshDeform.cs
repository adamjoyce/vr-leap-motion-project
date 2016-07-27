using UnityEngine;
using System.Collections;

public class MeshDeform : MonoBehaviour
{
    float deformscale = 0.001f;
    Vector3[] meshVertices;
    public float speed;
    public float scale;
    public float varianceX, varianceY, varianceZ;
    float timeX, timeY, timeZ;
    float defScalefromGO;
    Perlin noise;

    public bool isBeingTargeted;

    // Use this for initialization
    void Start ()
    {
        noise = new Perlin();
        meshVertices = gameObject.GetComponent<MeshFilter>().mesh.vertices;
        defScalefromGO = gameObject.GetComponent<Transform>().localScale.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isBeingTargeted)
        {
            if (defScalefromGO < 0.5f)
            {
                defScalefromGO += deformscale;
                scale = defScalefromGO;
            }
        }

        else
        {
            if (defScalefromGO > 0.0f)
            {
                defScalefromGO -= deformscale;
                scale = defScalefromGO;
            }
            if (defScalefromGO <= 0.0f)
            {
                scale = 0.0f;
            }
        }

        Vector3[] verts = new Vector3[meshVertices.Length];
        timeX += Time.time * speed + varianceX;
        timeY += Time.time * speed + varianceY;
        timeZ += Time.time * speed + varianceZ;

        for (int i = 0; i < verts.Length; i++)
        {
            Vector3 vert = meshVertices[i];
            vert.x += noise.Noise(timeX + vert.x, timeX + vert.y, timeX + vert.z) * scale;
            vert.y += noise.Noise(timeY + vert.x, timeY + vert.y, timeY + vert.z) * scale;
            vert.z += noise.Noise(timeZ + vert.x, timeZ + vert.y, timeZ + vert.z) * scale;
            verts[i] = vert;
        }
        gameObject.GetComponent<MeshFilter>().mesh.vertices = verts;
    }
}
