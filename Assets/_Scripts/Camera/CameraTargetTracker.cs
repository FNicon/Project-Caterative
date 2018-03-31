using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetTracker : MonoBehaviour
{
    List<GameObject> targets;
    public Path cameraPath;
    new private Transform camera;

    void Awake()
    {
        camera = Camera.main.transform;
        targets = new List<GameObject>();
        if (cameraPath == null)
        {
            Debug.LogError("[CameraTargetTracker] Camera Path object is null! IF IN DOUBT, put, in the scene, the example prefab found in the _Prefabs and assign it to CameraTargetTracker script!");
        }
    }

    void OnEnable()
    {
        //Player harusnya tetap bisa bergerak meskipun ada brick. Brick ini kan kayak chest gitu. Ada yang ngasih trap, kosong maupun kucing.
        /*foreach (var brick in Resources.FindObjectsOfTypeAll<Brick>())
        {
            targets.Add(brick.gameObject);
        }*/
        /*
        ShieldBoss shieldBoss = FindObjectOfType<ShieldBoss>();
        if (shieldBoss !=null)
        {
            targets.Add(shieldBoss.gameObject);
        }
        */
        for (int i = 0; i < cameraPath.pathNodes.Length - 1; i++)
        {
            targets.Add(cameraPath.pathNodes[i].gameObject);
        }
        TargetDetectionArea targetArea = FindObjectOfType<TargetDetectionArea>();
        if (targetArea != null)
        {
            targets.Add(targetArea.gameObject);
        }
        CameraEnd end = FindObjectOfType<CameraEnd>();
        if (end != null)
        {
            targets.Add(end.gameObject);
        }
    }

    public GameObject GetClosestTarget()
    {
        if (targets.Count > 0)
        {
            GameObject closestTarget = null;
            for (int i = 0; i < targets.Count; i++)
            {

                if (ResolveTarget(closestTarget, i))
                {
                    closestTarget = targets[i];
                }
            }
            return closestTarget;
        }
        else
        {
            return null;
        }
    }

    private bool ResolveTarget(GameObject closestTarget, int i)
    {
        if (closestTarget == null && targets[i].activeSelf == true) {
            return true;
        } else {
            return targets[i].activeSelf == true
                    && Vector2.Distance(targets[i].transform.position, camera.position)
                       < Vector2.Distance(closestTarget.transform.position, camera.position);   
        }
    }
}
