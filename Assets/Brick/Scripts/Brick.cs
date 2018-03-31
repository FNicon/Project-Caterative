using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickLife = 1;
    private int currentBrickLife = 1;
    public Transform bricksPool;
    public BrickDestroyEffect destroyEffect;
    public BrickDropper dropper;

    void Awake()
    {
        if (bricksPool == null)
        {
            bricksPool = transform.parent;
        }
        if (bricksPool == null)
        {
            Debug.LogError("[Brick] Either Brick's pool is not assigned OR Brick is not set as a child of a pool!");
        }
        destroyEffect = GetComponent<BrickDestroyEffect>();
        dropper = GetComponent<BrickDropper>();
    }

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
            destroyEffect.Play(transform.position);
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
