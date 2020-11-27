using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class MotionManager : Singleton<MotionManager>
{
    [ReadOnly] public bool CheckProximity;


    private void Update()
    {
        if (CheckProximity)
            CheckingProximity();
    }

    public void Load()
    {
        CheckProximity = true;
    }
    public void UnLoad()
    {
        CheckProximity = false;
    }

    public void CheckingProximity()
    {
        float distance = 0;

		#region Checking ship

		Vector3 shipPosition = ShipManager.I.ShipDataLoaded.GameObjectLoaded.transform.position;

        // Ship >> Planet = Perdre niveau
        if (PlanetManager.I.PlanetDatasLoaded.Count > 0)
            for (int i = 0; i < PlanetManager.I.PlanetDatasLoaded.Count; i++)
            {
                distance = Vector2.Distance(PlanetManager.I.PlanetDatasLoaded[i].GameObjectLoaded.transform.position, shipPosition);
                if (distance <= PlanetManager.I.PlanetDatasLoaded[i].Size)
                {
                    LevelManager.I.LostLevel();
                    return;
                }
            }

        // Ship >> WormholeEnd = Gagner niveau
        if(WormholeManager.I.WormholeDataEnd != null)
        {
            distance = Vector2.Distance(WormholeManager.I.WormholeDataEnd.GameObjectLoaded.transform.position, shipPosition);
            if (distance <= WormholeManager.I.WormholeDataEnd.Size)
            {
                LevelManager.I.WinLevel();
                return;
            }

            CanvasManager.I.SetTextExitDistance(distance);
        }

		// Ship >> Item = Collecter item
        if(ItemManager.I.ItemDatasLoaded.Count > 0)
            for (int i = 0; i < ItemManager.I.ItemDatasLoaded.Count; i++)
            {
                distance = Vector2.Distance(ItemManager.I.ItemDatasLoaded[i].GameObjectLoaded.transform.position, shipPosition);
                if (distance <= ItemManager.I.ItemDatasLoaded[i].Size)
                {
                    ItemManager.I.CollectItem(ItemManager.I.ItemDatasLoaded[i]);
                    break;
                }
            }

        //Ship >> Probe = Collecter probe
        //if (ProbeManager.I.ProbeDataLoaded.Count > 0)
        //    for (int i = 0; i < ProbeManager.I.ProbeDataLoaded.Count; i++)
        //    {
        //        distance = Vector2.Distance(ProbeManager.I.ProbeDataLoaded[i].GameObjectLoaded.transform.position, shipPosition);
        //        if (distance <= ProbeManager.I.ProbeDataLoaded[i].Size)
        //        {
        //            ProbeManager.I.CollectProbe(ProbeManager.I.ProbeDataLoaded[i]);
        //            break;
        //        }
        //    }

        #endregion

        #region Checking Probes

        if (ProbeManager.I.ProbeDataLoaded.Count > 0)
            for (int i = 0; i < ProbeManager.I.ProbeDataLoaded.Count; i++)
            {
                Vector2 probePosition = ProbeManager.I.ProbeDataLoaded[i].GameObjectLoaded.transform.position;
                bool isDestroyed = false;

                // (Probe >> Probe = Détruire probe)

                // Probe >> Planet = Détruire probe
                for (int j = 0; j < PlanetManager.I.PlanetDatasLoaded.Count; j++)
                {
                    distance = Vector2.Distance(PlanetManager.I.PlanetDatasLoaded[j].GameObjectLoaded.transform.position, ProbeManager.I.ProbeDataLoaded[i].GameObjectLoaded.transform.position);
                    Debug.Log("Probe " + i + " >> Distance planet " + j + " = " + distance);
                    if (distance <= PlanetManager.I.PlanetDatasLoaded[j].Size)
                    {
                        ProbeManager.I.DestroyProbe(ProbeManager.I.ProbeDataLoaded[i]);
                        isDestroyed = true;
                        break;
                    }
                }
                if (isDestroyed)
                    break;

                // Probe >> Wormhole = Détruire probe
                if (WormholeManager.I.WormholeDataEnd != null)
                {
                    distance = Vector2.Distance(WormholeManager.I.WormholeDataEnd.GameObjectLoaded.transform.position, probePosition);
                    if (distance <= WormholeManager.I.WormholeDataEnd.Size)
                    {
                        ProbeManager.I.DestroyProbe(ProbeManager.I.ProbeDataLoaded[i]);
                        isDestroyed = true;
                    }
                }
                if (isDestroyed)
                    break;

                // Probe >> Item
                // = Collecter item
                if (ItemManager.I.ItemDatasLoaded.Count > 0)
                    for (int k = 0; k < ItemManager.I.ItemDatasLoaded.Count; k++)
                    {
                        distance = Vector2.Distance(ItemManager.I.ItemDatasLoaded[k].GameObjectLoaded.transform.position, probePosition);
                        if (distance <= ItemManager.I.ItemDatasLoaded[k].Size)
                        {
                            ItemManager.I.CollectItem(ItemManager.I.ItemDatasLoaded[k]);
                            break;
                        }
                    }
            }

        #endregion

        #region Checking Items

        if(ItemManager.I.ItemDatasLoaded.Count > 0 && PlanetManager.I.PlanetDatasLoaded.Count > 0)
            for (int i = 0; i < ItemManager.I.ItemDatasLoaded.Count; i++)
            {
                // Item >> Planet = Détruire item
                for (int j = 0; j < PlanetManager.I.PlanetDatasLoaded.Count; j++)
                {
                    distance = Vector2.Distance(ItemManager.I.ItemDatasLoaded[i].GameObjectLoaded.transform.position, PlanetManager.I.PlanetDatasLoaded[j].GameObjectLoaded.transform.position);
                    if (distance <= ItemManager.I.ItemDatasLoaded[i].Size)
                    {
                        ItemManager.I.DestroyItem(ItemManager.I.ItemDatasLoaded[i]);
                        break;
                    }
                }
            }

        #endregion
    }
}
