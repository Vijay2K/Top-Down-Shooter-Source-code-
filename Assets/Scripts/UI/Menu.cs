using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator rulesAnimator;
    [SerializeField] private Animator controlAnimator;
    [SerializeField] private Animator highScoreAnimator;
    [SerializeField] private Animator aboutUsAnimator;

    [SerializeField] private TMP_Text highScoreText = null;
    [SerializeField] private TMP_Text totalKillText = null;

    private LoadingTransition loadingTransition;

    private void Start() {
        loadingTransition = GameObject.FindObjectOfType<LoadingTransition>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        totalKillText.text = PlayerPrefs.GetInt("HighKills").ToString();
    }

    public void StartGame() {
        StartCoroutine(loadingTransition.StartTransition("Game"));
    }

    public void HighScore() {
        highScoreAnimator.SetTrigger("HighScore");
    }

 
    public void Rules() {
        rulesAnimator.SetTrigger("Rules");
    }

    public void Controls() {
        controlAnimator.SetTrigger("Controls");
    }

    public void CloseControls() {
        controlAnimator.SetTrigger("CloseControls");
    }

    public void CloseRules() {
        rulesAnimator.SetTrigger("CloseRules");
    }

    public void AboutUs() {
        aboutUsAnimator.SetTrigger("AboutUs");
    }

    public void CloseAboutUs() {
        aboutUsAnimator.SetTrigger("CloseAboutUs");
    }

    public void CharacterBio() {
        StartCoroutine(loadingTransition.StartTransition("CharacterBio"));
    }

    public void Quit() {
        Application.Quit();
    }
}
