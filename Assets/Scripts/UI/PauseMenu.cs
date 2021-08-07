using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;

    public static bool isGamePaused;
    private LoadingTransition loadingTransition;

    private void Start() {
        loadingTransition = GameObject.FindObjectOfType<LoadingTransition>();
        pauseMenu.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isGamePaused) {
                Resume();
            } else {
                pause();
            }
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        Cursor.visible = false;
    }

    private void pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        Cursor.visible = true;
    }

    public void MainMenu() {
        isGamePaused = false;
        StartCoroutine(loadingTransition.StartTransition("MainMenu"));
        Time.timeScale = 1;
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
