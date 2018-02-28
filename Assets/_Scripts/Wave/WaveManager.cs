using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
	public BrickSpawner brickSpawner;
	private int currentWave = 0;
	// Use this for initialization
	void Start () {
		brickSpawner.Spawn(currentWave);
	}
	
	// Update is called once per frame
	void Update () {
		if (brickSpawner.CountBricksLeft() <= 0) {
			currentWave = currentWave + 1;
			if (currentWave > brickSpawner.Bricks.Length) {
				currentWave = currentWave + 0;
			}
			brickSpawner.Spawn(currentWave);
		}
	}

}
