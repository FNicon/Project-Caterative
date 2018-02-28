using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int brickLife = 1;
	private int currentBrickLife = 1;
	public Vector2 spawnPosition;
	public Transform bricksPool;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.CompareTag("Ball")) {
			GetDamage();
		}
	}
	void GetDamage() {
		currentBrickLife = currentBrickLife - 1;
		if (currentBrickLife < 0) {
			RelocateBrick();
		}
	}
	void RelocateBrick() {
		this.transform.SetParent(bricksPool);
		this.transform.position = bricksPool.transform.position;
		Spawn();
	}
	void Spawn() {
		currentBrickLife = brickLife;
		this.transform.SetParent(null);
		this.transform.position = spawnPosition;
	}
}
