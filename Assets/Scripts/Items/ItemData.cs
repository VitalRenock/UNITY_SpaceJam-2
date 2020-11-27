using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Item_X", menuName = "New Item")]
public class ItemData : ScriptableObject, IProps
{
	public string Name;

	public Sprite Sprite;
	public int SpriteOrder = 105;

	public Vector2 StartPosition;
	public float StartRotation;
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

		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = Sprite;
		spriteRenderer.sortingOrder = SpriteOrder;

		gameObject.transform.position = new Vector3(StartPosition.x, StartPosition.y, 0);
		gameObject.transform.eulerAngles = new Vector3(0, 0, StartRotation);
		gameObject.transform.localScale = new Vector3(Size, Size, 0);

		GravityCompanion gravityCompanion = gameObject.AddComponent<GravityCompanion>();
		gravityCompanion.Mass = Mass;
		gravityCompanion.IsAttractor = IsAttractor;
		gravityCompanion.IsAttracted = IsAttracted;
		GravityManager.I.AllGravityCompanions.Add(gravityCompanion);

		TrailRenderer trailRenderer = gameObject.AddComponent<TrailRenderer>();
		trailRenderer.material = TrailMaterial;
		trailRenderer.startColor = Color.green;
		trailRenderer.endColor = Color.yellow;
		trailRenderer.time = TrailLifetime;
		trailRenderer.sortingOrder = TrailSpriteOrder;

		return gameObject;
	}
}
