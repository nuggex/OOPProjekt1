using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 7F;
    public float sensitivityY = 5f;
    float minimumX = -360F;
    float maximumX = 360F;
    float minimumY = -60F;
    float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;
    void FixedUpdate()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            //Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, -Vector3.right);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.forward);
            transform.localRotation = originalRotation * yQuaternion;
            transform.parent.parent.parent.parent.rotation = originalRotation * Quaternion.AngleAxis(rotationX, Vector3.up);
        }
        /*else if (axes == RotationAxes.MouseX)
        {
            Debug.Log("X");
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, -Vector3.right);
            transform.localRotation = originalRotation * xQuaternion;
        }*/
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.forward);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
    void Start()
    {
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }



}
