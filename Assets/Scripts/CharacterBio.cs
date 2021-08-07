using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBio : MonoBehaviour
{
    private List<Transform> characters;
    private LoadingTransition loadingTransition;

    private void Awake() {
        characters = new List<Transform>();
        for(int i = 0; i < transform.childCount; i++) {
            var character = transform.GetChild(i);
            characters.Add(character);

            character.gameObject.SetActive(i == 0);
        }
    }

    private void Start() {
        loadingTransition = GameObject.FindObjectOfType<LoadingTransition>();
    }

    public void EnableCharacters(Transform character) {
        for(int i = 0; i < transform.childCount; i++) {
            var transformToToggle = transform.GetChild(i);
            bool shouldBeActive = transformToToggle == character;

            transformToToggle.gameObject.SetActive(shouldBeActive);
        }
    }

    public void Back() {
        StartCoroutine(loadingTransition.StartTransition("MainMenu"));
    }
}
