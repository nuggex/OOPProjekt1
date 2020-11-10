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
    public float K;
    public float SpringF;
    public float StartPosY;
    public float LastY;
    public float Mass;
    public float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        StartPosY = LowerCube.transform.localPosition.y;
        SpringF = 20.0f;
        K = 9.82f;
        WhereIsKyle = false;
        PlatForm = 100.0f;
        Mass = 50.0f;
        deltaY = (PlatForm * K) / SpringF;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // F = m * a if kyle is on platform // 

        // vel_next_update = vel_current + time_step * acceleration // 
        //  pos_next_update = pos_current + time_step * vel_current
        float Fr;
        //Fr = F - Fk;
        //Fr = K * PlatForm -(-SpringF * LowerCube.transform.localPosition.y);
        deltaY = LowerCube.transform.position.y - LastY;
        float Fg = PlatForm * K;
        float F = deltaY * SpringF;
        Fr = F - Fg;

        Debug.Log("fr " + Fr);


        if (WhereIsKyle)
        {
            PlatForm = 50.0f;
        }

        Vector3 CurrentPosition = LowerCube.transform.position;
        float CurrentVelocity = LowerCube.transform.position.magnitude;
        Vector3 NextPosition = new Vector3(0, (LowerCube.transform.position.y) + (Fr * Time.deltaTime * 0.05f), 0);
        //LowerCube.transform.position = new Vector3(this.transform.position.x, LowerCube.transform.position.magnitude + Time.deltaTime * 10.0f,this.transform.position.z); 
        LowerCube.transform.localPosition += NextPosition;
        LastY = LowerCube.transform.position.y;

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
