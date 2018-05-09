using System.Collections;
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
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
}
