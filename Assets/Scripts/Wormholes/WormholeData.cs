using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "Wormhole_X", menuName = "New Wormhole")]
public class WormholeData : ScriptableObject, IProps
{
	public Sprite Sprite;
	public int SpriteOrder = 90;

	public Vector2 StartPosition;
	public float Size;

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

		return gameObject;
	}
}
