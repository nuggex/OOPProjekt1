using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public HumanController hc;

    public List<GameObject> ButterFlies;
    public List<GameObject> Slugs;
    public List<Transform> Platforms;
    private void Awake()
    {

        instance = this;
    }

    public void ResetGame()
    {
        resetPlayer();
        resetEnemies();
    }

    private void resetCollectibles()
    {
        Transform collectibleHolder = GameObject.Find("Level/Collectibles").transform;
        Transform[] rewards = collectibleHolder.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (Transform reward in rewards)
        {
            reward.gameObject.SetActive(true);
        }
        return;
    }
    private void resetPlayer()
    {
        
    }
    private void resetEnemies()
    {

    }
    public void Killpoints()
    {
        hc.Killed();
    }
}

public enum Rewards
{
    
}
