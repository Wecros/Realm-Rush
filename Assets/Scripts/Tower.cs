using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileSystem;


    // Update is called once per frame
    void Update()
    {
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
    }

    void FireAtEnemy() {
        float distToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distToEnemy <= attackRange) {
            Shoot(true);
        } else {
            Shoot(false);
        }
    }

    void Shoot(bool isShooting) {
        var emissionModule = projectileSystem.emission;
        emissionModule.enabled = isShooting;
    }
}
