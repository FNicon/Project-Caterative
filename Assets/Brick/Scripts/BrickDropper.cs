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
			if (thingsToDrop[i].GetComponent<CatBehaviour>() != null) {
				thingsToDrop[i].GetComponent<CatBehaviour>().isInArena = true;
			}
			if (thingsToDrop[i].GetComponent<TrapSpawner>() != null) {
				thingsToDrop[i].GetComponent<TrapSpawner>().SpreadTrap();
			}
		}
	}
}
