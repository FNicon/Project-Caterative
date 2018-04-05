using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
	public SpriteRenderer catSprite;
	public bool isInArena;
	public CatType cat;
	private Rigidbody2D catBody;
	public float xSpeed;
	public CatCounter counter;
	private void Awake()
	{
		catBody = gameObject.GetComponent<Rigidbody2D>();
		catSprite.sprite = cat.catSprite;
	}
	private void Update()
	{
		if (isInArena) {
			CatMovements();
		}
	}
	public void Summon() {
		isInArena = true;
	}
	private void CatMovements() {
		catBody.velocity = new Vector2(xSpeed, 0);
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		Collider2D otherCollider = other.collider;
		if (otherCollider.CompareTag("Player"))
		{
			transform.position = new Vector2(-7,0);
			if (!cat.isAlreadySaved) {
				isInArena = false;
				counter.AddCat();
				cat.isAlreadySaved = true;
			}
		} else {
			if (isInArena) {
				xSpeed = -xSpeed;
			}
		}
	}
}
