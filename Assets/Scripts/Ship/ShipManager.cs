using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ShipManager : Singleton<ShipManager>
{
	[ReadOnly] public ShipData ShipDataLoaded;

	Coroutine Thrusting;

	private void Update()
	{
		// Ship Thrusting
		if (Input.GetKeyDown(KeyCode.Z) && Thrusting == null)
			Thrusting = StartCoroutine(Thrust());

		// Ship Rotation
		if (Input.GetAxis("Horizontal") != 0)
			RotateShip(Input.GetAxis("Horizontal"));
	}

	public void Load(ShipData shipData)
	{
		ShipDataLoaded = shipData;
		ShipDataLoaded.GameObjectLoaded = ShipDataLoaded.Instantiation();
	}
	public void UnLoad()
	{
		StopAllCoroutines();

		Destroy(ShipDataLoaded.GameObjectLoaded);
		ShipDataLoaded = null;
	}

	public void RotateShip(float angle)
	{
		ShipDataLoaded.GameObjectLoaded.transform.Rotate(Vector3.back, angle * ShipDataLoaded.SpeedRotation * Time.deltaTime);
		CanvasManager.I.SetTextShipRotation(ShipDataLoaded.GameObjectLoaded.transform.eulerAngles.z);
	}



	public IEnumerator Thrust()
	{
		Debug.Log("Start thrusting");

		GravityCompanion gravityCompanionShip = ShipDataLoaded.GameObjectLoaded.GetComponent<GravityCompanion>();
		gravityCompanionShip.IsAttracted = true;

		float startTime = Time.time;
		while (Time.time <= startTime + ShipDataLoaded.ThrustingTime)
		{
			gravityCompanionShip.Velocity += (Vector2)ShipDataLoaded.GameObjectLoaded.transform.up * ShipDataLoaded.ThrustingPower * Time.deltaTime;
			yield return null;
		}

		Debug.Log("Stop thrusting");
		Thrusting = null;
	}
}