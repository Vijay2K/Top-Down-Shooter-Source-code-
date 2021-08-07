using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTanks : MonoBehaviour 
{
    [SerializeField] private GameObject[] explosionTanks = null;
    [SerializeField] private Transform[] spawnPoints = null;

    private void Start() {
        InvokeRepeating("SpawnTanks", 120f, 120f);
    }

    private void SpawnTanks() {
        int randomSpawnPoints = Random.Range(0, spawnPoints.Length);
        int randomTanks = Random.Range(0, explosionTanks.Length);

        Instantiate(explosionTanks[randomTanks], spawnPoints[randomSpawnPoints].position, Quaternion.identity);
    }
}
