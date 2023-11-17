using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script

    void Start() {
        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies() {
        // Call the SpawnEnemy method to spawn an enemy
        enemySpawner.SpawnEnemy();
    }
}
