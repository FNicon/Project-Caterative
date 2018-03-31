using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TargetDetectionArea : MonoBehaviour
{
    public const int MAX_COLLIDER_DETECTED = 100;
    Collider2D colliderDetector;
    Collider2D[] colliderBuffer;
    public int countRemaining { get; private set; }

    void Awake()
    {
        colliderBuffer = new Collider2D[MAX_COLLIDER_DETECTED];
        colliderDetector = GetComponent<Collider2D>();
        colliderDetector.isTrigger = true;
        if (GetRemainingTargetCount() == 0)
        {
            Debug.LogWarning("[TargetDetectionArea] There is no GameObject tagged as \"Target\" in \"" + this.name + "\". Consider rechecking if this is not intended");
        }
    }

    public int GetRemainingTargetCount()
    {
        int countDetected = Physics2D.OverlapCollider(colliderDetector, new ContactFilter2D(), colliderBuffer);
        countRemaining = 0;
        for (int i = 0; i < countDetected; i++)
        {
            if (colliderBuffer[i].CompareTag("Target"))
            {
                countRemaining++;
            }
        }
        return countRemaining;
    }
}