using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public Path pathToFollow;
    public int currentSegment = 0;
    public int moveToward = 1;
    public float speed = 1f;

    public enum MovementType
    {
        Default,
        Cycle
    }

    public MovementType movementType;

    void Update()
    {
        if (pathToFollow != null)
        {
            switch (movementType)
            {
                case MovementType.Cycle:
                    MoveCycle();
                    break;
                default:
                    Move();
                    break;
            }
        }
        Vector3 newPosition = Vector3.MoveTowards(
            transform.position, pathToFollow.GetNodePosition(currentSegment),
            speed * Time.deltaTime
        );
        transform.position = newPosition;
    }

    private void MoveCycle()
    {
        if (transform.position == pathToFollow.GetNodePosition(currentSegment))
        {
            if (moveToward > 0)
            {
                currentSegment++;
            } else {
				currentSegment--;
			}
            if (currentSegment >= pathToFollow.pathNodes.Length)
            {
                currentSegment = 0;
            } else if (currentSegment < 0) {
				currentSegment = pathToFollow.pathNodes.Length -1;
			}
        }
    }

    void Move()
    {
        if (transform.position == pathToFollow.GetNodePosition(currentSegment))
        {
            currentSegment = currentSegment + moveToward;
            if (currentSegment >= pathToFollow.pathNodes.Length - 1)
            {
                moveToward = -1;
            }
            else if (currentSegment <= 0)
            {
                moveToward = 1;
            }
        }
    }
}
