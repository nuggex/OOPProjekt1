using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonsBallCollider : MonoBehaviour
{
    public GameObject ThisBall;
    public float ParentVelocity;
    public bool HasHitBall = false;
    bool left = false;
    float temp;

    private void OnCollisionEnter(Collision collision)
    {
        int counter = 0;
        if (collision.collider.tag == "NewtonBall")
        {
            for (int i = 1; i < 6; i++)
            {

                // if(collision.collider.name =="Bob-1")
                string coll = "Bob-" + i.ToString();
                string gob = "Bob-" + (i + 1).ToString();
                {

                    temp = collision.collider.gameObject.GetComponentInParent<NewtonsCradle>().Velocity + gameObject.GetComponentInParent<NewtonsCradle>().Velocity;
                    if (temp >= 0)
                    {

                        if (collision.collider.gameObject.name == coll && gameObject.name == gob)
                        {
                            gameObject.GetComponentInParent<NewtonsCradle>().Velocity = temp;
                            gameObject.GetComponentInParent<NewtonsCradle>().Velocity = collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity;
                            collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = 0.0f;
                            counter++;
                        }
                    }
                    else
                    {
                        if (collision.collider.gameObject.name == coll && gameObject.name == gob)
                        {
                            collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = temp;
                            //collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = gameObject.GetComponentInParent<NewtonsCradle>().Velocity;
                            gameObject.GetComponentInParent<NewtonsCradle>().Velocity = 0.0f;
                            left = true;
                            counter--;

                        }
                    }

                    /*
                    if (gameObject.GetComponentInParent<NewtonsCradle>().ThisCollision == false)
                    {
                        other.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = GameManager.instance.PendulumVelocity;
                    }
                    //ThisBall.GetComponentInParent<NewtonsCradle>().Velocity = ThisBall.GetComponentInParent<NewtonsCradle>().Velocity/10f;
                    gameObject.GetComponentInParent<NewtonsCradle>().ThisCollision = true;
                    */
                }
            }
        }
        /*
        Debug.Log(collision.collider.tag);

        foreach (NewtonsCradle NewtonsBall in GameManager.instance.NewtonsBalls)
        {
            //Debug.Log(NewtonsBall.name);
            if (gameObject.GetComponentInParent<NewtonsCradle>().name == NewtonsBall.name)
            {

                Debug.Log("THIS : " + collision.gameObject.GetComponentInParent<NewtonsCradle>().name + " COLLIDED WITH " + NewtonsBall.name + " at velocity " + NewtonsBall.Velocity);
                //NewtonsBall.Velocity = gameObject.GetComponentInParent<NewtonsCradle>().Velocity;
                collision.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = NewtonsBall.Velocity;
                NewtonsBall.Velocity = -0.05f;
                //ThisBall.GetComponent<Collider>().isTrigger = false;
                //other.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = -0.05f;
            }
        }

        /* if (collision.collider.tag == "NewtonBall")
         {
             collision.collider.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = GameManager.instance.PendulumVelocity;
             this.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = 0;
         }*/
    }
    private void OnTriggerEnter(Collider other)
    {


        /*
        //Debug.Log("trigged");
        foreach (NewtonsCradle NewtonsBall in GameManager.instance.NewtonsBalls)
        {
            //Debug.Log(NewtonsBall.name);
            if (other.gameObject.name.Contains)
            {

                Debug.Log("THIS : " + gameObject.GetComponentInParent<NewtonsCradle>().name + " COLLIDED WITH " + NewtonsBall.name);
                gameObject.GetComponentInParent<NewtonsCradle>().;
                NewtonsBall.Velocity = 0;
                //ThisBall.GetComponent<Collider>().isTrigger = false;
                //other.gameObject.GetComponentInParent<NewtonsCradle>().Velocity = -0.05f;
            }
        }*/

    }
    private void OnTriggerExit(Collider other)
    {/*
        if (other.tag == "NewtonBall")
        {
            if(other.gameObject.GetComponentInParent<NewtonsCradle>().HasCollided == false) 
            other.gameObject.GetComponentInParent<NewtonsCradle>().HasCollided = true;

        }*/



    }
}
