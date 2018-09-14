using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan; 
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectileParticle;

    Transform targetEnemy;

    void Update ()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy.position);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(testEnemy.transform, closestEnemy);
        }
        targetEnemy = closestEnemy;
    }

    Transform GetClosest(Transform transformA, Transform transformB)
    {
        if (Vector3.Distance(transform.position, transformA.position) < Vector3.Distance(transform.position, transformB.position))
        {
            return transformA;
        }
        return transformB;
    }

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.transform.position);
        if(distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
