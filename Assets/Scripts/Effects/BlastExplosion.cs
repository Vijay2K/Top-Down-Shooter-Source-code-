using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastExplosion : MonoBehaviour
{
    [SerializeField] private GameObject explosiveParticle = null;
    [SerializeField] private float explosionForce = 100f;
    [SerializeField] private float blastRadius = 2f;
    [SerializeField] private float blastDamage = 50f;

    public void ExplosiveEffect() {
        if(explosiveParticle != null) {
            GameObject explosiveParticleInstance = Instantiate(explosiveParticle, transform.position, Quaternion.identity);
            Destroy(explosiveParticleInstance, 2f);
        }    

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach(Collider col in colliders) {
            Rigidbody colRigidbody = col.gameObject.GetComponent<Rigidbody>();
            if(colRigidbody != null) {
                colRigidbody.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }

            CombatTarget target = col.gameObject.GetComponent<CombatTarget>();
            if(target != null) {
                target.GetComponent<Health>().TakeDamage(blastDamage);
            }
        }
    }
}
