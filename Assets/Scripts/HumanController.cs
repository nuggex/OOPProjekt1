using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public Shoot ShootPreFab;
    public Shoot shoot;
    public Transform ShootHolder;
    public Transform aim;
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
        ShootHolder = GameObject.Find("Level/Shots").transform;
        startLocation = gameObject.transform.localPosition;
        player = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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

                aim = GameObject.Find("Head").transform;
                Debug.Log(aim);
                shoot = Instantiate(ShootPreFab, transform.position, transform.rotation, ShootHolder);
                shoot.GetComponent<Shoot>().FireShoot(aim);

                nextShot = Time.time;
                Destroy(shoot, 10f);
            }
        }
    }
}
