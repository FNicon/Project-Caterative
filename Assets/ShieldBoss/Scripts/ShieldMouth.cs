using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Caterative.Brick.TheShieldBoss {
    public class ShieldMouth : MonoBehaviour {
        SpriteRenderer sprite;

        void Awake() {
            sprite = GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite) {
            this.sprite.sprite = sprite;
        }
    }
}