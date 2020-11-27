using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class LevelManager : Singleton<LevelManager>
{
	[ReadOnly] public LevelData LevelDataLoaded;
	[ReadOnly] public bool LevelFinish = false;
	[ReadOnly] public bool LevelIsWinned = false;


	public void Load(LevelData levelToLoad)
	{
		LevelDataLoaded = levelToLoad;
		LevelFinish = false;
		LevelIsWinned = false;

		// Load Ship
		ShipManager.I.Load(LevelDataLoaded.ShipData);

		// UnLoad Probes
		ProbeManager.I.Load(LevelDataLoaded.ProbeData, LevelDataLoaded.ProbeCount);

		// Load Planets
		PlanetManager.I.Load(LevelDataLoaded.PlanetsToLoad);

		// Load Wormholes
		WormholeManager.I.Load(LevelDataLoaded.WormholeStart, LevelDataLoaded.WormholeEnd);

		// Load Items
		ItemManager.I.Load(LevelDataLoaded.itemsToLoad);

		// Load Gravity
		GravityManager.I.Load(levelToLoad.ConstantG);

		// Load Motion
		MotionManager.I.Load();

		// Load Interface
		CanvasManager.I.Load();

		// Launch Start Messages
		MessageManager.I.RemoveAllMessagesDisplayed();
		MessageManager.I.Post("Level " + LevelDataLoaded.IndexOfLevel.ToString(), "Bonne chance.", 5f);
		MessageManager.I.Post(LevelDataLoaded.MessagesOfLevel, MessageManager.I.TimeDisplayed, MessageManager.I.TimeBeforePost);
	}
	public void UnLoad()
	{
		LevelDataLoaded = null;
		LevelFinish = true;

		// UnLoad Gravity Component
		GravityManager.I.UnLoad();

		// UnLoad Motion
		MotionManager.I.UnLoad();

		// UnLoad Ship
		ShipManager.I.UnLoad();

		// UnLoad Probes
		ProbeManager.I.UnLoad();

		// UnLoad Planets
		PlanetManager.I.UnLoad();

		// UnLoad Wormholes
		WormholeManager.I.UnLoad();

		// UnLoad Items
		ItemManager.I.UnLoad();

		// UnLoad Interface
		CanvasManager.I.UnLoad();

		// Erase All Messages
		MessageManager.I.RemoveAllMessagesDisplayed();
	}

	public void WinLevel()
	{
		Debug.Log("Level WIN");
		CanvasManager.I.SetTextGameOver(true);

		LevelIsWinned = true;
		LevelFinish = true;
	}
	public void LostLevel()
	{
		Debug.Log("Level LOST");
		CanvasManager.I.SetTextGameOver(false);

		LevelIsWinned = false;
		LevelFinish = true;
	}
}
