using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayGameOver : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasgroup = null;
    [SerializeField] private float fadeTime = 0.01f;
    [SerializeField] private bool isCursorVisible = false;

    //UI
    [SerializeField] private TMP_Text currentScoreText = null;
    [SerializeField] private TMP_Text currentKillText = null;
    [SerializeField] private TMP_Text highScoreText = null;
    [SerializeField] private TMP_Text totalKillText = null;


    private PlayerController player;
    private LoadingTransition loadingTransition;
    private DisplayScore displayScore;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        loadingTransition = GameObject.FindObjectOfType<LoadingTransition>();
        displayScore = GetComponent<DisplayScore>();
        canvasgroup.blocksRaycasts = false;
    }

    private void Update() {
        if (player.GetComponent<Health>().GetIsDead()) {
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            totalKillText.text = PlayerPrefs.GetInt("HighKills", 0).ToString();

            StartCoroutine(FadeOut(fadeTime));
        }

        UpdateGameOverUI();
    }

    private void UpdateGameOverUI() {
        currentScoreText.text = displayScore.GetScore().ToString();
        currentKillText.text = displayScore.GetKills().ToString();

        if(displayScore.GetScore() > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", displayScore.GetScore());
        }

        if(displayScore.GetKills() > PlayerPrefs.GetInt("HighKills", 0)) {
            PlayerPrefs.SetInt("HighKills", displayScore.GetKills());
        }
    }

    public IEnumerator FadeOut(float time) {
        yield return new WaitForSeconds(3f);
        Cursor.visible = isCursorVisible;
        canvasgroup.blocksRaycasts = true;
        while (canvasgroup.alpha < 1) {
            yield return canvasgroup.alpha += time;
            yield return null;
        }
    }

    // BUTTON UI
    public void RestartGame() {
        //SceneManager.LoadScene("Game");
        StartCoroutine(loadingTransition.StartTransition("Game"));
        canvasgroup.blocksRaycasts = false;
    }

    public void MainMenu() {
        //SceneManager.LoadScene("MainMenu");
        StartCoroutine(loadingTransition.StartTransition("MainMenu"));
        canvasgroup.blocksRaycasts = false;
    }
}
