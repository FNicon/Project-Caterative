using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Caterative.Brick.Balls;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldBoss : MonoBehaviour
    {
        Shield shield;
        public int health = 60;
        public int subStateLength = 3;
        public int annoyedStateLength = 2;
        public int angryStateLength = 1;
        private State m_state;
        public State state
        {
            get
            {
                return this.m_state;
            }
            set
            {
                this.m_state = value;
                InvokeOnStateChange();
            }
        }
        public Ball targetBall;
        int redirectShieldCounter = 0;
        int stateCounter;
        public float moveDistancePerSecond = 2;
        public float happyRotationPerSecond = 25;
        public delegate void StateEvent(ShieldBoss boss);
        public static event StateEvent OnStateChange;
        private void InvokeOnStateChange()
        {
            if (OnStateChange != null)
            {
                OnStateChange(this);
            }
        }

        void Awake()
        {
            shield = GetComponentInChildren<Shield>();
        }

        void OnEnable()
        {
            BallDestroyer.OnBallDestroy += UpdateStateOnBallDestroy;
        }

        void OnApplicationQuit()
        {
            BallDestroyer.OnBallDestroy -= UpdateStateOnBallDestroy;
        }

        void Start()
        {
            shield.DirectTowards(225f);
            state = State.Annoyed;
        }

        void Update()
        {
            if (targetBall != null)
            {
                switch (state)
                {
                    case State.Angry:
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
                        break;
                    case State.Happy:
                        shield.transform.Rotate(0, 0, happyRotationPerSecond * Time.deltaTime);
                        break;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                targetBall = collision.collider.GetComponent<Ball>();
                UpdateBossStateOnBallCollide();
                health--;
                ResolveCurrentStateOnBallCollide(targetBall);
                stateCounter++;
                if (health <= 0)
                {
                    Deactivate();
                }
                StopAllCoroutines();
                StartCoroutine(InvokeTemporalHurtState(state));
            }
        }

        private IEnumerator InvokeTemporalHurtState(State previousState)
        {
            state = State.Hurt;
            yield return new WaitForSeconds(0f); //TODO resolve quick state change
            state = previousState;
        }

        private void Deactivate()
        {
            transform.position = new Vector2(-10, 100);
        }

        private void UpdateStateOnBallDestroy(Ball whichBall)
        {
            if (BallManager.Instance.CountActiveBall() == 0)
            {
                state = State.Happy;
            }
        }

        private void UpdateBossStateOnBallCollide()
        {
            switch (state)
            {
                case State.Happy:
                    state = State.Annoyed;
                    break;
                case State.Annoyed:
                    if (stateCounter >= annoyedStateLength * subStateLength)
                    {
                        stateCounter = 0;
                        state = State.Angry;
                    }
                    break;
                case State.Angry:
                    if (stateCounter >= angryStateLength * subStateLength)
                    {
                        stateCounter = 0;
                        state = State.Annoyed;
                    }
                    break;
            }
        }

        private void ResolveCurrentStateOnBallCollide(Ball ball)
        {
            switch (state)
            {
                case State.Annoyed:
                    RedirectShieldTowardsBall(ball);
                    AnnoyedMode(ball);
                    break;
                case State.Angry:
                    AngryShieldMode(ball);
                    break;
            }
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