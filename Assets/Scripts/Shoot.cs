using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Rigidbody Rbshot;
    Vector3 SpawnPosition;
    

    public void FireShoot(Transform aimDirection)
    {
        float xDir = aimDirection.transform.position.x;
        float yDir = aimDirection.transform.position.y;
        float zDir = aimDirection.transform.position.z;
        Vector3 aimVector = new Vector3(xDir, yDir, zDir);
        Debug.Log(aimVector);
        Rbshot.AddForce(aimVector, ForceMode.Impulse);
    }
}
