using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ProbeManager : Singleton<ProbeManager>
{
	[ShowInInspector] [ReadOnly] public ProbeData ProbeDataToLoad;
	[ShowInInspector] [ReadOnly] public int MaxProbes;

	[ShowInInspector] [ReadOnly] public List<ProbeData> ProbeDataLoaded;
	[ShowInInspector] [ReadOnly] public int ProbesCount;


	private void Update()
	{
		// Shoot Probes
		if (Input.GetKeyDown(KeyCode.Space))
			LaunchProbes();
	}


	public void Load(ProbeData probeDataToLoad, int probeCount)
	{
		ProbeDataToLoad = probeDataToLoad;
		ProbesCount = probeCount;
	}
	public void UnLoad()
	{
		StopAllCoroutines();

		foreach (ProbeData probe in ProbeDataLoaded)
			Destroy(probe.GameObjectLoaded);
		ProbeDataLoaded.Clear();

		ProbesCount = 0;
	}

	public void LaunchProbes()
	{
		if(ProbesCount > 0)
		{
			ProbeData newProbe = ProbeDataToLoad;
			ProbeDataLoaded.Add(newProbe);
			newProbe.GameObjectLoaded = newProbe.Instantiation();
			StartCoroutine(Thrust(newProbe));
			ProbesCount--;
			CanvasManager.I.SetTextProbeCount(ProbesCount);
		}
		else
			Debug.Log("Plus de sonde en réserve!");
	}
	public int AddProbes(int quantity)
	{
		if (ProbesCount + quantity <= MaxProbes)
		{
			ProbesCount += quantity;
			return 0;
		}
		else
		{
			Debug.LogError("Too many probe to add! " + ((ProbesCount + quantity) - MaxProbes) + " probe(s) remove.");
			ProbesCount = MaxProbes;
			return (ProbesCount + quantity) - MaxProbes;
		}
	}
	public void DestroyProbe(ProbeData probe)
	{
		if (ProbeDataLoaded.Contains(probe))
		{
			GravityManager.I.RemoveCompanion(probe.GameObjectLoaded.GetComponent<GravityCompanion>());
			Destroy(probe.GameObjectLoaded);
			ProbeDataLoaded.Remove(probe);
		}
	}
	public void CollectProbe(ProbeData probeToCollect)
	{
		DestroyProbe(probeToCollect);
		AddProbes(1);
	}



	public IEnumerator Thrust(ProbeData probe)
	{
		yield return new WaitForSeconds(0.1f);
		Debug.Log("Start probe thrusting");

		GravityCompanion gravityCompanionProbe = probe.GameObjectLoaded.GetComponent<GravityCompanion>();
		gravityCompanionProbe.IsAttracted = true;

		float startTime = Time.time;
		while (Time.time <= startTime + probe.ThrustingTime)
		{
			gravityCompanionProbe.Velocity += (Vector2)probe.GameObjectLoaded.transform.up * probe.ThrustingPower * Time.deltaTime;
			yield return null;
		}

		Debug.Log("Stop probe thrusting");

		yield return null;
	}
}