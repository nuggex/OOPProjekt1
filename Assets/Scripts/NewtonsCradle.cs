using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonsCradle : MonoBehaviour
{
    // Start is called before the first frame update

    //public float Velocity;
    public GameObject Bob;
    float Gravity;
    float Angle;
    float AngularAcceleration;
    public float PendulumMass;
    public float ArmLength;
    public float Velocity { get; set; }
    public bool HasCollided { get; set; }
    public bool ThisCollision { get; set; }
    bool firstTime;
    void Start()
    {
        Gravity = 2f;
        ArmLength = Vector3.Distance(gameObject.transform.position, Bob.transform.position);
        Velocity = 0;
        Angle = gameObject.transform.rotation.eulerAngles.z;
        firstTime = true;
        HasCollided = false;
        GameManager.instance.NewtonsBalls.Add(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Get current angle on this update and calculate eulerZ // 
        float eulerZ;
        float EulersToRad = gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        eulerZ = Mathf.Sin(EulersToRad);
        firstTime = false;

        // Calculate angular acceleration // 
        AngularAcceleration = (-1 * Gravity * eulerZ) / ArmLength;

        // Add angular velocity to Acceleration // 
        Velocity += AngularAcceleration;


        // Add velocity to Angle // 
        Angle += Velocity;
        // Rotate with angle // 
        Quaternion rotation = Quaternion.Euler(0, 0, Angle);
        gameObject.transform.rotation = rotation;
        // Add velocity to GameManager // 
        GameManager.instance.PendulumVelocity = Velocity;

    }
}
