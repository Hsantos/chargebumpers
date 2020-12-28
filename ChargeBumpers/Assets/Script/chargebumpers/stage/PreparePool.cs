using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PreparePool : MonoBehaviour
{
    public List<GameObject> Prefabs;

    private void Start()
    {
        DefaultPool pool = PhotonNetwork.PrefabPool as DefaultPool;
        if(pool != null && Prefabs != null)
        {
            foreach (GameObject prefab in Prefabs)
            {
                if(!pool.ResourceCache.ContainsKey(prefab.name))
                    pool.ResourceCache.Add(prefab.name, prefab);
            }
        }
    }
}
