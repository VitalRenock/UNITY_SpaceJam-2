using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
	
public class ItemManager : Singleton<ItemManager>
{
	[ReadOnly] public List<ItemData> ItemDatasLoaded;
	[ReadOnly] public List<ItemData> itemsShip;
	public int InventorySize;


	public void Load(List<ItemData> itemDatasToLoad)
	{
		for (int i = 0; i < itemDatasToLoad.Count; i++)
		{
			ItemDatasLoaded.Add(itemDatasToLoad[i]);
			ItemDatasLoaded[i].GameObjectLoaded = itemDatasToLoad[i].Instantiation();
			StartCoroutine(Thrust(ItemDatasLoaded[i]));
		}
	}
	public void UnLoad()
	{
		StopAllCoroutines();

		foreach (ItemData item in ItemDatasLoaded)
			Destroy(item.GameObjectLoaded);
		ItemDatasLoaded.Clear();
	}

	public void CollectItem(ItemData itemToCollect)
	{
		Debug.Log("Dans CollectItem");
		if (itemsShip.Count < InventorySize)
		{
			ItemData itemCopy = itemToCollect;
			itemsShip.Add(itemCopy);
			DestroyItem(itemToCollect);
		}
		else
			Debug.Log("Inventory full!");
			//MessageManager.I.Post("IA Mobius", "Plus de place dans l'inventaire");
	}
	public void DestroyItem(ItemData itemToDestroy)
	{
		if (ItemDatasLoaded.Contains(itemToDestroy))
		{
			GravityManager.I.RemoveCompanion(itemToDestroy.GameObjectLoaded.GetComponent<GravityCompanion>());
			Destroy(itemToDestroy.GameObjectLoaded);
			ItemDatasLoaded.Remove(itemToDestroy);
		}
	}



	public IEnumerator Thrust(ItemData item)
	{
		//yield return new WaitForSeconds(0.1f);
		Debug.Log("Start item thrusting");

		GravityCompanion gravityCompanionProbe = item.GameObjectLoaded.GetComponent<GravityCompanion>();
		gravityCompanionProbe.IsAttracted = true;

		float startTime = Time.time;
		while (Time.time <= startTime + item.ThrustingTime)
		{
			gravityCompanionProbe.Velocity += (Vector2)item.GameObjectLoaded.transform.up * item.ThrustingPower * Time.deltaTime;
			yield return null;
		}

		Debug.Log("Stop item thrusting");

		yield return null;
	}
}
