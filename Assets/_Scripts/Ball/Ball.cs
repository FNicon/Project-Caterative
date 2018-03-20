using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.Balls
{
    public class Ball : MonoBehaviour
    {
        public float maxSpeed;
        public float minSpeed;
        public int speedIterator;
        private Rigidbody2D ballBody;
		private TrailRenderer trail;
		public bool active {get; protected set;}

        void Awake()
        {
            ballBody = GetComponent<Rigidbody2D>();
			trail = GetComponentInChildren<TrailRenderer>();
			active = false;
        }

        void FixedUpdate()
        {
            if ((Mathf.Abs(ballBody.velocity.x) > maxSpeed) || (Mathf.Abs(ballBody.velocity.y) > maxSpeed))
            {
                ballBody.velocity = maxSpeed * (ballBody.velocity.normalized);
                speedIterator = 0;
            }
            else if ((ballBody.velocity.x < minSpeed) || (ballBody.velocity.y < minSpeed))
            {
                ballBody.velocity = (minSpeed + speedIterator) * (ballBody.velocity.normalized);
                speedIterator = speedIterator + 1;
            }
            else
            {
                ballBody.velocity = new Vector2(ballBody.velocity.x, ballBody.velocity.y);
            }
            if (speedIterator > 10)
            {
                speedIterator = 0;
            }
        }

        public void LaunchTowardsAngle(float initialSpeed, float direction)
        {
			active = true;
			trail.enabled = true;
            Vector2 directionVector = VectorRotation.RotateVector(Vector2.right, direction);
            Vector2 launchVelocity = (directionVector * initialSpeed);
            ballBody.velocity = launchVelocity;
        }

		public void Deactivate() {
			active = false;
			trail.enabled = false;
		}

        void OnCollisionEnter2D(Collision2D collision) {
            ICollidable collidable = collision.gameObject.GetComponent<ICollidable>();
            if (collidable != null) {
                BallManager.Instance.InvokeOnBallCollide(this,collidable);
            }
        }

		void OnTriggerEnter2D(Collider2D collider) {
			ICollidable collidable = collider.gameObject.GetComponent<ICollidable> ();
			if (collidable != null) {
				BallManager.Instance.InvokeOnBallTrigger(this,collidable);
			}
		}
    }
}