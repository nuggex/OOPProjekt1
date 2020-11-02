using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class ButterFlyController : MonoBehaviour
{

    //GameObject ButterFly;
    Rigidbody ButterFlyRB;
    Transform LeftWing;
    Transform RightWing;
    float WingDirection;
    float Rotspeed = 4.5f;
    float Health = 100f;
    float speed = 0;
    int randDirectionIterator;
    float flySpeed;
    int wings = 4;
    int MovementLimiter = 200;
    int UppwardsLimit = 175;
    int DirectionLimit = 195;
    Vector3 newHeading;
    // Start is called before the first frame update
    void Start()
    {
        //ButterFly = GameObject.Find("Level/Butterfly");
        //LeftWing = GameObject.Find(transform.name +"/LeftWing").transform;
        //RightWing = GameObject.Find(transform.name + "/RightWing").transform;
        WingDirection = 0;
        ButterFlyRB = gameObject.GetComponent<Rigidbody>();

        LeftWing = gameObject.GetComponentInChildren<Transform>().Find("LeftWing");
        RightWing = gameObject.GetComponentInChildren<Transform>().Find("RightWing");
        transform.Rotate(0, Random.Range(-179, 180), 0);
        speed = Random.Range(2f, 10f);
        newHeading = new Vector3(Random.Range(-60, 60), 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (LeftWing.rotation.eulerAngles.z > 40 || LeftWing.rotation.eulerAngles.z < -45) Rotspeed *= -1;

        this.LeftWing.Rotate(0, 0, Rotspeed);
        this.RightWing.Rotate(0, 0, -Rotspeed);
        //Quaternion currentDirection = gameObject.transform.rotation;
        //gameObject.transform.position += transform.forward * speed;

        randDirectionIterator = Random.Range(0, MovementLimiter);
        flySpeed = Random.Range(75f, 200f);
        if (randDirectionIterator > UppwardsLimit)
        {
            float YForce = Random.Range(10.5f, 20.5f);
            Vector3 flightpattern = new Vector3(0, YForce, 0);
            ButterFlyRB.AddForce(flightpattern * 10f + transform.position, ForceMode.Impulse);
        }

        if (randDirectionIterator > DirectionLimit)
        {
            newHeading = new Vector3(Random.Range(-60, 60), 0, 0);
        }
        //Vector3 FlightDirection = new Vector3(0,0,transform.position.z * flySpeed);
        ButterFlyRB.AddForce(transform.forward * flySpeed, ForceMode.Impulse);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newHeading), 0.1f);
    }

    public void GetHit(float p)
    {
        Health -= p;
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.collider.tag == "Wall")
        {

            Vector3 CorrectionHeading = new Vector3(transform.rotation.x, -1 * transform.rotation.y, transform.rotation.z);
            //transform.eulerAngles = CorrectionHeading;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newHeading), 0.7f);
        }
        if (collision.collider.name == "SlugPreFab(Clone)")
        {
            Debug.Log("hit");
            GameManager.instance.Killpoints();
            
            //Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {

            Vector3 CorrectionHeading = new Vector3(transform.rotation.x, -1 * transform.rotation.y, transform.rotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newHeading), 0.7f);
        }
    }
}
