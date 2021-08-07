using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    [SerializeField] private GameObject pickUpMsg = null;
    [SerializeField] private GameObject warnMsg = null;
    [SerializeField] private Transform spawnPoint = null;
    private Gun gun;
    private bool hasEntered;
    private AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gun = GameObject.FindObjectOfType<Gun>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && hasEntered)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (gun.bulletsLeft < 200 && gun.bulletsLeft >= 150)
        {
            gun.bulletsLeft += (200 - gun.bulletsLeft);
            PickUpSound();
            DestroyObj();
        }
        else if (gun.bulletsLeft < 150)
        {
            gun.bulletsLeft += 50;
            PickUpSound();
            DestroyObj();
        }
        else
        {
            Instantiate(warnMsg, spawnPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Gun gunHolder = other.GetComponent<Gun>();
        if(gunHolder != null) {
            pickUpMsg.SetActive(true);
            hasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        pickUpMsg.SetActive(false);
        hasEntered = false;
    }

    private void PickUpSound() {
        audioManager.Play("PickUp");
    }

    private void DestroyObj() {
        Destroy(gameObject);
    }
}
