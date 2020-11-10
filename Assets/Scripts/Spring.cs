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
    public float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        SpringF = 100.0f;
        a = 9.82f;
        WhereIsKyle = false;
        PlatForm = 100.0f;
        Y = (PlatForm * a) / SpringF;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Fr;
        float Ar;

        deltaY = Y + (Y-LowerCube.transform.position.y);
        float Fg = PlatForm * a;
        float F = deltaY * SpringF;
        Fr = F - Fg;
        Ar = Fr / PlatForm;
        float Ar2 = Fr / a;

        Debug.Log("AR " + Ar);
        Debug.Log("AR2 " + Ar2);

        Vector3 newpos = new Vector3(0, (this.transform.position.y + Ar), 0);
        Vector3 newpos2 = new Vector3(0, (this.transform.position.y + Ar2), 0);

        Debug.Log(newpos);
        Debug.Log(newpos2);

        //LowerCube.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y + Ar )* Time.deltaTime , this.transform.position.z);
        LowerCube.transform.Translate(newpos * (Time.deltaTime),Space.World);

        //Vector3 CurrentPosition = LowerCube.transform.position;
        //float CurrentVelocity = LowerCube.transform.position.magnitude;
        //Vector3 NextPosition = new Vector3(0, (LowerCube.transform.position.y) + (Ar * Time.deltaTime * 0.05f), 0);
        //LowerCube.transform.localPosition += NextPosition;
        //LastY = LowerCube.transform.position.y;

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
        Debug.Log(myCollider);
        if (collision.collider.name == "RobotKyle")
        {
            PlayerWeight = GameManager.instance.GetWeight();
            PlayerVelocity = GameManager.instance.GetVelocity();
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        // F = m * a 
        if (collision.collider.name == "RobotKyle")
        {
            Debug.Log("Kyle is on platform");
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        // reset values 

    }
}
