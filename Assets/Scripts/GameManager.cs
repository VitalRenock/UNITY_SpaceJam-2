using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;


public class GameManager : Singleton<GameManager>
{
	[ReadOnly] public List<LevelData> LevelsToLoad;

	private void Start()
	{
		StartCoroutine(GameLoop());
	}
	private void Update()
	{
		// For Debug
		if (Input.GetKeyDown(KeyCode.F1))	// Reload Game
			SceneManager.LoadScene("SampleScene");
		if (Input.GetKeyDown(KeyCode.F2))	// Win current level
			LevelManager.I.WinLevel();
		if (Input.GetKeyDown(KeyCode.F3))
			Application.Quit();
	}

	IEnumerator GameLoop()
	{
		Debug.Log("GAME STARTED");

		foreach (LevelData level in LevelsToLoad)
			yield return LevelLoop(level);

		Debug.Log("GAME FINISHED");
		Application.Quit();
	}
	IEnumerator LevelLoop(LevelData levelData)
	{
		Debug.Log(levelData.IndexOfLevel.ToString());
		LevelManager.I.Load(levelData);

		while (!LevelManager.I.LevelFinish)
			yield return null;

		Debug.Log("LevelFinish");
		LevelManager.I.UnLoad();

		yield return new WaitForSeconds(1);
	}
}
