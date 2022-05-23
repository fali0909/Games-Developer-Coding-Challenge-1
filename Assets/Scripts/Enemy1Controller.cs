using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {

    public static float Health = 100f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    public float timeInvincible = 2.0f;
    Vector3 playerPos;
    Vector3 enemyPos;
    float distance;
    float speed = 5;

    Animation_Test anim;
    PlayerMovement playerMovement;

    private void Start() {
        anim = GetComponent<Animation_Test>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update() {

        enemy.transform.LookAt(player.transform);
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;
        distance = Vector3.Distance(playerPos, enemyPos);
        if (distance <= 2) {
            anim.AttackAni();
            playerMovement.ChangeHealth(1);
        }
        else {
            anim.RunAni();
            transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void ChangeBuildingHealth(int value) {
        float currentHealth = Health;
        Health = Mathf.Clamp(currentHealth, 0, 100);
        Health -= value;
        if (Health <= 0) {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
    }

    public void ProjectileTouched1() {
        ChangeBuildingHealth(10);
    }
}
