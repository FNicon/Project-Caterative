using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Cat Type", menuName = "Cat Type/new Cat Type", order = 1)]
public class CatType : ScriptableObject
{
	public string catName;
	public Sprite catSprite;
	public Sprite[] catImages;
	[TextArea(3, 10)]
    public string catStory;
	public bool isAlreadySaved;
}
