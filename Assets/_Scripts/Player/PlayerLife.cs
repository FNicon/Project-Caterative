using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public delegate void LifeEvent(Player player, int currentLife);
    public event LifeEvent OnLifeChange;
    public int currentLife { get; private set; }
    public int maxLife;
    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    public void GetDamage()
    {
        currentLife = currentLife - 1;
        OnLifeChange(player,currentLife);
    }
    public void GetHealth()
    {
        currentLife = currentLife + 1;
        OnLifeChange(player,currentLife);
    }

    public void SetLifeToMax()
    {
        currentLife = maxLife;
    }

    public bool IsAlive()
    {
        return (currentLife > 0);
    }
}
