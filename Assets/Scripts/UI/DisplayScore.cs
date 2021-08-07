using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    //UI
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text killScoreText = null;

    private int scorePoints = 0;
    private int killPoints = 0;

    private PlayerController playerController;

    private int xpPoints;

    private void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    public void DisplayScoreText () {

        foreach (EnemyController controller in FindObjectsOfType<EnemyController>()) {
            xpPoints = controller.GetComponent<XPPoints>().XP;
        }

        scorePoints += xpPoints;
        scoreText.text = scorePoints.ToString();
    }
    
    public void DisplayKillScore() {
        if(playerController.GetComponent<Health>().GetIsDead()) { return; }

        killPoints++;
        killScoreText.text = killPoints.ToString();
    }

    public int GetScore() {
        return scorePoints;
    }

    public int GetKills() {
        return killPoints;
    }

}
