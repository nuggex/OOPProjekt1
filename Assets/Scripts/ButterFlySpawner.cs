using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButterFlySpawner : MonoBehaviour
{

    public GameObject Prefab;
    float timer;
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - timer > 1)
        {
            GameObject butterfly = Instantiate(Prefab, new Vector3(Random.Range(0f, 1000f), Random.Range(10f, 50f), Random.Range(0f, 1000f)), Prefab.transform.rotation);
            timer = Time.time;
            //Destroy(butterfly, 5f);
        }
    }
}
