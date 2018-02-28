using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {
	public Text textLife;
	private int currentLife;
	public int maxLife;
	public GameObject gameOverPanel;
	// Use this for initialization
	void Start () {
		Revive();
		gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Revive() {
		currentLife = maxLife;
		textLife.text = currentLife.ToString();
		gameOverPanel.SetActive(false);
	}
	public void GetDamage() {
		currentLife = currentLife - 1;
		textLife.text = currentLife.ToString();
		if (currentLife <= 0) {
			GameOver();
		}
	}
	public void GameOver() {
		gameOverPanel.SetActive(true);
	}
	public bool IsAlive() {
		return (currentLife > 0);
	}
}
