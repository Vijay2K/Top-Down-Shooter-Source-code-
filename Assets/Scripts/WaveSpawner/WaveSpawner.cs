using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves = null;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float waveCount;
    [SerializeField] private Transform[] spawnPoints = null;
    [SerializeField] private SpawnState state = SpawnState.COUNTING;
    [SerializeField] private TMP_Text waveCountText = null;
    [SerializeField] private TMP_Text waveCompletedText = null;
    [SerializeField] private Animator waveCounterAnimator = null;
    [SerializeField] private Animator waveCompletedAnimation = null;
    [SerializeField] private GameObject gameEndPanel = null;

    private int nextWave = 0;
    private float searchCount = 1f;
    public static bool gameEnd = false;
    private LoadingTransition loadingTransition;

    private void Start() {
        loadingTransition = GameObject.FindObjectOfType<LoadingTransition>();
        waveCount = timeBetweenWaves;
    }

    private void Update() {
        if(state == SpawnState.WAITING) {
            if(!ZombieIsAlive() && !gameEnd) {
                BeginNewWave(waves[ nextWave ]);
            } else {
                return;
            }
        }

        if(waveCount <= 0 && state != SpawnState.SPAWNING && !gameEnd) {
            StartCoroutine(SpawnWave(waves[ nextWave ]));
        } else {
            waveCount -= Time.deltaTime;
        }
    }

    private void BeginNewWave(Wave wave) {
        Debug.Log("Wave compeleted");
        WaveCompletedAnimation(wave);

        state = SpawnState.COUNTING;
        waveCount = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) {
            nextWave = 0;
            gameEnd = true;
            Debug.Log("All waves have completed");
            gameEndPanel.SetActive(true);
            Cursor.visible = true;
        } else {
            nextWave++;
        }
    }

    private bool ZombieIsAlive() {
        searchCount -= Time.deltaTime;
        if(searchCount <= 0) {
            searchCount = 1f;
            if(GameObject.FindObjectOfType<EnemyController>() == null) {
                return false;
            }
        }
        
        return true;
    }

    IEnumerator SpawnWave(Wave wave) {
        state = SpawnState.SPAWNING;

        WaveCounterAnimation(wave);

        for (int i = 0; i < wave.count; i++) {
            SpawnZombies(wave.zombies[Random.Range(0, wave.zombies.Length)]);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    private void WaveCounterAnimation(Wave wave) {
        waveCountText.text = wave.waveName;
        waveCounterAnimator.SetTrigger("DropDown");
    }

    private void WaveCompletedAnimation(Wave wave) {
        waveCompletedText.text = wave.waveName + " completed";
        waveCompletedAnimation.SetTrigger("ScaleUp");
    }


    private void SpawnZombies(GameObject zombie) {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(zombie, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    public void MainMenu() {
        StartCoroutine(loadingTransition.StartTransition("MainMenu"));
    }
}
