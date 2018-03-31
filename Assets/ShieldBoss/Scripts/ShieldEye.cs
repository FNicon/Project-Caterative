using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Caterative.Brick.TheShieldBoss
{
	public class ShieldEye : MonoBehaviour
	{
		SpriteRenderer sprite;
		SpriteMask mask;

		void Awake()
		{
			sprite = GetComponent<SpriteRenderer>();
			mask = GetComponent<SpriteMask>();
		}

		public void SetSprite(Sprite sprite)
		{
			this.sprite.sprite = sprite;
			mask.sprite = sprite;
		}
	}
}