using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private GameObject lootPoints = null;

    [SerializeField] private GameObject[] lootItems = null;

    private PlayerController playerController;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }
    
    public void SpawnLootPoint(Vector3 pos) {
        if(playerController.GetComponent<Health>().GetIsDead()) { return; }
        Instantiate(lootPoints, pos, Quaternion.identity);
    }

    public void SpawnLootItems(Vector3 pos) {
        if(playerController.GetComponent<Health>().GetIsDead()) { return; }
        int randomItems = Random.Range(0, lootItems.Length);
        Instantiate(lootItems[randomItems], pos, Quaternion.identity);
    }
}
