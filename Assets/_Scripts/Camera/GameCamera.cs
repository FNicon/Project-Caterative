using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {
	public GameObject player;
	public GameObject border;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f,-10);
		player.transform.position = new Vector2(player.transform.position.x,this.transform.position.y - 5);
		border.transform.position = new Vector2(border.transform.position.x,this.transform.position.y);
	}
}
