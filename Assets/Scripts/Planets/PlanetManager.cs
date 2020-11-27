using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlanetManager : Singleton<PlanetManager>
{
	[ReadOnly] public List<PlanetData> PlanetDatasLoaded = new List<PlanetData>();


	public void Load(List<PlanetData> planetDatasToLoad)
	{
		for (int i = 0; i < planetDatasToLoad.Count; i++)
		{
			PlanetDatasLoaded.Add(planetDatasToLoad[i]);
			PlanetDatasLoaded[i].GameObjectLoaded = PlanetDatasLoaded[i].Instantiation();
		}
	}

	public void UnLoad()
	{
		foreach (PlanetData planet in PlanetDatasLoaded)
			Destroy(planet.GameObjectLoaded);
		PlanetDatasLoaded.Clear();
	}
}
