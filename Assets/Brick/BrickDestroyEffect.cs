using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroyEffect : MonoBehaviour {
	public GameObject brickDestroyParticle;
	public GameObject brickOutlineExplosion;

    internal void Play(Vector3 onThisLocation)
    {
        Instantiate(brickDestroyParticle,onThisLocation,Quaternion.identity);
		Instantiate(brickOutlineExplosion,onThisLocation,Quaternion.identity);
    }
}
