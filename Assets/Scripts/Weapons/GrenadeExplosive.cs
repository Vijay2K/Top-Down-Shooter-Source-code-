using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosive : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    private CameraShake cameraShake = null;
    private BlastExplosion explosion;

    private float countDown;
    private bool hasExplode = false;


    private void Start() {
        countDown = delay;
        explosion = GetComponent<BlastExplosion>();
        cameraShake = GameObject.Find("CameraShakeAnimation").GetComponent<CameraShake>();
    }

    private void Update() {
        countDown -= Time.deltaTime;
        if(countDown <= 0 && !hasExplode) {
            Explode();
            hasExplode = true;
        }
    }

    public void Explode() {

        explosion.ExplosiveEffect();

        //cameraShake
        cameraShake.GrenadeBlast();

        //Audio
        AudioManager.Instance.Play("GrenadeExplosion");

        Destroy(gameObject);
    }
}
