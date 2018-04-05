using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectStatus : MonoBehaviour {
	public bool isStun;
	public SpriteRenderer stunView;
	// Use this for initialization
	void Awake ()
	{
		stunView.enabled = false;
		isStun = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public IEnumerator StunPlayer(float stunTime)
	{
		isStun = true;
		stunView.enabled = true;
		//playerBody.velocity = new Vector2(0,0);
		yield return new WaitForSeconds(stunTime);
		isStun = false;
		stunView.enabled = false;
	}
}
