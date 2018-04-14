using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSFX : MonoBehaviour {
	public AudioSource collisionAudio;
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Ball"))
		{
			collisionAudio.Play();
		}
	}
	
}
