using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Difficulty settings")]
   
    [SerializeField] [Min(1)] private int difficulty;


    [Space(50)]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemyStats[] enemies;
    [SerializeField] private GameObject[] spawnLocations;


    private int currentWave = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemies()
    {
        int enemiesToSpawn = difficulty * currentWave * 5;
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyType = Random.Range(0, enemies.Length - 1);
            int location = Random.Range(0, spawnLocations.Length-1);

            GameObject enemy = Instantiate(enemyPrefab, spawnLocations[location].transform.position + new Vector3(Random.Range(1,10), Random.Range(1, 10), 0), Quaternion.identity);
            enemy.GetComponent<Enemy>().stats = enemies[enemyType];
        }
    }
}
