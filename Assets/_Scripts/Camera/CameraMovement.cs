using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool noTarget;
    private Vector3 targetPosition;
	private float distancePerSecond;
    public float maxDistancePerSecond = 8;
    public float moveFactor = 0.1f;
    public List<GameObject> objectsRelativeToCamera;
    public Vector2[] relativeDistancesOfObjects;
    public float lowestObjectPositionInCamera = 2f;
    CameraTargetTracker tracker;

    void Awake()
    {
        tracker = GetComponent<CameraTargetTracker>();
    }

    void Start()
    {
        targetPosition = transform.position;
        UpdateTargetPosition();
    }

    void Update()
    {
        if (!noTarget)
        {
            MoveCamera(GetDistanceToTargetPerSecond());
            MoveObjectsRelativeToCamera();
        }
        UpdateTargetPosition();
    }

    private float GetDistanceToTargetPerSecond()
    {
        float partialDistanceToTarget = Vector2.Distance(transform.position, targetPosition) * moveFactor;
        float distancePerSecond;        
        if (partialDistanceToTarget > maxDistancePerSecond)
        {
            distancePerSecond = maxDistancePerSecond;
        } else
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
            relativeObject.position = new Vector2 (
            relativeObject.position.x,
            transform.position.y + relativeDistancesOfObjects[i].y);
        }
    }

    private void UpdateTargetPosition()
    {
        GameObject target = tracker.GetClosestTarget();
        if (target != null)
        {
            noTarget = false;
            if (target.transform.position.y - transform.position.y > lowestObjectPositionInCamera)
            {
                targetPosition = new Vector3(0, target.transform.position.y - lowestObjectPositionInCamera, -10);
            }
        } else
        {
            noTarget = true;
            targetPosition = new Vector3(0, 0, -10);
        }
    }
}
