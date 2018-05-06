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
    public PlayerHurtEffects hurtEffects;
    //public CameraShake hurtEffect;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    public void GetDamage()
    {
        //hurtEffect.Shake();
        hurtEffects.HurtEffect();
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Target")) {
            GetDamage();
        }
    }
}
