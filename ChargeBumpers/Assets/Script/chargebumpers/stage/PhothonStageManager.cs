using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhothonStageManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpawnPoints; 
    
    void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

   private void SpawnPlayer()
    {
        int player = 0;
        if(!PhotonNetwork.IsMasterClient)
        {
            player = 1;
        }

        int randPost = Random.Range(0, SpawnPoints.Count-1);
        GameObject gameObject = PhotonNetwork.Instantiate("VehiclePack", SpawnPoints[randPost].transform.position, Quaternion.identity);
        
    }
}
