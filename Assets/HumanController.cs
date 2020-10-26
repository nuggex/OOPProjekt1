using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{

    public float m_speed = 10.0f;
    public float s_speed = 5.0f;
    Transform originalLocation;
    Rigidbody rb;
    GameObject player;
    Vector3 startLocation;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
