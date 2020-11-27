using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class WormholeManager : Singleton<WormholeManager>
{
	[ReadOnly] public WormholeData WormholeDataStart;
	[ReadOnly] public WormholeData WormholeDataEnd;


	public void Load(WormholeData wormholeStart, WormholeData wormholeEnd)
	{
		WormholeDataStart = wormholeStart;
		WormholeDataStart.GameObjectLoaded = WormholeDataStart.Instantiation();
		WormholeDataEnd = wormholeEnd;
		WormholeDataEnd.GameObjectLoaded = WormholeDataEnd.Instantiation();
	}
	public void UnLoad()
	{
		Destroy(WormholeDataStart.GameObjectLoaded);
		WormholeDataStart = null;
		Destroy(WormholeDataEnd.GameObjectLoaded);
		WormholeDataEnd = null;
	}
}
