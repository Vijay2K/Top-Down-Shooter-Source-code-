using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyLoot : MonoBehaviour
{
    private DisplayScore displayScore;
    private AudioManager audioManager;

    private void Start() {
        displayScore = GameObject.FindObjectOfType<DisplayScore>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<PlayerController>()) {
            displayScore.DisplayScoreText();
            audioManager.Play("Looting");
            Destroy(transform.parent.gameObject);
        }
    }
}
