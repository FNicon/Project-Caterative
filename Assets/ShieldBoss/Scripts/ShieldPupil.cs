using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.Balls;
using UnityEngine;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldPupil : MonoBehaviour
    {
        public Transform pupilTarget;
        public Vector2 targetPositionThreshold = new Vector2(1f, 1.5f);
        public Vector2 maxPupilPosition = new Vector2(0.075f, 0.02f);
        SpriteRenderer sprite;
        private Vector3 originalPosition;
        public Sprite annoyedPupil;
        public Sprite angryPupil;
        public Sprite hurtPupil;
        public Sprite happyPupil;
        State state;
        float hurtTimer;
        public float hurtTime = 0.4f;

        void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            originalPosition = transform.position;
            hurtTimer = 0;
        }

        void OnEnable()
        {
            ShieldBoss.OnStateChange += ResolveStateChange;
        }

        void OnDisable()
        {
            ShieldBoss.OnStateChange -= ResolveStateChange;
        }

        private void ResolveStateChange(ShieldBoss boss)
        {
            state = boss.state;
        }

        void Update()
        {
            if (hurtTimer > 0)
            {
                hurtTimer -= Time.deltaTime;
            }
            switch (state)
            {
                case State.Annoyed:
                    if (hurtTimer <= 0)
                    {
                        SetTarget();
                        SetSprite(annoyedPupil);
                        PupilFollowTargetUpdate();
                    }
                    break;
                case State.Hurt:
                    if (hurtTimer <= 0)
                    {
                        hurtTimer = hurtTime;
                    }
                    ReleaseTarget();
                    SetSprite(hurtPupil);
                    break;
                case State.Happy:
                    if (hurtTimer <= 0)
                    {
                        ReleaseTarget();
                        SetSprite(happyPupil);
                    }
                    break;
                case State.Angry:
                    if (hurtTimer <= 0)
                    {
                        SetTarget();
                        SetSprite(angryPupil);
                        PupilFollowTargetUpdate();
                    }
                    break;
                default:
                    break;
            }
        }

        private void ReleaseTarget()
        {
            transform.position = originalPosition;
            pupilTarget = null;
        }

        private void PupilFollowTargetUpdate()
        {
            Vector2 relativeTargetPosition = pupilTarget.position - transform.position;
            transform.localPosition = new Vector2(
                maxPupilPosition.x * (
                    Mathf.Abs(relativeTargetPosition.x) > targetPositionThreshold.x ?
                    Mathf.Sign(relativeTargetPosition.x) * targetPositionThreshold.x :
                    relativeTargetPosition.x
                    / targetPositionThreshold.x),
                maxPupilPosition.y * (
                Mathf.Abs(relativeTargetPosition.y) > targetPositionThreshold.y ?
                Mathf.Sign(relativeTargetPosition.y) * targetPositionThreshold.y :
                relativeTargetPosition.y
                / targetPositionThreshold.y)
            );
        }

        public void SetTarget()
        {
            if (pupilTarget == null)
            {
                if (GameManager.Instance.GetBall().active)
                {
                    this.pupilTarget = GameManager.Instance.GetBall().transform;
                }
                else
                {
                    this.pupilTarget = GameManager.Instance.GetAim().transform;
                }
            }
        }

        public void SetSprite(Sprite sprite)
        {
            this.sprite.sprite = sprite;
        }
    }
}