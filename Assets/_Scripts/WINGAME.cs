using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WINGAME : MonoBehaviour {
	public Caterative.Brick.TheShieldBoss.ShieldBoss shield;
	public GameObject WINPANEL;
	public GameObject LOSEPANEL;
	public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (shield.health <= 0) {
			WINPANEL.SetActive(true);
			LOSEPANEL.SetActive(false);
			player.isWin = true;
		}
	}
}
