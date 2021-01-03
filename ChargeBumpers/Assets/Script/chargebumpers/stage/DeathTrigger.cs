using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoints;

    [SerializeField]
    private float respawnPenalty = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        int spawnPointCount = spawnPoints.transform.childCount;
        int numberDrawn = Random.Range(0, spawnPointCount);
        Transform spawnPoint = spawnPoints.transform.GetChild(numberDrawn).GetComponent<Transform>();

        CarBehaviour car = other.GetComponentInParent<CarBehaviour>();
        car.Respawn(spawnPoint.position, spawnPoint.rotation, respawnPenalty);
    }
}
