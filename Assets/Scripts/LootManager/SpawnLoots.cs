using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoots : MonoBehaviour
{
    
    [SerializeField] private Transform spawnPoint = null;
    
    private LootManager lootManager;

    private void Start() {
        lootManager = GameObject.Find("LootManager").GetComponent<LootManager>();
    }

    public IEnumerator StartSpawn() {
        yield return new WaitForSeconds(3f);

        if(spawnPoint != null) 
            lootManager.SpawnLootItems(spawnPoint.position);
    }
}
