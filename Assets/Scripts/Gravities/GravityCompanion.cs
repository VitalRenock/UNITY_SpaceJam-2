using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GravityCompanion : MonoBehaviour
{
	public bool IsAttracted;
	public bool IsAttractor;
	public float Mass;

	public Vector2 Velocity = Vector2.zero;

	private void FixedUpdate()
	{
		if (IsAttracted)
			transform.Translate(new Vector3(Velocity.x, Velocity.y, 0), Space.World);
	}
}
