using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplashEffect = null;

    public GameObject GetBloodSplashEffect() {
        return bloodSplashEffect;
    }

}
