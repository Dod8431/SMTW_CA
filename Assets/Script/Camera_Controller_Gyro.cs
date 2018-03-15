using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller_Gyro : MonoBehaviour {
    private Gyroscope gyro;
    public bool gyroEnabled = true;
    bool haveGyro;
    Quaternion rot;
    GameObject cameraContainer;
    public float turnSpeed = 4.0f;
    Vector3 mouseOrigin;
    bool isRotating;


    void Start()
    {

        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = this.transform.position;
        transform.SetParent(cameraContainer.transform);
        haveGyro = EnableGyro();

    }
    private bool EnableGyro()
    {

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    void Update()
    {
        if (haveGyro && gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Get mouse origin
                gyroEnabled = false;
                mouseOrigin = Input.mousePosition;
                isRotating = true;
            }
        }

        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }
    }

    public void ButtonGyro()
    {
        gyroEnabled = !gyroEnabled;
    }

}
