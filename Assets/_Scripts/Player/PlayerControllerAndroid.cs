using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAndroid : MonoBehaviour {


	private bool isDragging;
	private float distance;
	private Vector3 offset;
	private Transform player;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	Vector2 ReadInput() {
		Vector3 v3;
		RaycastHit hit;
		Ray ray;
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;
			if (touch.phase == TouchPhase.Began) {
				ray = Camera.main.ScreenPointToRay (pos);
				if (Physics.Raycast (ray, out hit) && (hit.collider.tag == "Player")) {
					player = hit.transform;
					distance = hit.transform.position.z - Camera.main.transform.position.z;
					v3 = new Vector3 (pos.x, pos.y, distance);
					v3 = Camera.main.ScreenToWorldPoint (v3);
					offset = player.position - v3;
					isDragging = true;
					return (new Vector2 (0, 0));
				}
			}

			if (touch.phase == TouchPhase.Moved && isDragging) {
				v3 = touch.position - pos;
				return (new Vector2(v3.x, v3.y));
			}
		} 
		else {
			isDragging = false;
			return (new Vector2 (0,0));
		}
	} */
}
