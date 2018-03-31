using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetTracker : MonoBehaviour
{
    List<GameObject> targets;
    public Path cameraPath;
    public int currentTargetIndex = 0;
    new private Transform camera;
    GameObject closestTarget;

    void Awake()
    {
        camera = Camera.main.transform;
        targets = new List<GameObject>();
        if (cameraPath == null)
        {
            Debug.LogError("[CameraTargetTracker] Camera Path object is null! IF IN DOUBT, put, in the scene, the example prefab found in the _Prefabs and assign it to CameraTargetTracker script!");
        }
    }

    void OnEnable()
    {
        for (int i = 0; i < cameraPath.pathNodes.Length; i++)
        {
            targets.Add(cameraPath.pathNodes[i].gameObject);
        }
    }

    public GameObject GetClosestTarget()
    {
        if (targets.Count > 0)
        {
            closestTarget = null;
            for (int i = 0; i < targets.Count; i++)
            {

                if (ResolveTarget(closestTarget, i))
                {
                    closestTarget = targets[i];
                }
            }
            return closestTarget;
        }
        else
        {
            return null;
        }
    }

    private bool ResolveTarget(GameObject closestTarget, int i)
    {
        if (closestTarget == null && targets[i].activeSelf == true) {
            return true;
        } else {
            return targets[i].activeSelf == true
                    && Vector2.Distance(targets[i].transform.position, camera.position)
                       < Vector2.Distance(closestTarget.transform.position, camera.position);   
        }
    }

    public GameObject GetCurrentTargetByIndex()
    {
        if (currentTargetIndex >= targets.Count)
        {
            Debug.LogWarning("[CameraTargetTracker] Target Index exceeds the number of target - 1, used Modulo value instead");
        }
        return targets[currentTargetIndex % targets.Count];
    }
}
