using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 5f;
    private Transform target;
    private NavMeshAgent agent;
    private Health health;
    private Animator animator;
    private DissolveEffect dissolveEffect;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        dissolveEffect = GetComponent<DissolveEffect>();
    }

    private void Update() {
        if(health.GetIsDead()) {
            agent.speed = 0.0f;
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(dissolveEffect.Dissolve());
            Destroy(gameObject, destroyTimer);
        }
    }

    public void StartMoveAction() {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    public void CancelMoverAction() {
        agent.isStopped = true;
    }

}
