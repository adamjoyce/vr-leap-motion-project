using UnityEngine;
using System.Collections;

public class AlternateCameraControls : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    private float yaw = -142.8781f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            yaw += horizontalSpeed * Input.GetAxis("Mouse X");
            pitch += verticalSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
