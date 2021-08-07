using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player = null;

    private void LateUpdate() {
        transform.position = player.position;
    }
}
