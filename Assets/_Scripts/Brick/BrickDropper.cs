using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDropper : MonoBehaviour
{
	public GameObject[] thingsToDrop;
	public void DropAll()
	{
		for (int i = 0; i < thingsToDrop.Length; i++)
		{
			thingsToDrop[i].transform.position = transform.position;
		}
	}
}
