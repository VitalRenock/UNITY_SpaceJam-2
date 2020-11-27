using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour
{
	//public Rigidbody2D rigidbody2D = new Rigidbody2D();

	//public Vector2 Velocity
	//{
	//	get { return rigidbody2D.velocity; }
	//	set { rigidbody2D.velocity = value; }
	//}

	//#region Variables

	//private float distance;
	//public float Distance
	//{
	//	get { return distance; }
	//	set { distance = value; }
	//}

	//private float duration;
	//public float Duration
	//{
	//	get { return duration; }
	//	set { duration = value; }
	//}

	//private float speed;
	//public float Speed
	//{
	//	get { return speed; }
	//	set { speed = value; }
	//}

	//private Vector3 direction;  // Normalized
	//public Vector3 Direction
	//{
	//	get { return direction; }
	//	set { direction = value.normalized; }
	//}

	//private Vector3 displacement;
	//public Vector3 Displacement
	//{
	//	get { return displacement; }
	//	set { displacement = value; }
	//}

	//private Vector3 endPosition;
	//public Vector3 EndPosition
	//{
	//	get { return endPosition; }
	//	set { endPosition = value; }
	//}

	//private Vector3 velocity;
	//public Vector3 Velocity
	//{
	//	get { return velocity; }
	//	set { velocity = value; }
	//}

	//public Vector3 DeltaVelocity
	//{
	//	get { return velocity * Time.deltaTime; }
	//	private set { }
	//}

	//#endregion

	//#region Physics Calculs

	//public float SetDistance(float speed, float duration)
	//{
	//	return speed * duration;
	//}
	//public float SetDuration(float speed, float distance)
	//{
	//	return distance / speed;
	//}
	//public float SetSpeed(float distance, float duration)
	//{
	//	return distance / duration;
	//}
	//public Vector3 SetDisplacement(Vector3 direction, float distance)
	//{
	//	return direction.normalized * distance;
	//}
	//public Vector3 SetEndPosition(Vector3 startPosition, Vector3 displacement)
	//{
	//	return startPosition + displacement;
	//}
	//public void SetVelocity(Vector3 direction, float speed)
	//{
	//	velocity = direction.normalized * speed;
	//}
	////public Vector3 SetDeltaVelocity(Vector3 velocity)
	////{
	////	return velocity * Time.deltaTime;
	////}

	//#endregion
}
