using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Caterative.Brick.Balls;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldMinionB : MonoBehaviour, ICollidable
    {
        Shield shield;
        ShieldBossFigure figure;
        public int health = 10;
        public Ball targetBall;

        void Awake()
        {
            shield = GetComponentInChildren<Shield>();
            figure = GetComponentInChildren<ShieldBossFigure>();
        }

        void Start()
        {
            targetBall = FindObjectOfType<Ball>();
            shield.DirectTowards(270);
        }

        void Update()
        {
            if (targetBall != null)
            {
                if (targetBall.transform.position.y > transform.position.y)
                {
                    if (targetBall.transform.position.x > transform.position.x)
                    {
                        shield.DirectTowards(87, 0.06f);
                    }
                    else
                    {
                        shield.DirectTowards(93, 0.06f);
                    }
                }
                else
                {
                    if (targetBall.transform.position.x > transform.position.x)
                    {
                        shield.DirectTowards(273, 0.06f);
                    }
                    else
                    {
                        shield.DirectTowards(267, 0.06f);
                    }
                }
            }
        }

        void ICollidable.OnCollideWithBall(Ball ball)
        {
            targetBall = ball;
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