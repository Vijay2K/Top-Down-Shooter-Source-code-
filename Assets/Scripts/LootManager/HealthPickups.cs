using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    [SerializeField] private GameObject pickUpMsg = null;
    [SerializeField] private GameObject warnMsg = null;
    [SerializeField] private Transform spawnPoint = null;
    
    private bool hasEntered = false;
    private Health playerhealth;
    private AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        playerhealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q) && hasEntered) {
            if(playerhealth.currentHealth < 50 && playerhealth.currentHealth >= 40) {
                playerhealth.currentHealth += (50 - playerhealth.currentHealth);
                PickUpSound();
                DestroyObj();
            }
            else if(playerhealth.currentHealth < 40) {
                playerhealth.currentHealth += 10;
                PickUpSound();
                DestroyObj();
            } else {
                Instantiate(warnMsg, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null) {
            pickUpMsg.SetActive(true);
            hasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        pickUpMsg.SetActive(false);
        hasEntered = false;
    }

    private void PickUpSound() {
        audioManager.Play("Heal");
    }

    private void DestroyObj() {
        Destroy(gameObject);
    }
}
