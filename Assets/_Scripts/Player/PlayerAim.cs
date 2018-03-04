using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Ball ballToLaunch;
    public LineRenderer targetLine;
    private float launchDirection;
    public float launchSpeed;
    private Vector2 startLaunchLocation;
	private Vector2 targetLaunchLocation;
    public GameObject ballsPool;

    void Awake()
    {
        targetLine.positionCount = 2;
        ReloadBall();
    }

    void Update()
    {
        UpdateLaunchDirection();
    }
	
    public void UpdateLaunchDirection()
    {
        launchDirection = 90 + ((transform.position.x / 2) * -45);
        startLaunchLocation = new Vector2(
            transform.position.x * 1.25f,
            transform.position.y + 0.5f
        );
        targetLine.SetPosition(0, startLaunchLocation);
        Vector2 launchVector = VectorRotation.RotateVector(Vector2.right, launchDirection);
        int layerMask = LayerMask.GetMask("Bricks","Balls");
        RaycastHit2D hit = Physics2D.Raycast(transform.position,launchVector, 20, layerMask);
        if (hit.collider != null)
        {
            targetLaunchLocation = hit.point;
        }
        else
        {
            targetLaunchLocation = startLaunchLocation + (launchVector * 20);
        }
		targetLine.SetPosition(1, targetLaunchLocation);
    }

    public void Shoot()
    {
        if (ballToLaunch != null)
        {
            ballToLaunch.GetComponentInChildren<TrailRenderer>().enabled = true;
            ballToLaunch.transform.position = startLaunchLocation;
            ballToLaunch.LaunchTowardsAngle(launchSpeed, launchDirection);
            ballToLaunch = null;
        }
    }

    public void ReloadBall()
    {
        if (ballsPool.transform.childCount > 0)
        {
            GameObject currentBall = ballsPool.transform.GetChild(0).gameObject;
            ballToLaunch = currentBall.GetComponent<Ball>();
            currentBall.transform.SetParent(null);
        }
        else
        {
            ballToLaunch = null;
            targetLine.enabled = false;
        }
    }
}
