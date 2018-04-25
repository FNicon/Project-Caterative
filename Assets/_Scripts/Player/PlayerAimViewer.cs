using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAimViewer : MonoBehaviour {
    public Vector2 startLaunchLocation;
    public Vector2 targetLaunchLocation;
	public LineRenderer targetLine;
    public float launchDirection;
	public Slider reloadSlider;
	void Awake()
    {
        targetLine = GetComponentInChildren<LineRenderer>();
        targetLine.positionCount = 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	
    public void UpdateLaunchDirection()
    {
        //targetLine.positionCount = 2;
        launchDirection = 90 + ((transform.position.x / 2) * -45);
        startLaunchLocation = new Vector2(
            transform.position.x * 1.25f,
            transform.position.y + 0.5f);
        targetLine.SetPosition(0, startLaunchLocation);
        Vector2 launchVector = VectorRotation.RotateVector(Vector2.right, launchDirection);
        int layerMask = LayerMask.GetMask("Bricks", "Balls");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, launchVector, 20, layerMask);
        if (hit.collider != null)
        {
            targetLaunchLocation = hit.point;
        } else
        {
            targetLaunchLocation = startLaunchLocation + (launchVector * 20);
        }
        targetLine.SetPosition(1, targetLaunchLocation);
    }
	public void UpdateCoolDown(float cooldownCount, float cooldownTime) {
		reloadSlider.value = cooldownCount/cooldownTime;
	}
}
