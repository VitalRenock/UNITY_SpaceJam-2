using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
	public SpriteRenderer Background;
	public Text TextExitDistance;
	public Text TextShipRotation;
	public Text TextProbeCount;
	public Text TextGameOver;


	public void Load()
	{
		Background.gameObject.SetActive(true);
		TextExitDistance.gameObject.SetActive(true);
		TextShipRotation.gameObject.SetActive(true);
		TextProbeCount.gameObject.SetActive(true);
		TextGameOver.gameObject.SetActive(false);

		SetTextShipRotation(ShipManager.I.ShipDataLoaded.GameObjectLoaded.transform.eulerAngles.z);
		SetTextProbeCount(ProbeManager.I.ProbesCount);
	}
	public void UnLoad()
	{
		Background.gameObject.SetActive(false);
		TextExitDistance.gameObject.SetActive(false);
		TextShipRotation.gameObject.SetActive(false);
		TextProbeCount.gameObject.SetActive(false);
		TextGameOver.gameObject.SetActive(true);
	}

	public void SetTextExitDistance(float distance)
	{
		if (distance > 100)
			TextExitDistance.color = Color.red;
		else
			TextExitDistance.color = Color.Lerp(Color.green, Color.red, distance * 0.01f);

		TextExitDistance.text = "Exit distance: " + distance.ToString();
	}
	public void SetTextShipRotation(float rotation)
	{
		TextShipRotation.text = "Ship Rotation: " + rotation.ToString() + "°";
	}
	public void SetTextProbeCount(float probeCount)
	{
		TextProbeCount.text = "Probes count: " + ProbeManager.I.ProbesCount.ToString();
	}
	public void SetTextGameOver(bool IsWinned)
	{
		if (IsWinned)
		{
			TextGameOver.color = Color.green;
			TextGameOver.text = "Level " + LevelManager.I.LevelDataLoaded.IndexOfLevel.ToString() + " WIN!";
		}
		else
		{
			TextGameOver.color = Color.red;
			TextGameOver.text = "Level " + LevelManager.I.LevelDataLoaded.IndexOfLevel.ToString() + " Lost...";
		}
	}
}
