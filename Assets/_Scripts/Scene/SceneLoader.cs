﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
	public void Play(string sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
	}
	public void ExitGame()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
			Application.Quit();
	}
}
