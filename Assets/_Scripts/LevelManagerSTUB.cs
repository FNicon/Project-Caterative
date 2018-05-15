using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerSTUB : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text textLife;
    private PlayerLife playerLife;
    private string currentSceneName;

    void Awake()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        RevivePlayer();
        playerLife.OnLifeChange += ResolveLifeChange;
    }

    void OnApplicationQuit()
    {
        playerLife.OnLifeChange -= ResolveLifeChange;
    }

    private void ResolveLifeChange(Player player, int currentLife)
    {
        textLife.text = playerLife.currentLife.ToString();
        if (currentLife <= 0)
        {
            GameOver();
        }
    }

    void Start()
    {
        GameManager.Instance.ReadyTheBall();
    }

    public void RevivePlayer()
    {
        playerLife.SetLifeToMax();
        //textLife.text = playerLife.currentLife.ToString();
        gameOverPanel.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
