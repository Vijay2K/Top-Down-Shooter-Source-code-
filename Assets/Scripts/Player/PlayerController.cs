using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Gun gun;
    private Grenade grenade;
    public float horizontalMove { get ; private set; }
    public float verticalMove { get ; private set; }
    private Health health;

    private void Start() {
        health = GetComponent<Health>();
        gun = GetComponent<Gun>();
        grenade = GetComponent<Grenade>();
    }

    private void Update() {
        if(PauseMenu.isGamePaused) { return; }
        if(health.GetIsDead()) { return; }
        if(gun.GetIsReloading()) { return; }
        if(WaveSpawner.gameEnd) { return; }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0)) {
            gun.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            gun.Reload();
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            grenade.Throw();
        }

    }
}
