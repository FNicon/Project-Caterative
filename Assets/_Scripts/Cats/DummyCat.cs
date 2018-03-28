using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCat : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Cat Saved! +1");
		}
	}
}
