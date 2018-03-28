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

        void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            
        }

        void Update()
        {
            if (GameManager.Instance.GetBall().active)
            {
                SetTarget(GameManager.Instance.GetBall().transform);
            } else
            {
                SetTarget(GameManager.Instance.GetAim().transform);
            }
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

        public void SetTarget(Transform target)
        {
            this.pupilTarget = target;
        }

        public void SetSprite(Sprite sprite)
        {
            this.sprite.sprite = sprite;
        }
    }
}