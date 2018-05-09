using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class PlayerHurtEffects : MonoBehaviour {
	public float shakeMagnitude;
	public float shakeRoughness;
	public float shakeFadeInTime;
	public float shakeFadeOutTime;
	public SpriteRenderer playerSprite;
	public Image redEffect;
	public Color hurtColor;
	public Color originalColor;
	private Color newColor;
	private float countDown;
	public float colorChangePerSecond;
	// Use this for initialization
	void Start () {
		redEffect.enabled = false;
		originalColor = playerSprite.color;
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void HurtEffect() {
		StartCoroutine(HurtFadeIn());
		CameraShaker.Instance.ShakeOnce(shakeMagnitude,shakeRoughness,shakeFadeInTime,shakeFadeOutTime);
	}
	bool IsPlayerHurtColor() {
		return ((playerSprite.color.r == hurtColor.r) && (playerSprite.color.g == hurtColor.g) &&
				(playerSprite.color.b == hurtColor.b) && (playerSprite.color.a == hurtColor.a));
	}
	bool IsPlayerOriginalColor() {
		return ((playerSprite.color.r == originalColor.r) && (playerSprite.color.g == originalColor.g) &&
				(playerSprite.color.b == originalColor.b) && (playerSprite.color.a == originalColor.a));
	}
	bool IsPlayerNewColor() {
		return ((playerSprite.color.r == newColor.r) && (playerSprite.color.g == newColor.g) &&
				(playerSprite.color.b == newColor.b) && (playerSprite.color.a == newColor.a));
	}
	IEnumerator HurtFadeOut() {
		newColor = originalColor;
		redEffect.enabled = false;
		StartCoroutine(Fade(shakeFadeInTime));
		yield return new WaitUntil(IsPlayerOriginalColor);
	}
	IEnumerator Fade(float time) {
		yield return new WaitForSeconds(0.1f);
		playerSprite.color = Vector4.MoveTowards(playerSprite.color,newColor,Time.deltaTime*colorChangePerSecond);
		if (!IsPlayerNewColor()) {
			StartCoroutine(Fade(time));
		}
	}
	IEnumerator HurtFadeIn() {
		newColor = hurtColor;
		redEffect.enabled = true;
		StartCoroutine(Fade(shakeFadeInTime));
		yield return new WaitUntil(IsPlayerHurtColor);
		StartCoroutine(HurtFadeOut());
	}
}
