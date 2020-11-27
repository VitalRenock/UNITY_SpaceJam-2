using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Ship_X", menuName = "New Ship")]
public class ShipData : ScriptableObject, IProps
{
	public string Name;

	public Sprite Sprite;
	public int SpriteOrder = 100;

	public Vector2 StartPosition;
	public float StartRotation;
	public float Size;

	public float Mass;
	public bool IsAttractor;
	public bool IsAttracted;

	public float ThrustingPower;
	public float ThrustingTime;
	public float SpeedRotation;

	public Material TrailMaterial;
	public float TrailLifetime;
	public int TrailSpriteOrder = 95;

	[HideInInspector] public GameObject GameObjectLoaded;

	public GameObject Instantiation()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = Name;

		SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
		sr.sprite = Sprite;
		sr.sortingOrder = SpriteOrder;

		gameObject.transform.position = StartPosition;
		gameObject.transform.eulerAngles = new Vector3(0, 0, StartRotation);
		gameObject.transform.localScale = new Vector3(Size, Size, Size);

		GravityCompanion gravity = gameObject.AddComponent<GravityCompanion>();
		gravity.Mass = Mass;
		gravity.IsAttractor = IsAttractor;
		gravity.IsAttracted = IsAttracted;
		GravityManager.I.AllGravityCompanions.Add(gravity);

		TrailRenderer trailRenderer = gameObject.AddComponent<TrailRenderer>();
		trailRenderer.material = TrailMaterial;
		trailRenderer.startColor = Color.yellow;
		trailRenderer.endColor = Color.red;
		trailRenderer.time = TrailLifetime;
		trailRenderer.sortingOrder = TrailSpriteOrder;

		// For Test
		CameraManager.I.trailTest = trailRenderer;

		return gameObject;
	}
}
