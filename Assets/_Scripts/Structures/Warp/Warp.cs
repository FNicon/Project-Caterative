using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.Warp
{
    public class Warp : MonoBehaviour
    {
        public GameObject destination;

        void OnTriggerEnter2D(Collider2D collider)
        {
            Warpable warped = collider.GetComponent<Warpable>();
            if (warped != null)
            {
                if (warped.state == Warpable.State.Incoming)
                {
                    warped.transform.position = destination.transform.position;
                }
                warped.Warp();
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            Warpable warped = collider.GetComponent<Warpable>();
            if (warped != null)
            {
                warped.Warp();
            }
        }
    }
}