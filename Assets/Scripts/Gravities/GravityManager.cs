using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class GravityManager : Singleton<GravityManager>
{
	[ReadOnly] public float ConstantG = 1; // En Newton UnityUnits²/kg²
	[ReadOnly] public bool GravityOn;
	[ReadOnly] public List<GravityCompanion> AllGravityCompanions;


	private void FixedUpdate()
	{
		if(GravityOn && AllGravityCompanions.Count >= 2)
			ApplyGravity();
	}

	public void Load(float constantG)
	{
		ConstantG = constantG;
		GravityOn = true;
	}
	public void UnLoad()
	{
		GravityOn = false;
		AllGravityCompanions.Clear();
	}

	void ApplyGravity()
	{
		foreach (GravityCompanion attractor in AllGravityCompanions)
			if (attractor.IsAttractor)
				foreach (GravityCompanion attracted in AllGravityCompanions)
					if (attracted.IsAttracted && attractor != attracted)
						attracted.Velocity += Gravity.CalculateGravityForce(attractor, attracted);
	}
	public void RemoveCompanion(GravityCompanion companionToRemove)
	{
		if (AllGravityCompanions.Contains(companionToRemove))
			AllGravityCompanions.Remove(companionToRemove);
		else
			Debug.LogError("GravityManager can't remove a companion.");
	}
}