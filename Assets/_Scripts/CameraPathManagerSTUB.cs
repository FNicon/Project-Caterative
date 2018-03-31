using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPathManagerSTUB : MonoBehaviour
{
    CameraTargetTracker tracker;

    void Awake()
    {
        tracker = Camera.main.GetComponent<CameraTargetTracker>();
    }

    void Update()
    {
        GameObject node = tracker.GetCurrentTargetByIndex();
        TargetDetectionArea area = node.GetComponent<TargetDetectionArea>();
        if (area != null && area.GetRemainingTargetCount() == 0)
        {
            tracker.currentTargetIndex++;
        }
    }
}
