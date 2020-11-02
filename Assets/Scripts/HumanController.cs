using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public Shoot ShootPreFab;
    public Shoot shoot;
    public Transform ShootHolder;
    public Transform aimX;
    public Transform aimY;

    float nextShot = 0;
    float m_speed = 275.0f;
    float s_speed = -145.0f;
    Transform originalLocation;
    Rigidbody rb;
    GameObject player;
    GameObject head;
    Vector3 startLocation;

    float points = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextShot = Time.time;
        ShootHolder = GameObject.Find("Level/ShootHolder").transform;
        startLocation = gameObject.transform.localPosition;
        player = gameObject;
        head = GameObject.Find("Head");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aimX = head.transform;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * m_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * m_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * Time.deltaTime * s_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= transform.right * Time.deltaTime * s_speed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Time.time - nextShot > 0.05f)
            {
                shoot = Instantiate(ShootPreFab, aimX.position, aimX.rotation, ShootHolder);
                //shoot.gameObject.AddComponent<Rigidbody>();
                Rigidbody shootRB = shoot.GetComponent<Rigidbody>();

                //shootRB.GetComponent<Shoot>().FireShoot();
                shootRB.AddForce(aimX.up * 7500f + transform.position);
                nextShot = Time.time;
                Destroy(shoot.gameObject, 5);
                
            }
        }
    }

    public void Killed()
    {
        points += 1;
    }
}
