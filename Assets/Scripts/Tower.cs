﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileSystem;

    // State of each tower
    Transform targetEnemy;


    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }
        print("here");

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB) {
            return transformA;
        }

        return transformB;
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
