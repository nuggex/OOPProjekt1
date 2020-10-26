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
    public float m_speed = 10.0f;
    public float s_speed = 5.0f;
    Transform originalLocation;
    Rigidbody rb;
    GameObject player;
    Vector3 startLocation;
    // Start is called before the first frame update
    void Start()
    {
        nextShot = Time.time;
        ShootHolder = GameObject.Find("Level/ShootHolder").transform;
        startLocation = gameObject.transform.localPosition;
        player = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aimX = GameObject.Find("Head").transform;
        Debug.Log("HEAD :" + aimX.rotation);
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
            if (Time.time - nextShot > 1)
            {
                shoot = Instantiate(ShootPreFab, aimX.position, aimX.rotation, ShootHolder);
                //shoot.gameObject.AddComponent<Rigidbody>();
                Rigidbody shootRB = shoot.GetComponent<Rigidbody>();

                //shootRB.GetComponent<Shoot>().FireShoot();
                shootRB.AddForce(aimX.up * 7500f);
                nextShot = Time.time;
                Destroy(shoot.gameObject, 5);
                
            }
        }
    }
}
