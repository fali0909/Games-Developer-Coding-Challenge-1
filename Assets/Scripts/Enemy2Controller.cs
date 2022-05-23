using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour {
    public static float enemy2Health = 100f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    public float timeInvincible = 2.0f;
    Vector3 playerPos;
    Vector3 enemyPos;
    float distance;
    float speed = 5;

    PlayerMovement playerMovement;

    private void Start() {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update() {
        enemy.transform.LookAt(player.transform);
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;
        distance = Vector3.Distance(playerPos, enemyPos);
        if (distance <= 1) {
            playerMovement.ChangeHealth(7);
        }
        else {
            transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void ChangeEnemyHealth(int value) {
        float currentHealth = enemy2Health;
        enemy2Health = Mathf.Clamp(currentHealth, 0, 100);
        enemy2Health -= value;
        if (enemy2Health <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
    }

    public void ProjectileTouched2()
    {
        ChangeEnemyHealth(1);
    }
}
