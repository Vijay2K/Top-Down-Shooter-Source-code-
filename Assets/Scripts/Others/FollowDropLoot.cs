using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDropLoot : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float minModifier = 7;
    [SerializeField] private float maxModifier = 11;

    private Vector3 _velocity = Vector3.zero;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("LootTracker").transform;
    }

    private void Update() {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));
    }

}
