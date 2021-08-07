using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTransition : MonoBehaviour
{

    [SerializeField] private float transitionTime = 3f;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public IEnumerator StartTransition(string levelName) {
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
