using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OscilatingPlatforms : MonoBehaviour
{
    public string PlatformID;
    private float yPos;
    private void Start()
    {
        yPos = transform.position.y;
        GameManager.instance.Platforms.Add(gameObject.transform);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        string name = gameObject.name;
        char PlatformNumber = name.Last();
        int index = (int)PlatformNumber - 1;
        //Debug.Log(Vector3.Distance(transform.position , GameManager.instance.Platforms[index].position));
        float y = Mathf.Sin(Time.time * 2 + PlatformNumber)*2;
        
        transform.position = new Vector3(transform.position.x, y + yPos +2.0f, transform.position.z);
    }
}
