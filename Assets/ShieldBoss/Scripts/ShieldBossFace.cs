using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.TheShieldBoss {
	public class ShieldBossFace : MonoBehaviour {
		public Sprite annoyedEye;
		public Sprite annoyedPupil;
		public Sprite annoyedMouth;
		
		public Sprite angryEye;
		public Sprite angryMouth;
		public Sprite angryPupil;
		public Sprite hurtEye;
		public Sprite hurtMouth;
		public Sprite surpriseHappyEye;
		public Sprite surpriseHappyMouth;
		public Sprite happyEye;
		public Sprite happyMouth;

		ShieldEye eye;
		ShieldPupil pupil;
		ShieldMouth mouth;

		void Awake() {
			eye = GetComponentInChildren<ShieldEye>();
			pupil = GetComponentInChildren<ShieldPupil>();
			mouth = GetComponentInChildren<ShieldMouth>();
		}

		public void SetHurtFace(State bossState) {
			StopAllCoroutines();
			StartCoroutine(HurtFaceCoroutine(bossState));
		}

		public IEnumerator HurtFaceCoroutine(State bossState) {
			eye.SetSprite(hurtEye);
			pupil.SetSprite(null);
			mouth.SetSprite(hurtMouth);
			yield return new WaitForSeconds(0.4f);
			switch(bossState) {
				case State.Angry:
					SetAngryFace();
					break;
				case State.Annoyed:
					SetAnnoyedFace();
					break;
			}
		}

		public void SetAnnoyedFace() {
			eye.SetSprite(annoyedEye);
			pupil.SetSprite(annoyedPupil);
			pupil.maxPupilPosition = new Vector2(0.075f,0.01f);
			mouth.SetSprite(annoyedMouth);
		}

		public void SetAngryFace() {
			eye.SetSprite(angryEye);
			pupil.SetSprite(angryPupil);
			pupil.maxPupilPosition = new Vector2(0.05f,0.008f);
			mouth.SetSprite(angryMouth);
		}

		public void SetSurpriseHappyFace() {
			StopAllCoroutines();
			StartCoroutine(SurpriseHappyFaceCoroutine());
		}

		public IEnumerator SurpriseHappyFaceCoroutine() {
			eye.SetSprite(surpriseHappyEye);
			pupil.SetSprite(null);
			mouth.SetSprite(surpriseHappyMouth);
			yield return new WaitForSeconds(1f);
			SetHappyFace();
		}

		public void SetHappyFace() {
			eye.SetSprite(happyEye);
			pupil.SetSprite(null);
			mouth.SetSprite(happyMouth);
		}
	}
}