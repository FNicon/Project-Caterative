using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldBossFigure : MonoBehaviour
    {
        Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
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
            switch (boss.state)
            {
                case State.Hurt:
                    Hit();
                    break;
                default:
                    break;
            }
        }

        public void Hit()
        {
            animator.SetBool("isFigureHit", true);
        }
    }
}