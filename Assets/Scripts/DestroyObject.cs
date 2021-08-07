using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float timer = 5f;

    private void Start() {
        Destroy(gameObject, timer);
    } 
}
