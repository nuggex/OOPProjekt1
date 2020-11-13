using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public HumanController hc;
    public Spring sp;
    public List<GameObject> ButterFlies;
    public List<GameObject> Slugs;
    public List<Transform> Platforms;
    public float BulletMass;
    public float PlatformMass;
    private void Awake()
    {

        instance = this;
    }

    public void ResetGame()
    {
     
    }

    public float GetWeight()
    {
        return hc.Weight;
    }

    public float GetVelocity()
    {
        return hc.VelocityY;
    }

    public void TriggerSpringForce()
    {
        sp.Activate();
    }
    public void UnTriggerSpringForce()
    {
        sp.Disable();
    }
    public void Killpoints()
    {
        hc.Killed();
    }
}

public enum Rewards
{
    
}
