using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.Warp
{
    public class Warpable : MonoBehaviour
    {
        public enum State
        {
            Incoming,
            WarpingOut,
            WarpingIn,
            Outgoing
        }
        public State state { get; private set; }

        void Start()
        {
            state = State.Incoming;
        }

        public void Warp()
        {
            switch (state)
            {
                case State.Incoming:
                    state = State.WarpingIn;
                    break;
                case State.WarpingIn:
                    state = State.WarpingOut;
                    break;
                case State.WarpingOut:
                    state = State.Outgoing;
                    break;
                case State.Outgoing:
                    state = State.Incoming;
                    break;
                default:
                    state = State.Incoming;
                    break;
            }
        }
    }
}