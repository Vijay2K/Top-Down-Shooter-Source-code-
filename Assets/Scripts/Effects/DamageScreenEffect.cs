using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreenEffect : MonoBehaviour
{
    [SerializeField] private Image damageScreenImage = null;
    [SerializeField] private float alphaValue = 0.08f;
    [SerializeField] private float fadingValue = 0.01f;

    private void Update() {
        if(damageScreenImage.color.a > 0) {
            Color dColor = damageScreenImage.color;
            dColor.a -= fadingValue;

            damageScreenImage.color = dColor;
        }
    }

    public void DisplayDamageScreen() {
        if(damageScreenImage != null) {
            Color dColor = damageScreenImage.color;
            dColor.a = alphaValue;

            damageScreenImage.color = dColor;
        }
    } 
}
