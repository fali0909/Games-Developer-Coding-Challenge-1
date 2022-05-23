using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    private Image Health_Bar;
    public float CurrentHealth;
    private float maxHealth = 100f;
    Enemy1Controller enemy;

    private void Start() {
        Health_Bar = GetComponent<Image>();
        enemy = FindObjectOfType<Enemy1Controller>();
    }

    private void Update() {
        CurrentHealth = Enemy1Controller.Health;
        Health_Bar.fillAmount = CurrentHealth / maxHealth;
    }
}
