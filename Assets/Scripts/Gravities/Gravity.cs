using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gravity
{
	public static Vector2 CalculateGravityForce(GravityCompanion attractor, GravityCompanion attracted)
	{
		// Calcule de la direction.
		Vector2 direction = (Vector2)attractor.transform.position - (Vector2)attracted.transform.position;

		// Calcule de la distance. En Unity units
		float distance = direction.magnitude; // Retourne la longueur d'un vecteur.

		// Calcule de la force d'attraction. en Newton, Formule: F = ((masseA * masseB) / distance(AB)²) * G
		float weight = GravityManager.I.ConstantG * ((attracted.Mass * attractor.Mass) / (distance * distance));

		// Calcule de la force finale. en Newton + Direction
		Vector2 gravityForce = direction.normalized * weight;

		return gravityForce;
	}
}
