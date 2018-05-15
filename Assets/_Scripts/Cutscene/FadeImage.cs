using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {
	Image thisImage;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		thisImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void FadeIn(float duration) {
		//thisImage.GetComponent<CanvasRenderer> ().SetAlpha (0f);
		thisImage.CrossFadeAlpha (1f, duration, false);
	}
	public void FadeOut(float duration) {
		//thisImage.GetComponent<CanvasRenderer> ().SetAlpha (1f);
		thisImage.CrossFadeAlpha (0f, duration, false);
	}
	public void FadeToBlack(float duration) {
		thisImage.CrossFadeColor (Color.black, duration, false, true);
	}
	public void FadeToWhite(float duration) {
		thisImage.CrossFadeColor (Color.white, duration, false, true,true);
	}
	public void ChangeSourceImage(int next) {
		thisImage.sprite = sprites [next];
		thisImage.SetNativeSize ();
	}
	public IEnumerator FlashImage(float durationFade, float durationShow) {
		FadeIn (durationFade);
		yield return new WaitForSeconds(durationShow);
		FadeOut (durationFade);
	}
}
