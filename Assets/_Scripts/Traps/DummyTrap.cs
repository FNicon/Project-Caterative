using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrap : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			Debug.Log("Trap Triggered! -1");
		}
	}
}
