using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Path : MonoBehaviour {
	public Transform[] pathNodes;
	// Use this for initialization
	void Start () {
		//pathNodes = GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDrawGizmos() {
		for (int i = 0; i<pathNodes.Length - 1;i++) {
			Handles.DrawDottedLine(pathNodes[i].position,pathNodes[i+1].position,3.0f);
		}
	}

	public Vector3 GetNodePosition(int segment) {
		return(pathNodes[segment].position);
	}
}
