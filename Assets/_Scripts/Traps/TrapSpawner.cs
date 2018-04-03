using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
	public GameObject objectTrap;
	public void SpreadTrap()
	{
		GameObject trap = Instantiate(objectTrap,this.transform.position,this.transform.rotation);
		Debug.Log("Once!");
		//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1,1);
		/*for (int i=0; i < trapType.trapComponents.Length; i++)
		{
			GameObject trap = Instantiate(trapType.trapComponents[i],this.transform.position,this.transform.rotation);
			trap.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0,i),Random.Range(0,i));
		}*/
	}
}
