using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem goalparticles;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(.25f);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var goalfx = Instantiate(goalparticles, transform.position, Quaternion.identity);
        goalfx.Play();
        Destroy(goalfx.gameObject, goalfx.main.duration);

        Destroy(gameObject);
    }
}