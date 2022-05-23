using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private Text title;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;
    public float currentWave = 1;
    private int currentAmount = 1;
    public float spawnInterval = 0;
    public float currentSpawnTime = 5f;
    public float waveTimer = 20f;

    private void Start() {
        enemyPrefab.SetActive(false);
    }

    private void Update() { 
        currentSpawnTime -= Time.deltaTime;
        waveTimer -= Time.deltaTime;

        if (currentSpawnTime <= spawnInterval){
            SpawnNewEnemy(currentAmount);
            currentSpawnTime = 5f;

        }
        if (waveTimer <= spawnInterval) {
            currentWave += 1;
            title.text = "Wave: " + currentWave + " / 10";
            currentAmount = currentAmount + 2;
            waveTimer = 20f;
        }
        if (currentWave == 5) {
            enemyPrefab.SetActive(false);
            boss.SetActive(true);
            title.text = "Wave : " + currentWave + "(BOSS LEVEL)";
            Level2Boss();
        }
        if (currentWave == 10) {
            Time.timeScale = 0f;
            boss.SetActive(true);
            player.SetActive(false);
        }
    }

    private void Level2Boss() {
        boss.SetActive(false);
        enemy2.SetActive(true);
        enemyPrefab.SetActive(true);
    }

    public void SpawnNewEnemy(int enemies) {
        for (int i = 0; i < enemies; i++) {
            GameObject enemyClone = Instantiate(enemyPrefab, new Vector3(enemySpawner.transform.position.y, enemySpawner.transform.position.x, i * currentAmount), Quaternion.identity);
            enemyClone.SetActive(true);
        }
    }
}
