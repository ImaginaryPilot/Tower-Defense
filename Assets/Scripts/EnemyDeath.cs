using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int healthpoints = 5;
    [SerializeField] ParticleSystem deathFx;
    [SerializeField] ParticleSystem hitFx;
    [SerializeField] int healthincrease = 1;
    [SerializeField] AudioClip DeadEnemyFX;



    void Start()
    {



    }

    void OnParticleCollision(GameObject other)
    {
        GetComponent<AudioSource>().PlayOneShot(DeadEnemyFX);
        var Health = FindObjectOfType<PlayerHealth>();
        var playerhealth = Health.health;
        var Healthtext = Health.healthtext;
        var deathcount = Health.numberofdeaths;
        healthpoints--;
        hitFx.Play();
        if (deathcount >= 3)
        {
            playerhealth = playerhealth + 2;
            Healthtext.text = playerhealth.ToString();
        }
        if (healthpoints <= 0)
        {
            playerhealth = playerhealth + healthincrease;
            Healthtext.text = playerhealth.ToString();
            deathFx.Play();
            Invoke("dead", .5f);
        }
    }

    void dead()
    {
        Destroy(gameObject);
    }
}
