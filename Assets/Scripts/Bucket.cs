using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Bullet")
        {
            GameManager.instance.PlatformMass += 0.5f;
        }
        if (other.name == "RobotKyle") {
            Debug.Log("Kyle has entered");
            GameManager.instance.PlatformMass += 100f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Bullet")
        {
            GameManager.instance.PlatformMass -= 0.5f;
        }
        if (other.name == "RobotKyle")
        {
            Debug.Log("Kyle has entered");
            GameManager.instance.PlatformMass -= 100f;
        }
    }
}
