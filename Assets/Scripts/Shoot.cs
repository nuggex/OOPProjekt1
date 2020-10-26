using System.Collections;
using System.Collections.Generic;
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
}
