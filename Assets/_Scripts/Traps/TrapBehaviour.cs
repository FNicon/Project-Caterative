using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
	public TrapType trapType;
	public void SpreadTrap()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1,1);
		/*for (int i=0; i < trapType.trapComponents.Length; i++)
		{
			GameObject trap = Instantiate(trapType.trapComponents[i],this.transform.position,this.transform.rotation);
			trap.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0,i),Random.Range(0,i));
		}*/
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			transform.position = new Vector2(-7,0);
			Debug.Log("Trap Triggered! -1");
		}
	}
}
