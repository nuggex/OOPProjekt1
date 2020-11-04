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
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 65f;
    private float gravityValue = -150f;
    CharacterController Character;

    float points = 0;
    // Start is called before the first frame update
    void Start()
    {
        Character = gameObject.GetComponent<CharacterController>();
        nextShot = Time.time;
        ShootHolder = GameObject.Find("Level/ShootHolder").transform;
        startLocation = gameObject.transform.localPosition;
        player = gameObject;
        head = GameObject.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        aimX = head.transform;

        groundedPlayer = Character.isGrounded;
        /*if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }*/

        gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        Debug.Log(groundedPlayer);
        //Vector3 move = new Vector3(Input.GetAxis("Vertical"), gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y);
        //Debug.Log(move);
        

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveDirection = transform.TransformDirection(Vector3.forward);
            Character.Move(moveDirection * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveDirection = transform.TransformDirection(-Vector3.forward);
            Character.Move(moveDirection * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveDirection = transform.TransformDirection(-Vector3.right);
            Character.Move(moveDirection * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveDirection = transform.TransformDirection(Vector3.right);
            Character.Move(moveDirection * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            Debug.Log("Is Jumping");
            playerVelocity.y = jumpHeight;
            Debug.Log("Jump velocity: " + playerVelocity.y);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        Character.Move(playerVelocity * Time.deltaTime);
        /*if (move != Vector3.zero)
        {
            Debug.Log("Moving");
            
        }*/
        /*
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.time;
        Character.SimpleMove(playerVelocity * Time.time);
        */
        /*
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            Character.Move(move * Time.deltaTime * 2f);
            //Character.Move(transform.position * Time.deltaTime * 1f);
            //rb.transform.Translate(transform.forward *2f);
            //transform.position += transform.forward * Time.deltaTime * m_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            //Character.Move(Vector3.ClampMagnitude(-rb.transform.forward, 1.0f));
            //rb.transform.Translate(-transform.forward);
            //transform.position -= transform.forward * Time.deltaTime * m_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            //rb.transform.Translate(-transform.right* 1.5f);
            //transform.position += transform.right * Time.deltaTime * s_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            //rb.transform.Translate(transform.right * 1.5f);
            //transform.position -= transform.right * Time.deltaTime * s_speed;
        }*/
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("LeftControl");
            if (Time.time - nextShot > 0.05f)
            {
                
                shoot = Instantiate(ShootPreFab, aimX.position, aimX.rotation, ShootHolder);
                //shoot.gameObject.AddComponent<Rigidbody>();
                Rigidbody shootRB = shoot.GetComponent<Rigidbody>();
                //Debug.Log("Player Velocity: " + rb.velocity.magnitude);
                //float speed = ((7500f * rb.velocity.magnitude) < 5000f) ? 7500f : 7500f * rb.velocity.magnitude;
                float speed = 7500f;
                //shootRB.GetComponent<Shoot>().FireShoot();
                //shootRB.velocity = rb.velocity;
                //shootRB.angularVelocity = rb.angularVelocity;
                shootRB.AddForce((aimX.up) * speed );
                Debug.Log("test");
                Debug.Log("speed" + speed);
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
