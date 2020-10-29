using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButterFlyController : MonoBehaviour
{

    GameObject ButterFly;
    Transform LeftWing;
    Transform RightWing;
    float WingDirection;
    float Rotspeed = 4.5f;
    float Health = 100f;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        ButterFly = GameObject.Find("Level/Butterfly");
        //LeftWing = GameObject.Find(transform.name +"/LeftWing").transform;
        //RightWing = GameObject.Find(transform.name + "/RightWing").transform;
        WingDirection = 0;

        LeftWing = gameObject.GetComponentInChildren<Transform>().Find("LeftWing");
        RightWing = gameObject.GetComponentInChildren<Transform>().Find("RightWing");
        transform.Rotate(0, Random.Range(-179, 180), 0);
        speed = Random.Range(2f, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (LeftWing.rotation.eulerAngles.z > 40 || LeftWing.rotation.eulerAngles.z < -45) Rotspeed *= -1;

        LeftWing.Rotate(0, 0, Rotspeed);
        this.RightWing.Rotate(0, 0, -Rotspeed);

        //gameObject.transform.position += transform.forward * speed;

    }

    public void GetHit(float p)
    {
        Health -= p;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.name == "SlugPreFab(Clone)")
        {
            Debug.Log("hit");
            GameManager.instance.Killpoints();
            Destroy(this.gameObject);
        }
    }
}
