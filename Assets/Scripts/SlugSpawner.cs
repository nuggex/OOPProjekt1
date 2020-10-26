using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugSpawner : MonoBehaviour
{

    public Shoot ShootPreFab;
    public Shoot shoot;
    public Transform ShootHolder;
    public Transform aim;
    float nextShot = 0;
    // Start is called before the first frame update
    private void Start()
    {
        nextShot = Time.time;
        ShootHolder = GameObject.Find("Level/Shots").transform;
       // aim = GameObject.Find("Level/Terrain/Robot Kyle/Root/Ribs/Neck/Head").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - nextShot > 1)
        {

            aim = GameObject.Find("Level/Terrain/Robot Kyle/Root/Ribs/Neck/Head").transform;

            shoot = Instantiate(ShootPreFab, transform.position, transform.rotation, ShootHolder);
            shoot.GetComponent<Shoot>().FireShoot(aim);

            nextShot = Time.time;
            Destroy(shoot, 10f);
        }
    }



}
