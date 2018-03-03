using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private bool noTarget;
	private Vector3 targetPosition;
	public float maxDistancePerFrame = 8;
	public float moveFactor = 0.1f;
	public List<GameObject> objectsRelativeToCamera;
	public Vector2[] relativeDistancesOfObjects;
	public BrickSpawner spawner;
	// Use this for initialization
	void Start () {
		UpdateRelativePositionsToBrick();
	}
	
	// Update is called once per frame
	void Update () {
		if (!noTarget) {
			MoveCamera(GetDistancePerFrame());
			MoveRelativeObjects();
		}
		UpdateRelativePositionsToBrick();
	}
	private float GetDistancePerFrame() {
		float partialDistanceToTarget = Vector2.Distance(transform.position, targetPosition) * moveFactor;
		float distancePerFrame;
		if (partialDistanceToTarget > maxDistancePerFrame) {
			distancePerFrame = maxDistancePerFrame;
		} else {
			distancePerFrame = partialDistanceToTarget;
		}
		return (distancePerFrame);
	}
	private void MoveCamera(float distancePerFrame) {
		Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, distancePerFrame * Time.deltaTime);
		transform.position = newPosition;
	}

	private void MoveRelativeObjects() {
		for (int i = 0; i < objectsRelativeToCamera.Count; i++) {
			Transform relativeObject = objectsRelativeToCamera[i].transform;
			relativeObject.position = new Vector2(relativeObject.position.x,transform.position.y + relativeDistancesOfObjects[i].y);
		}
	}

	private void UpdateRelativePositionsToBrick() {
		GameObject whichDestroyable = spawner.bricks[0];
		if (whichDestroyable != null) {
			noTarget = false;
			if (whichDestroyable.transform.position.y - transform.position.y > 2) {
				targetPosition = new Vector3(0, whichDestroyable.transform.position.y - 2, -10);
			}
		} else {
			noTarget = true;
			targetPosition = Vector2.zero;
		}
	}
}
