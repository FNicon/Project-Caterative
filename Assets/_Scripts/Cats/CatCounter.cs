using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatCounter : MonoBehaviour {
	public Text catText;
	int catAmount;
	// Use this for initialization
	void Start () {
		UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddCat() {
		catAmount = catAmount + 1;
		UpdateText();
	}
	
	void UpdateText() {
		catText.text = "Cat : " + catAmount.ToString();
	}
}
