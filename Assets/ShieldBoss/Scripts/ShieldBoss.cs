using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Caterative.Brick.Balls;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldBoss : MonoBehaviour, ICollidable
    {
        Shield shield;
        ShieldBossFigure figure;
        public int health = 60;
        public enum State
        {
            Annoyed,
            Angry
        }
        public int subStateLength = 3;
        public int annoyedStateLength = 2;
        public int angryStateLength = 1;
        public State state;
        int redirectShieldCounter = 0;
        int stateCounter;
        private float moveDistancePerSecond = 2;

        void Awake()
        {
            shield = GetComponentInChildren<Shield>();
            figure = GetComponentInChildren<ShieldBossFigure>();
        }

        void Start()
        {
            shield.DirectTowards(225f);
        }

        void ICollidable.OnCollideWithBall(Ball ball)
        {
            switch (state)
            {
                case State.Annoyed:
                    if (stateCounter == annoyedStateLength * subStateLength)
                    {
                        stateCounter = 0;
                        state = State.Angry;
                    }
                    break;
                case State.Angry:
                    if (stateCounter == angryStateLength * subStateLength)
                    {
                        stateCounter = 0;
                        state = State.Annoyed;
                    }
                    break;
            }
            health--;
            figure.Hit();
            if (health <= 0)
            {
                enabled = false;
            }
            switch (state)
            {
                case State.Annoyed:
                    AnnoyedMode(ball);
                    break;
                case State.Angry:
                    AngryShieldMode(ball);
                    break;
            }
            stateCounter++;
        }

        private void AnnoyedMode(Ball ball)
        {
            shield.setBoostDeflect(false);
            if (transform.position.x != 0)
            {
                StopAllCoroutines();
                StartCoroutine(MoveTowards(new Vector2(0, transform.position.y)));
            }
            redirectShieldCounter = stateCounter % subStateLength;
            if (redirectShieldCounter == subStateLength - 1)
            {
                redirectShieldCounter = 0;
                RedirectShieldTowardsBall(ball);
            }

        }

        private void AngryShieldMode(Ball ball)
        {
            
            if (ball.transform.position.y > transform.position.y)
            {
                shield.DirectTowards(90, 0.06f);
            }
            else
            {
                shield.DirectTowards(270, 0.06f);
            }
            shield.setBoostDeflect(true);
            StopAllCoroutines();
            if (ball.transform.position.x > transform.position.x)
            {
                StartCoroutine(MoveTowards(new Vector2(-1, transform.position.y)));
            }
            else
            {
                StartCoroutine(MoveTowards(new Vector2(1, transform.position.y)));
            }
        }

        private IEnumerator MoveTowards(Vector2 targetPos)
        {
            while (transform.position.x != targetPos.x)
            {
                transform.localPosition = Vector2.MoveTowards(transform.position, targetPos, moveDistancePerSecond * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

        private void RedirectShieldTowardsBall(Ball incomingBall)
        {
            Vector2 ballRelativePos = incomingBall.transform.position - transform.position;
            float angleToRotate;
            if (ballRelativePos.x > 0)
            {
                if (ballRelativePos.y > 0)
                {
                    angleToRotate = 45f;
                }
                else
                {
                    angleToRotate = 315f;
                }
            }
            else
            {
                if (ballRelativePos.y > 0)
                {
                    angleToRotate = 135f;
                }
                else
                {
                    angleToRotate = 225f;
                }
            }
            shield.DirectTowards(angleToRotate, 0.1f);
        }
    }
}