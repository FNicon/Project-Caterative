using System;
using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.Balls;
using UnityEngine;

namespace Caterative.Brick.TheShieldBoss {
    public class Shield : MonoBehaviour, ICollidable {
        ShieldObject shieldObject;
        Animator shieldObjectAnimator;
        public float rotateFactor = 0.1f;
        new Collider2D collider;
        public bool boostDeflect;

        void Awake() {
            shieldObject = GetComponentInChildren<ShieldObject>();
            shieldObjectAnimator = shieldObject.GetComponent<Animator>();
            collider = GetComponent<Collider2D>();
        }

        void ICollidable.OnCollideWithBall(Ball ball) {
            shieldObjectAnimator.SetBool("isHit", true);
        }

        public void DirectTowards(float angle) {
            StopAllCoroutines();
            StartCoroutine(RotateCoroutine(angle));
        }

        private IEnumerator RotateCoroutine(float targetAngle) {
            float currentAngle, clampedAngle, angleToRotate;
            do {
                currentAngle = transform.rotation.eulerAngles.z > 0 ? transform.rotation.eulerAngles.z % 360 : transform.rotation.eulerAngles.z + 360;
                if (Mathf.Abs(currentAngle - targetAngle) > 0.01f) {
                    clampedAngle = targetAngle % 360;
                    if (Mathf.Abs(transform.rotation.eulerAngles.z - clampedAngle) < 180) {
                        angleToRotate = (clampedAngle - transform.rotation.eulerAngles.z) * rotateFactor;
                    } else {
                        angleToRotate = (clampedAngle - (transform.rotation.eulerAngles.z - 360)) * rotateFactor;
                    }
                    transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + angleToRotate);
                    yield return new WaitForEndOfFrame();
                }
            } while (Mathf.Abs(currentAngle - targetAngle) > 0.1f);
        }

        internal void DirectTowards(float angle, float rotateFactor) {
            this.rotateFactor = rotateFactor;
            DirectTowards(angle);
        }

        public void setBoostDeflect(bool cond) {
            boostDeflect = cond;
        }
    }
}