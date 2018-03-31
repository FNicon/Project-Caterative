using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("We won't be using spawner since the level's brick are predetermined in the Editor instead")]
public class BrickSpawner : MonoBehaviour
{
    public Brick[] bricks;
    public GameObject spawnArea;
    public int spawnIndex;

    void Awake()
    {
        //bricks = (Brick[]) Resources.FindObjectsOfTypeAll<Brick>();
    }

    public void Spawn()
    {
        if (bricks.Length > 0)
        {
            Brick currentBrick = bricks[spawnIndex];
            currentBrick.transform.SetParent(spawnArea.transform);
            currentBrick.transform.position = this.transform.position;
            currentBrick.ReviveBrick();
        }
    }

    public int CountBricksLeft()
    {
        return (spawnArea.transform.childCount);
    }
}
