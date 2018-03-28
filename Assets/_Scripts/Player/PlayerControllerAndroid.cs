using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAndroid : MonoBehaviour
{

    public Camera mainCamera;
    private bool isDragging;
    private float distance;
    private Vector3 offset;
    private Transform player;
    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 ReadInput()
    {
        float camDistance = Camera.main.transform.position.z;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Mathf.Abs(camDistance)));
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Player"))
                {
                    return (Vector2)touchedPos;
                }
                else
				{
					float followTouchX = Mathf.Lerp(transform.position.x, touchedPos.x, 0.3f);
					float followTouchY = Mathf.Lerp(transform.position.y, touchedPos.y, 0.3f);
					return new Vector2(followTouchX, followTouchY);
				}
            }
            else
                return (Vector2)transform.position;
        }
        else
            return (Vector2)transform.position;
    }
    /*
    Touch touch = Input.touches [0];
    Vector3 pos = touch.position;
    if (touch.phase == TouchPhase.Began) {
        ray = Camera.main.ScreenPointToRay (pos);
        if (Physics.Raycast (ray, out hit) && (hit.collider.tag == "Player")) {
            player = hit.transform;
            distance = hit.transform.position.z - Camera.main.transform.position.z;
            v3 = new Vector3 (pos.x, pos.y, distance);
            v3 = Camera.main.ScreenToWorldPoint (v3);
            offset = player.position - v3;
            isDragging = true;
            return (new Vector2 (0, 0));
        }*/

}
