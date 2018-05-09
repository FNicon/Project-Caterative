using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
	public Path pathToFollow;
	public int currentSegment = 0;
	//private bool isLastSegment = false;
	public int moveToward = 1;
	void Update ()
	{
		if (pathToFollow !=null)
		{
			Move();
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
			} else if (currentSegment <= 0)
			{
				moveToward = 1;
			}
		}
		Vector3 newPosition = Vector3.MoveTowards(
			transform.position, pathToFollow.GetNodePosition(currentSegment),
			1f * Time.deltaTime
		);
		transform.position = newPosition;
	}
}
