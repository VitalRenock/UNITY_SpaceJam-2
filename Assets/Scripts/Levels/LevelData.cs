using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Level_X", menuName = "New Level")]
public class LevelData : ScriptableObject 
{
	[TabGroup("Infos")] public int IndexOfLevel;
	[TabGroup("Gravity")] public float ConstantG;
	[TabGroup("Ship")] public ShipData ShipData;
	[TabGroup("Probes")] public ProbeData ProbeData;
	[TabGroup("Probes")] public int ProbeCount;
	[TabGroup("Planets")] public List<PlanetData> PlanetsToLoad;
	[TabGroup("Wormholes")] public WormholeData WormholeStart;
	[TabGroup("Wormholes")] public WormholeData WormholeEnd;
	[TabGroup("Items")] public List<ItemData> itemsToLoad;
	[TabGroup("Messages")] public List<MessageData> MessagesOfLevel;
}