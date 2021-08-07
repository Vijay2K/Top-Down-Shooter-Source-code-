using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFloatingText : MonoBehaviour
{
    [SerializeField] private GameObject damageText = null;
    [SerializeField] private Transform rotationOrbit = null;
    
    public void FloatingText(float currentHealth) {
        if(damageText == null) { return; }
        GameObject fText = Instantiate(damageText, transform.position, Camera.main.transform.rotation, transform);
        fText.GetComponentInChildren<TextMesh>().text = currentHealth.ToString();
    }

    //rotationOrbit.rotation
}
