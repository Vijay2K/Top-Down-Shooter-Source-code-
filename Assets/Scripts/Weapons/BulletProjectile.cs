using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float bulletDamge = 10f;
    private TimeManager timeManager;

    private void Start() {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    private void Update() {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        Health enemyHealth = other.gameObject.GetComponent<Health>();

        if (other.gameObject.GetComponent<CombatTarget>()) {
            enemyHealth.TakeDamage(bulletDamge);
            Instantiate(GetComponent<SpawnEffects>().GetBloodSplashEffect(), transform.position, Quaternion.identity);
        }

        if(other.gameObject.GetComponent<DestructableObject>()) {
            DestructableObject destructableObject = other.gameObject.GetComponent<DestructableObject>();
            destructableObject.Explode();
            Destroy(destructableObject.gameObject);
            timeManager.SlowMotionEffect();
        }
        
        Destroy(gameObject);
    }

}
