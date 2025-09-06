using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject RespawnEnemyBody;
    [SerializeField] Transform parent;
    [SerializeField] Text spawnedenemies;
    [SerializeField] AudioClip SpawnedEnemyFX;
    int score;
    void Start()
    {
        StartCoroutine(Spawning());
        spawnedenemies.text = score.ToString();
    }

    IEnumerator Spawning()
    {
        while (true)
        {
            score++;
            GetComponent<AudioSource>().PlayOneShot(SpawnedEnemyFX);
            spawnedenemies.text = score.ToString();
            var newEnemy = Instantiate(RespawnEnemyBody, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parent;
            yield return new WaitForSeconds(1f);
        }

    }
}
