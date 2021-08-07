using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour
{
    [SerializeField] private GameObject pickUpMsg = null;
    [SerializeField] private GameObject warnMsg = null;
    [SerializeField] private Transform spawnPoint = null;
    private Grenade grenade;
    private bool hasEnter = false;
    private AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        grenade = GameObject.FindObjectOfType<Grenade>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && hasEnter) {
            if(grenade.grenadenumber < 5) {
                grenade.grenadenumber++;
                PickUpSound();
                Destroy(gameObject);
            } else {
                Instantiate(warnMsg, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Grenade grenadeHolder = other.GetComponent<Grenade>();
        if(grenadeHolder != null) {
            pickUpMsg.SetActive(true);
            hasEnter = true;
        }   
    }

    private void PickUpSound() {
        audioManager.Play("PickUp");
    }

    private void OnTriggerExit(Collider other) {
        pickUpMsg.SetActive(false);
        hasEnter = false;
    }
}
