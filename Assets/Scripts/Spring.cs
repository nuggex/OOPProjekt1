using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    public GameObject UpperCube;
    public GameObject LowerCube;
    public GameObject ConnectingString;
    private float PlayerWeight;
    public float PlatForm;
    private float PlayerVelocity;
    private bool WhereIsKyle;
    public float a;
    public float SpringF;
    public float Y;
    public float startY;
    public float deltaY;
    private float BulletMass;
    // Start is called before the first frame update
    void Start()
    {
        WhereIsKyle = false;
        BulletMass = 0;
        startY = transform.position.y;
        SpringF = 100.0f;
        a = 9.82f;
        GameManager.instance.PlatformMass = 50.0f;
        Debug.Log("PlatForm Mass: " +  GameManager.instance.PlatformMass);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Fr;
        float Ar;
        float Fg;
        float F;
        // Debug.Log(GameManager.instance.PlatformMass);
        deltaY = startY - transform.position.y; // How far the GameManager.instance.PlatformMass has moved from origin
        Fg = GameManager.instance.PlatformMass * a; // Gravitation of the platform
        F = SpringF * deltaY; // To push of the spring against gravitation
        Fr = F - Fg; // The resulting force of the spring vs gravity
        Ar = Fr / GameManager.instance.PlatformMass; // Get the acceleration from force

        //Debug.Log("deltaY: " + deltaY);
        //Debug.Log("resulting force: " + Fr + " Ar: " + Ar);

        Vector3 newpos = new Vector3(0, Ar, 0);

        transform.Translate(newpos * (Time.deltaTime));

    }

    public void Activate()
    {
        WhereIsKyle = true;

    }
    public void Disable()
    {
        WhereIsKyle = false;
    }



    private void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.contacts[0].thisCollider;
        // Debug.Log(myCollider);
        if (collision.collider.name == "RobotKyle")
        {
            Debug.Log("Kyle is on le platförm");
            PlayerWeight = GameManager.instance.GetWeight();
            PlayerVelocity = GameManager.instance.GetVelocity();
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        // F = m * a 
        if (collision.collider.name == "RobotKyle")
        {
            //Debug.Log("Kyle is on platform");
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        // reset values 

    }
}
