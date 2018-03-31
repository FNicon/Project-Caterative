using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Marking this obsolete because it needs BrickSpawner. temporarily, use LevelManagerSTUB instead")]
public class WaveManager : MonoBehaviour
{
    public BrickSpawner brickSpawner;
    private int currentWave = 0;

    void Awake()
    {
		Debug.LogWarning("[WaveManager] If the game does not start, Add LevelManagerSTUB to scene, some changes happen to GameManager and marking this Manager obsolete for now");
    }

    void Start()
    {
        brickSpawner.spawnIndex = currentWave;
        brickSpawner.Spawn();
        GameManager.Instance.ReadyTheBall();
    }

    void Update()
    {
        if (brickSpawner.CountBricksLeft() <= 0)
        {
            currentWave = currentWave + 1;
            if (currentWave > brickSpawner.bricks.Length - 1)
            {
                currentWave = 0;
            }
            brickSpawner.spawnIndex = currentWave;
            brickSpawner.Spawn();
        }
    }

}
