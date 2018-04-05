using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldShadowReposition : MonoBehaviour
    {
        public ShieldObject shield;
        public Vector3 shadowOffset;

        void Update()
        {
			transform.position = shield.transform.position + shadowOffset;
        }
    }
}
