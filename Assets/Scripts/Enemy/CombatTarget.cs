using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTarget : MonoBehaviour
{
    [SerializeField] private float stoppingDistance = 2f;
    [SerializeField] private float attackingDamage = 5f;

    private Transform target;
    private EnemyController enemyController;
    private Animator animator;
    private Health health;
    private AudioManager audioManger;

    private void Start() {
        enemyController = GetComponent<EnemyController>();
        audioManger = GameObject.FindObjectOfType<AudioManager>();
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Update() {
        if (!GetInRange())
        {
            StopAttacking();
        }
        else
        {
            StartAttacking();
        }
    }

    private void StartAttacking()
    {
        enemyController.CancelMoverAction();
        animator.SetBool("Attack", true);
    }

    private void StopAttacking()
    {
        enemyController.StartMoveAction();
        animator.SetBool("Attack", false);
    }

    //Animation Trigger event
    private void Attack() {
        if(target.GetComponent<Health>().GetIsDead()) { return; }
        target.GetComponent<Health>().TakeDamage(attackingDamage);
        target.GetComponent<DamageScreenEffect>().DisplayDamageScreen();
        AudioManager.Instance.Play("ZombieAttack");
        if(target.GetComponent<Health>().GetIsDead()) {
            audioManger.Play("PlayerDead");
            animator.SetTrigger("StayIdle");
        }
    }

    private bool GetInRange() {
        return Vector3.Distance(target.position, transform.position) < stoppingDistance;
    }
}
