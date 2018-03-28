using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDropper : MonoBehaviour {
	public GameObject[] thingsToDrop;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void DropAll()
	{
		for (int i = 0; i < thingsToDrop.Length; i++)
		{
			thingsToDrop[i].transform.position = transform.position;
		}
	}
}
