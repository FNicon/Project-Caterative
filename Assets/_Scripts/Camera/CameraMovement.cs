using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    private float distancePerSecond;
    public float maxDistancePerSecond = 8;
    public float moveFactor = 0.1f;
    public List<GameObject> objectsRelativeToCamera;
    public Vector2[] relativeDistancesOfObjects;
    CameraTargetTracker tracker;
    public bool isUpdatingToClosestTarget = true;
    public bool canTargetLowerPosition = false;

    void Awake()
    {
        tracker = GetComponent<CameraTargetTracker>();
        Debug.LogWarning("[CameraMovement] If the camera is not moving, try either:\n deactivating Node GameObject from the smallest XOR changing CameraTargetTracker's currentTargetIndex value :)");
        Debug.Log("[CameraMovement] This script no longer holds the any Path. CameraTargetTracker holds it instead.");
    }

    void Start()
    {
        targetPosition = transform.position;
        UpdateToIndexTargetPosition();
    }

    void Update()
    {
        MoveCamera(GetDistanceToTargetPerSecond());
        MoveObjectsRelativeToCamera();
        if (isUpdatingToClosestTarget)
        {
            UpdateClosestTargetPosition();
        }
        else
        {
            UpdateToIndexTargetPosition();
        }
    }

    private float GetDistanceToTargetPerSecond()
    {
        float partialDistanceToTarget = Vector2.Distance(transform.position, targetPosition) * moveFactor;
        float distancePerSecond;
        if (partialDistanceToTarget > maxDistancePerSecond)
        {
            distancePerSecond = maxDistancePerSecond;
        }
        else
        {
            distancePerSecond = partialDistanceToTarget;
        }
        return (distancePerSecond);
    }

    private void MoveCamera(float distancePerSecond)
    {
        Vector3 newPosition = Vector3.MoveTowards(
            transform.position, targetPosition,
            distancePerSecond * Time.deltaTime
        );
        transform.position = newPosition;
    }

    private void MoveObjectsRelativeToCamera()
    {
        for (int i = 0; i < objectsRelativeToCamera.Count; i++)
        {
            Transform relativeObject = objectsRelativeToCamera[i].transform;
            relativeObject.position = new Vector2(
                transform.position.x,
                transform.position.y + relativeDistancesOfObjects[i].y
            );
        }
    }

    private void UpdateClosestTargetPosition()
    {
        GameObject target = tracker.GetClosestTarget();
        if (target != null)
        {
            if (canTargetLowerPosition || target.transform.position.y - transform.position.y > 0)
            {
                targetPosition = new Vector3(
                    target.transform.position.x,
                    target.transform.position.y,
                    -10);
            }
        }
        else
        {
            targetPosition = new Vector3(0, 0, -10);
        }
    }

    private void UpdateToIndexTargetPosition()
    {
        targetPosition = tracker.GetCurrentTargetByIndex();
    }
}
