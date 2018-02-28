using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
	public GameObject[] Bricks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Spawn(int spawnIndex) {
		GameObject currentBrick = Bricks[spawnIndex];
		currentBrick.transform.SetParent(this.transform);
		currentBrick.transform.position = this.transform.position;
		if (currentBrick.GetComponent<Brick>() != null) {
			currentBrick.GetComponent<Brick>().ReviveBrick();
		} else if (currentBrick.GetComponentsInChildren<Brick>() != null) {
			for (int i = 0; i<currentBrick.transform.childCount; i++) {
				currentBrick.GetComponentsInChildren<Brick>()[i].ReviveBrick();
			}
		}
	}
	public int CountBricksLeft() {
		return (this.transform.childCount);
	}
}
