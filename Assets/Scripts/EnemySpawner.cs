using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Player;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Difficulty settings")]
   
    [SerializeField] [Min(1)] private int difficulty;


    [Space(50)]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemyStats[] enemies;
    [SerializeField] private GameObject[] spawnLocations;


    [Space(50)]
    [SerializeField] private GameObject waveTextContainer;
    [SerializeField] private GameObject enemyCountTextContainer;

    private PlayerUI playerUI;


    private int currentWave = 0;
    private int enemyCount = 0;


    private void Start()
    {
        playerUI = GameObject.Find("Player").GetComponent<PlayerUI>();
        NextWave();
    }


    // Update is called once per frame
    void Update()
    {
        enemyCountTextContainer.GetComponent<TMP_Text>().text = "Enemies left: " + enemyCount.ToString();
        if(enemyCount == 0)
        {
            playerUI.SelectUpgrade();
        }
    }

    // Called everytime a wave is finished and player has selected level.
    public void NextWave()
    {
        currentWave++;
        waveTextContainer.GetComponent<TMP_Text>().text = currentWave.ToString();
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = difficulty * currentWave * 3;
        enemyCount = enemiesToSpawn;

        for(int i = 0; i < enemiesToSpawn; i++)
        {
            // Unlocks a new enemy every 3 waves if there exists a new one.
            int maxEnemy = Mathf.Min(enemies.Length-1, (int)Mathf.Floor(currentWave / 3) + 1);
            int enemyType = Random.Range(0, maxEnemy);

            Debug.Log("Type: " + enemyType);


            // Selects a random location
            int location = Random.Range(0, spawnLocations.Length-1);
            Debug.Log("Loc:" + location);

            // Adds an offset so that they dont spawn fully inside of eachtoher.
            Vector3 offset = new Vector3(Random.Range(-5.00f,5.00f), Random.Range(-5.00f,5.00f), 0);

            // Spawns the enemy at the location plus the offset.
            GameObject enemy = Instantiate(enemyPrefab, spawnLocations[location].transform.position + offset, Quaternion.identity);
            enemy.GetComponent<Enemy>().stats = enemies[enemyType];
        }
    }

    // Called everytime an enemy is killed.
    public void KilledEnemy()
    {
        enemyCount--;
    }
}
