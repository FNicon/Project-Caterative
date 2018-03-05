using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.Balls
{
    public interface ICollidable
    {
        void OnCollideWithBall(Ball ball);
    }
}