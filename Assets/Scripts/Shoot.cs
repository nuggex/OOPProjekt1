using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Rigidbody Rbshot;
    Vector3 SpawnPosition;
    

    public void FireShoot()
    {
        Rbshot = gameObject.GetComponent<Rigidbody>();
        //Rbshot.AddForce(transform.up * 100f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT WING, Collider name: " + collision.collider.name);

        if (collision.collider.name == "BUTT09" || collision.collider.name == "BUTT08" || collision.collider.name == "BUTT07" || collision.collider.name == "BUTT06")
        {
            Debug.Log("MATCHED wING0");
            //collision.gameObject.SetActive(false);
            collision.collider.gameObject.SetActive(false);
        }else if(collision.collider.name == "Butterfly(Clone)")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
