using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void CamShake() {
        animator.SetTrigger("Shake");
    }

    public void GrenadeBlast() {
        animator.SetTrigger("GrenadeBlast");
    }
}
