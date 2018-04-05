using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	public TrapType trapType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			if (other.transform.GetComponent<Player>()!=null) {
				PlayerEffectStatus playerData = other.transform.GetComponent<PlayerEffectStatus>();
				if (!playerData.IsCurrentlyStun()) {
					playerData.StartCoroutine(playerData.StunPlayer(trapType.stunTime));
				}
			}
			transform.position = new Vector2(-7,0);
		}
	}
}
