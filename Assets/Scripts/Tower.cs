using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform Head;
    [SerializeField] float attackrange = 10f;
    [SerializeField] ParticleSystem projectile;

    public Waypoint baseWaypoint;
    

    Transform Enemy;


    void Update()
    {
        SetTargeyEnemy();
        if (Enemy)
        {
            Head.LookAt(Enemy);
            FireEnemy();
        }
        else
        {
            Shoot(false);
        }

    }

    private void SetTargeyEnemy()
    {
        var Enemies = FindObjectsOfType<EnemyDeath>();
        if (Enemies.Length == 0) { return; }

        Transform closestEnemy = Enemies[0].transform;
        foreach (EnemyDeath testEnemy in Enemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        Enemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);
        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    void FireEnemy()
    {
        float distancetoenemy = Vector3.Distance(Enemy.transform.position, gameObject.transform.position);
        if (distancetoenemy <= attackrange)
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
        var emmissionModule = projectile.emission;
        emmissionModule.enabled = isActive;
    }
}
