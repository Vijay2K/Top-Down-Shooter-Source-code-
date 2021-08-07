using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 2.5f;

    private Vector3 offset = new Vector3(0, 2f, 0);

    private void Start() {
        Destroy(gameObject, destroyTimer);

        transform.localPosition += offset;
    }

    private void Update() {
    }
}
