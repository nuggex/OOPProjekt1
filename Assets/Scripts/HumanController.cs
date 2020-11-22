using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
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
    Vector3 LastPosition;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 65f;
    private float gravityValue = -150f;
    public float Weight { get; set; }
    public float VelocityY;
    CharacterController Character;

    float points = 0;
    // Start is called before the first frame update
    void Start()
    {
        Weight = 75.0f;
        Character = gameObject.GetComponent<CharacterController>();
        nextShot = Time.time;
        ShootHolder = GameObject.Find("Level/ShootHolder").transform;
        startLocation = gameObject.transform.localPosition;
        player = gameObject;
        head = GameObject.Find("Head");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VelocityY = (transform.position.y - this.LastPosition.y) / Time.deltaTime;
        this.LastPosition = transform.position;

        aimX = head.transform;

        groundedPlayer = Character.isGrounded;

        gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));

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
            playerVelocity.y = jumpHeight;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        Character.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Time.time - nextShot > 0.05f)
            {

                shoot = Instantiate(ShootPreFab, aimX.position, aimX.rotation, ShootHolder);
                Rigidbody shootRB = shoot.GetComponent<Rigidbody>();
                float speed = 7500f;
                shootRB.AddForce((aimX.up) * speed);
                nextShot = Time.time;
                Destroy(shoot.gameObject, 8);

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      /*  Debug.Log("collision" + collision.collider.gameObject.name);
        if (collision.gameObject.name == "Lower")
        {
            Debug.Log("collision with Lower");
            GameManager.instance.PlatformMass += 75;
        }*/
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        /*
        if (hit.collider.name != "Lower")
        {
            GameManager.instance.UnTriggerSpringForce();
        }*/
    }

    public void Killed()
    {
        points += 1;
    }

}
