using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleDetectionArea : MonoBehaviour
{
    public const int MAX_COLLIDER_DETECTED = 100;
    Collider2D colliderDetector;
    Collider2D[] colliderBuffer;
    public int countRemaining { get; private set; }

    void Awake()
    {
        colliderBuffer = new Collider2D[MAX_COLLIDER_DETECTED];
        colliderDetector = GetComponent<Collider2D>();
    }

    public int CountRemainingDestructible()
    {
        int countDetected = Physics2D.OverlapCollider(colliderDetector, new ContactFilter2D(), colliderBuffer);
        countRemaining = 0;
        for(int i = 0; i < countDetected; i++)
        {
            if (colliderBuffer[i].CompareTag("Destructible"))
            {
                countRemaining++;
            }
        }
		return countRemaining;
    }
}