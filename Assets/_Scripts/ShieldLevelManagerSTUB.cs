using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldLevelManagerSTUB : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text textLife;
    private PlayerLife playerLife;

    void Awake()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        playerLife.OnLifeChange += ResolveLifeChange;
    }

    void OnApplicationQuit()
    {
        playerLife.OnLifeChange -= ResolveLifeChange;    
    }

    private void ResolveLifeChange(Player player, int currentLife)
    {
        textLife.text = playerLife.currentLife.ToString();
        if (currentLife <= 0) {
            GameOver();
        }
    }

    void Start()
    {
        GameManager.Instance.ReadyTheBall();
        RevivePlayer();
    }

    public void RevivePlayer() {
		playerLife.SetLifeToMax();
		textLife.text = playerLife.currentLife.ToString();
		gameOverPanel.SetActive(false);
	}

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
