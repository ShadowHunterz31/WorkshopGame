using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASpawner : MonoBehaviour
{
    public EnemyScriptable[] EnemiesBrain;
    public GameObject EnemyPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0 ,1);
    }

    public void SpawnEnemy()
    {
        var enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<IAController>().Init(EnemiesBrain[Random.Range(0,EnemiesBrain.Length)]);
    }


}
