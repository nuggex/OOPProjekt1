using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringScale : MonoBehaviour
{
    float StartScaleY;
    float StartScaleX;
    // Start is called before the first frame update
    void Start()
    {
        StartScaleY = transform.localScale.y;
        StartScaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newYScale = StartScaleY + (GameManager.instance.PlatformDeltaY * 0.203f);
        float newXZScale = StartScaleX - (GameManager.instance.PlatformDeltaY * 0.203f);
        gameObject.transform.localScale = new Vector3(newXZScale, newYScale, newXZScale);
    }
}
