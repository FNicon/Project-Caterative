using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeViewer : MonoBehaviour {
	public Slider lifeSlider;
	public PlayerLife playerLife;
	public Image sliderImage;
	public Color redColor;
	public float redRange;
	// Use this for initialization
	void Start () {
		lifeSlider.value = playerLife.currentLife;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSlider.value = playerLife.currentLife;
		if (playerLife.currentLife <= redRange) {
			sliderImage.color = redColor;
		}
	}
}
