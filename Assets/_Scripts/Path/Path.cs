using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
	public Transform[] pathNodes;
	public Vector3 GetNodePosition(int segment)
	{
		return(pathNodes[segment].position);
	}
}
