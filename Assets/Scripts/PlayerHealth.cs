using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 25;
    [SerializeField] int healthdecrease = 1;
    [SerializeField] AudioClip GoalFX;
    public Text healthtext;
    public int numberofdeaths;
    private void Start()
    {
        healthtext.text = health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(GoalFX);
        health = health - healthdecrease;
        healthtext.text = health.ToString();
        if (health <= 0)
        {
            numberofdeaths = numberofdeaths + 1;
            health = health + 15;
            healthtext.text = health.ToString();
        }
    }
}
