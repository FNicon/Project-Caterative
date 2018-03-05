using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.TheShieldBoss;
using UnityEngine;

public class CameraTargetTracker : MonoBehaviour
{
    List<GameObject> targets;

    void Awake()
    {
		targets = new List<GameObject>();
    }

	void OnEnable() {
		foreach (var brick in Resources.FindObjectsOfTypeAll<Brick>())
        {
            targets.Add(brick.gameObject);
        }
        foreach (var ShieldBoss in Resources.FindObjectsOfTypeAll<ShieldBoss>())
        {
            targets.Add(ShieldBoss.gameObject);
        }
	}

    public GameObject GetClosestTarget()
    {
        GameObject closestTarget = targets[0];
        for (int i = 1; i < targets.Count; i++)
        {
            if (targets[i].transform.position.y < closestTarget.transform.position.y)
            {
				closestTarget = targets[i];
            }
        }
        return closestTarget;
    }
}
