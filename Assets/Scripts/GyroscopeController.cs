using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeController : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject CameraParent;

    private void Start()
    {
        //CameraParent = new GameObject("CameraParent");
        //CameraParent.transform.position = Camera.main.transform.position;
        //Camera.main.transform.SetParent(CameraParent.transform);

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;

        }
        Debug.Log("Gyro not enabled");
        return false;
    }
    
    void Update()
    {
        if (gyroEnabled)
        {
            //Camera.main.transform.rotation = ConvertRotation(gyro.attitude);
            Camera.main.transform.Rotate(-gyro.rotationRateUnbiased.x, -gyro.rotationRateUnbiased.y, 0);
            //CameraParent.transform.Rotate(-gyro.rotationRateUnbiased.x, 0, 0);
            //Camera.main.transform.Rotate(0, -gyro.rotationRateUnbiased.y, 0);
        }
    }

    private static Quaternion ConvertRotation(Quaternion quaternion)
    {
        return new Quaternion(quaternion.x, quaternion.y, -quaternion.z, -quaternion.w) * Quaternion.identity;
    }
}
