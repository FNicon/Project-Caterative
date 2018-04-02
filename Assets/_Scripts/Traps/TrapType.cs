using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trap Type", menuName = "Trap Type/new Trap Type", order = 1)]
public class TrapType : ScriptableObject {
	public Sprite trapSprites;
	public bool isDamage;
	public bool isStun;
}
