using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
	public BrickSpawner brickSpawner;
	private int currentWave = 0;
	
	void Start () {
		brickSpawner.spawnIndex = currentWave;
		brickSpawner.Spawn();
		GameManager.Instance.ReadyTheBall();
	}
	
	void Update () {
		if (brickSpawner.CountBricksLeft() <= 0) {
			currentWave = currentWave + 1;
			if (currentWave > brickSpawner.bricks.Length - 1) {
				currentWave = 0;
			}
			brickSpawner.spawnIndex = currentWave;
			brickSpawner.Spawn();
		}
	}

}
