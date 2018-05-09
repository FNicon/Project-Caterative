using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour {
	public Image image;
	public float fadeInDuration;
	public float fadeOutDuration;
	public float waitDuration;
	public float waitStartDuration;
	public Color inColor;
	public Color outColor;
	public bool inFirst;
	public bool fadeInOnly;
	private float counter;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		if (inFirst) {
			image.color = outColor;
			//isFadeIn = true;
		}
		StartCoroutine(ChangeColor());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
	IEnumerator ChangeColor() {
		yield return new WaitForSeconds(waitStartDuration);
		if (inFirst) {
			image.DOColor(inColor,fadeInDuration);
			StartCoroutine(Wait());
		} else {
			StartCoroutine(Wait());
		}
	}
	IEnumerator Wait() {
		yield return new WaitForSeconds(waitDuration);
		if (!fadeInOnly) {
			if (inFirst) {
				image.DOColor(outColor,fadeOutDuration);
			} else {
				image.DOColor(outColor,fadeOutDuration);
			}
		}
	}
	void FadeIn () {
		image.color = Vector4.MoveTowards(image.color,inColor,Time.deltaTime / fadeInDuration);
	}
	void FadeOut() {
		image.color = Vector4.MoveTowards(image.color,outColor,Time.deltaTime / fadeOutDuration);
	}
}
