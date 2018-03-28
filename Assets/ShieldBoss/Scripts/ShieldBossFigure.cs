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

        public void Hit()
        {
            animator.SetBool("isFigureHit", true);
        }
    }
}