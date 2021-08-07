using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    private BlastExplosion explosion;

    private void Start() {
        explosion = GetComponent<BlastExplosion>();
    }

    public void Explode() {
        explosion.ExplosiveEffect();
        AudioManager.Instance.Play("TankExplosion");
    }
}
