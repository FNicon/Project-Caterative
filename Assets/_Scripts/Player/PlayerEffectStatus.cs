using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectStatus : MonoBehaviour {
	private bool isStun;
	public SpriteRenderer stunView;
	public AudioSource stunSFX;
	// Use this for initialization
	void Awake ()
	{
		stunView.enabled = false;
		isStun = false;
	}
	public bool IsCurrentlyStun() {
		return (isStun);
	}
	public IEnumerator StunPlayer(float stunTime)
	{
		isStun = true;
		stunView.enabled = true;
		stunSFX.Play();
		//playerBody.velocity = new Vector2(0,0);
		yield return new WaitForSeconds(stunTime);
		isStun = false;
		stunView.enabled = false;
	}
}
