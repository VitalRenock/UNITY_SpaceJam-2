using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Planet_X", menuName = "New Planet")]
public class PlanetData : ScriptableObject, IProps
{
	public Sprite Sprite;
	public int SpriteOrder = 80;

	public Vector2 StartPosition;
	public float Size;

	public float Mass;
	public bool IsAttractor;
	public bool IsAttracted;

	[HideInInspector] public GameObject GameObjectLoaded;

	public GameObject Instantiation()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = this.name;

		SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
		sr.sprite = Sprite;
		sr.sortingOrder = SpriteOrder;

		gameObject.transform.position = StartPosition;
		gameObject.transform.localScale = new Vector3(Size, Size, Size);

		GravityCompanion gravity = gameObject.AddComponent<GravityCompanion>();
		gravity.Mass = Mass;
		gravity.IsAttractor = IsAttractor;
		gravity.IsAttracted = IsAttracted;
		GravityManager.I.AllGravityCompanions.Add(gravity);

		return gameObject;
	}
}