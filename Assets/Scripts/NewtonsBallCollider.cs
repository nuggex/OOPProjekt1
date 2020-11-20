using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonsBallCollider : MonoBehaviour
{
    public GameObject ThisBall;
    public float ParentVelocity;
    public bool HasHitBall = false;
    float temp;

    private void OnCollisionEnter(Collision collision)
    {

        // If collision object is anohter Bob Ball //
        if (collision.collider.tag == "NewtonBall")
        {

            // Loop to generate and find bob object name // 
            for (int i = 1; i < 6; i++)
            {

                // Create strings used for comparison in this loop // 
                string coll = "Bob-" + i.ToString();
                string gob = "Bob-" + (i + 1).ToString();
                {

                    // Add velocity of collision object and this gameobject to temp and set collided velocity to zero // 
                    temp = collision.collider.gameObject.GetComponentInParent<NewtonsCradle>().Velocity + gameObject.GetComponentInParent<NewtonsCradle>().Velocity;
                    // if velocity is positive add temp to this gameobject (This means the bob is going to the right // 
                    if (temp >= 0)
                    {

                        if (collision.collider.gameObject.name == coll && gameObject.name == gob)
                        {
                            gameObject.GetComponentInParent<NewtonsCradle>().Velocity = temp;
                            
                            //gameObject.GetComponentInParent<NewtonsCradle>().Velocity = collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity;
                            collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = 0.0f;
                        }
                    }
                    // If velocity isn't postive add velocity to collision gameobject and set this game object velocity to zero // 
                    else
                    {
                        if (collision.collider.gameObject.name == coll && gameObject.name == gob)
                        {
                            collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = temp;
                            gameObject.GetComponentInParent<NewtonsCradle>().Velocity = 0.0f;

                        }
                    }

                }
            }
        }
    }
}
