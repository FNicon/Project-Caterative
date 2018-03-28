using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickLife = 1;
    private int currentBrickLife = 1;
    public Transform bricksPool;
    public BrickDropper dropper;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ball"))
        {
            GetDamage();
        }
    }
    void GetDamage()
    {
        currentBrickLife = currentBrickLife - 1;
        if (currentBrickLife <= 0)
        {
            RelocateBrickToPool();
        }
    }

    void RelocateBrickToPool()
    {
        dropper.DropAll();
        this.transform.SetParent(bricksPool);
        this.transform.position = bricksPool.transform.position;
    }
    public void ReviveBrick()
    {
        currentBrickLife = brickLife;
    }
}
