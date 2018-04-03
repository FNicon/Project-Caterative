using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public Sprite backgroundToRepeat;
    public GameObject background1;
    public GameObject background2;
    GameObject[] twoBackground;
    float spriteHeightInUnit;
    new Transform camera;

    void Awake()
    {
        camera = Camera.main.transform;
        spriteHeightInUnit = (backgroundToRepeat.rect.yMax - backgroundToRepeat.rect.yMin) / backgroundToRepeat.pixelsPerUnit;
        background1.GetComponent<SpriteRenderer>().sprite = backgroundToRepeat;
        background2.GetComponent<SpriteRenderer>().sprite = backgroundToRepeat;
        background1.transform.position = transform.position;
        background2.transform.position = new Vector2(0, background1.transform.position.y + spriteHeightInUnit);
        twoBackground = new GameObject[2];
        twoBackground[0] = background1;
        twoBackground[1] = background2;
    }

    void Update()
    {
        foreach (var bg in twoBackground)
        {
            if (bg.transform.position.y - camera.position.y > spriteHeightInUnit)
            {
                bg.transform.position = new Vector2(
                    0, bg.transform.position.y - (2 * spriteHeightInUnit)
                );
            }
            else if (bg.transform.position.y - camera.position.y < -1 * spriteHeightInUnit)
            {
                bg.transform.position = new Vector2(
                    0, bg.transform.position.y + (2 * spriteHeightInUnit)
                );
            }
        }
    }
}
