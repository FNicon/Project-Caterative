using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Caterative.Brick.Balls;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldMinionC : MonoBehaviour, ICollidable
    {
        Shield shield;
        ShieldBossFigure figure;
        public int health = 2;
        public float happyRotationPerSecond = 25;

        void Awake()
        {
            shield = GetComponentInChildren<Shield>();
            figure = GetComponentInChildren<ShieldBossFigure>();
        }

        void Update()
        {
            shield.transform.Rotate(0, 0, happyRotationPerSecond * Time.deltaTime);
        }

        void ICollidable.OnCollideWithBall(Ball ball)
        {
            health--;
            figure.Hit();
            if (health <= 0)
            {
                Deactivate();
            }
        }

        private void Deactivate()
        {
            transform.position = new Vector2(-10, 100);
        }
    }
}