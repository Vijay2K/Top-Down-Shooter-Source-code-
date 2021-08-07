using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar = null;

    private Health health;

    private void Start() {
        health = GetComponent<Health>();
    }

    private void Update() {
        healthBar.fillAmount = health.GetHealthPercentage();
    }
}
