using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatGallery : MonoBehaviour {
	public CatType[] catsList;
	public GameObject galleryObjectTemplate;
	public List<GameObject> galleryObjects;
	public Sprite unknownSpriteTemplate;
	// Use this for initialization
	void Start () {
		CreateGallery();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateGallery() {
		for (int i=0; i < catsList.Length; i++) {
			galleryObjects.Add(Instantiate(galleryObjectTemplate,transform.position,transform.rotation));
			galleryObjects[i].transform.SetParent(transform);
			galleryObjects[i].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
			if (catsList[i].isAlreadySaved) {
				galleryObjects[i].GetComponentsInChildren<Image>()[1].sprite = catsList[i].catSprite;
				galleryObjects[i].GetComponentInChildren<Text>().text = catsList[i].catName;
			} else {
				galleryObjects[i].GetComponentsInChildren<Image>()[1].sprite = unknownSpriteTemplate;
				galleryObjects[i].GetComponentsInChildren<Image>()[1].color = new Vector4(0,0,0,255);
				galleryObjects[i].GetComponentInChildren<Text>().text = "unknown";
			}
		}
	}
}
