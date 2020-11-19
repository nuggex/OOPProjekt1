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
        if (!HasCollided)
        {
            float eulerZ;
            //if (Angle > 180) Angle = Angle - 360;
            float EulersToRad = gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            eulerZ = Mathf.Sin(EulersToRad);
            firstTime = false;

            AngularAcceleration = (-1 * Gravity * eulerZ) / ArmLength;

            //Debug.Log("Rotation Euler Angles:" + gameObject.transform.rotation.eulerAngles.z);
            //Debug.Log("Angular Acceleration: " + AngularAcceleration);

            Velocity += AngularAcceleration;
            //Debug.Log("Velocity: " + Velocity);

        }
        if (HasCollided)
        {
            //Velocity += GameManager.instance.PendulumVelocity;
            HasCollided = false;
        }
        Angle += Velocity;
        // Debug.Log("Velocity: " + Velocity + " Angle: " + Angle);
        Quaternion rotation = Quaternion.Euler(0, 0, Angle);
        gameObject.transform.rotation = rotation;
        GameManager.instance.PendulumVelocity = Velocity;
        //Debug.Log(gameObject.name + " Velocity: " + GameManager.instance.PendulumVelocity);
        //Debug.Log(gameObject.name + " Has Collided " + HasCollided);

        if (ThisCollision && Velocity >0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
