using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (hitPoints <= 0) {
            DestroySelf();
        }
    }

    void ProcessHit() {
        hitPoints--;
        print("Current hitpoints: " + hitPoints);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
