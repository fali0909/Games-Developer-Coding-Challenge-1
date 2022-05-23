using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
 

    private void OnTriggerEnter(Collider other) {
        Enemy1Controller e = FindObjectOfType<Enemy1Controller>();
        Enemy2Controller e1 = FindObjectOfType<Enemy2Controller>();
        if (other.transform.CompareTag("Enemy")) {
            e.ProjectileTouched1();
            Destroy(gameObject);
        }
        if (other.transform.CompareTag("Enemy2"))
        {
            e1.ProjectileTouched2();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
