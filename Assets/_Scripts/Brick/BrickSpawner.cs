using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
	public GameObject[] bricks;
	public GameObject spawnArea;
	public int spawnIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Spawn() {
		GameObject currentBrick = bricks[spawnIndex];
		currentBrick.transform.SetParent(spawnArea.transform);
		currentBrick.transform.position = this.transform.position;
		if (currentBrick.GetComponent<Brick>() != null) {
			currentBrick.GetComponent<Brick>().ReviveBrick();
		} else if (currentBrick.GetComponentsInChildren<Brick>() != null) {
			for (int i = 0; i<currentBrick.transform.childCount; i++) {
				currentBrick.GetComponentsInChildren<Brick>()[i].ReviveBrick();
			}
		}
	}
	public GameObject GetCurrentBrick() {
		return (bricks[spawnIndex]);
	}
	public int CountBricksLeft() {
		return (spawnArea.transform.childCount);
	}
}
