using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class CameraManager : Singleton<CameraManager>
{
	/*[ReadOnly]*/ public Camera MainCamera;
	/*[ReadOnly]*/ public bool FollowMode = false;
	/*[ReadOnly]*/ public float SpeedTranslation = 1f;

	/*[ReadOnly]*/ public float ZoomCamera;
	/*[ReadOnly]*/ public float MinimumZoom;
	/*[ReadOnly]*/ public float MaximumZoom;
	/*[ReadOnly]*/ public float ZoomOnStart;
	/*[ReadOnly]*/ [Range(0.01f, 100)] public float ZoomMultiplicator;

	/*[ReadOnly]*/ public TrailRenderer trailTest;


	//private void Awake()
	//{
	//	MainCamera = Camera.main;
	//}
	private void Start()
	{
		// Set Zoom on start.
		MainCamera.orthographicSize = ZoomOnStart;
		ZoomCamera = MainCamera.orthographicSize;
	}
	private void Update()
	{
		if (LevelManager.I.LevelFinish)
			return;

		// Update Zoom.
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			ZoomCamera += -Input.GetAxis("Mouse ScrollWheel") * ZoomMultiplicator;
			trailTest.widthMultiplier = ZoomCamera / 100f;

			if (ZoomCamera < MinimumZoom)
				ZoomCamera = MinimumZoom;
			if (ZoomCamera > MaximumZoom)
				ZoomCamera = MaximumZoom;
		}
		MainCamera.orthographicSize = ZoomCamera;

		// Translation
		if (Input.GetMouseButtonDown(2))
			FollowMode = false;
		if (Input.GetMouseButton(2))
			MainCamera.transform.Translate(new Vector2(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) * ZoomCamera * Time.deltaTime);

		// Center on ship
		if (Input.GetKeyDown(KeyCode.F))
			FollowMode = !FollowMode;
		if(FollowMode)
			MainCamera.transform.position = new Vector3(ShipManager.I.ShipDataLoaded.GameObjectLoaded.transform.position.x, ShipManager.I.ShipDataLoaded.GameObjectLoaded.transform.position.y, MainCamera.transform.position.z);
	}
}
