using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Vector2 ReadInput()
	{
		Vector2 movement;
		movement = new Vector2 (Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));
		return movement;
	}

	public bool IsInputFire()
	{
		return (Input.GetAxis("Jump") != 0);
	}
}
