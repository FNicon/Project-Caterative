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
    public Path cameraPath;
    private int currentPathSegment = 0;

    void Awake()
    {
        tracker = GetComponent<CameraTargetTracker>();
        if (cameraPath == null)
        {
            Debug.LogError("[CameraMovement] Camera Path object is null! IF IN DOUBT,  use the example prefab found in the _Scenes/PathTest and assign it to CameraMovement script!");
        }
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
            transform.position.y + relativeDistancesOfObjects[i].y);
        }
    }

    private void UpdateTargetPosition()
    {
        if (transform.position.y >= cameraPath.GetNodePosition(currentPathSegment).y)
        {
            currentPathSegment = currentPathSegment + 1;
        }
        GameObject target = tracker.GetClosestTarget();
        if (target != null)
        {
            noTarget = false;
            if (target.transform.position.y - transform.position.y > lowestObjectPositionInCamera)
            {
                targetPosition = new Vector3(cameraPath.GetNodePosition(currentPathSegment).x, target.transform.position.y - lowestObjectPositionInCamera, -10);
            }
        }
        else
        {
            noTarget = true;
            targetPosition = new Vector3(0, 0, -10);
        }
    }
}
