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

    private void OnDestroy()
    {
        //GameManager.instance.PlatformMass -= 0.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.name == "BUTT09" || collision.collider.name == "BUTT08" || collision.collider.name == "BUTT07" || collision.collider.name == "BUTT06")
        {
            collision.collider.gameObject.SetActive(false);
        }else if(collision.collider.name == "Butterfly(Clone)")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
