using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float slowMotionFactor = 0.05f;
    [SerializeField] private float slowMotionTime = 3.5f;

    private void Update() {
        if(PauseMenu.isGamePaused) { return; } 
        Time.timeScale += (1 / slowMotionTime) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void SlowMotionEffect() {
        Time.timeScale = slowMotionFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }
}
