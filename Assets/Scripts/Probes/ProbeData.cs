using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Probe_X", menuName = "New Probes")]
public class ProbeData : ScriptableObject, IProps
{
	public string Name;

	public Sprite Sprite;
	public int SpriteOrder = 110;

	public float Size;

	public float Mass;
	public bool IsAttractor;
	public bool IsAttracted;

	public float ThrustingPower;
	public float ThrustingTime;

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

		gameObject.transform.position = ShipManager.I.ShipDataLoaded.GameObjectLoaded.transform.position;
		gameObject.transform.eulerAngles = ShipManager.I.ShipDataLoaded.GameObjectLoaded.transform.eulerAngles;
		gameObject.transform.localScale = new Vector3(Size, Size, 0);

		GravityCompanion gravity = gameObject.AddComponent<GravityCompanion>();
		gravity.Mass = Mass;
		gravity.IsAttractor = IsAttractor;
		gravity.IsAttracted = IsAttracted;
		GravityManager.I.AllGravityCompanions.Add(gravity);

		TrailRenderer trailRenderer = gameObject.AddComponent<TrailRenderer>();
		trailRenderer.material = TrailMaterial;
		trailRenderer.startColor = Color.cyan;
		trailRenderer.endColor = Color.blue;
		trailRenderer.time = TrailLifetime;
		trailRenderer.sortingOrder = TrailSpriteOrder;

		return gameObject;
	}
}
