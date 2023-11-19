using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EntitySO enemyEntitySO; // Reference to the enemy EntitySO

    // Method to create a new enemy
    public Entity CreateNewEnemy() {
        var enemy = new Entity();

        // Set enemy properties from EntitySO
        enemy.EntityName = enemyEntitySO.entityName;
        enemy.Level = enemyEntitySO.entityLevel;
        enemy.ExperiencePoints = enemyEntitySO.entityExperiencePoints;
        enemy.MaxHealthPoints = enemyEntitySO.entityMaxHealth;
        enemy.HealthPoints = enemyEntitySO.entityHealth;
        enemy.MaxMana = enemyEntitySO.entityMaxMana;
        enemy.Mana = enemyEntitySO.entityMana;

        return enemy;
    }

    // Method to spawn a new enemy in the scene
    public void SpawnEnemy() {
        Entity newEnemy = CreateNewEnemy();

        // Load the enemy prefab from the Resources folder (replace "EnemyPrefab" with the actual prefab name)
        GameObject enemyPrefab = Resources.Load("Enemies/Slime") as GameObject;

        if (enemyPrefab != null)
        {
            // Instantiate the enemy prefab
            GameObject enemyGO = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Attach the Entity component to the newly instantiated GameObject
            Entity enemyEntity = enemyGO.GetComponent<Entity>();

            if (enemyEntity != null)
            {
                // Set the properties of the Entity component based on the created enemy
                enemyEntity.EntityName = newEnemy.EntityName;
                enemyEntity.Level = newEnemy.Level;
                enemyEntity.ExperiencePoints = newEnemy.ExperiencePoints;
                enemyEntity.MaxHealthPoints = newEnemy.MaxHealthPoints;
                enemyEntity.HealthPoints = newEnemy.HealthPoints;
                enemyEntity.MaxMana = newEnemy.MaxMana;
                enemyEntity.Mana = newEnemy.Mana;
            }
            else
            {
                Debug.LogError("The instantiated enemy GameObject is missing the Entity component.");
            }
        }
        else
        {
            Debug.LogError("Enemy prefab not found in Resources folder. Make sure it's assigned and located in the Resources folder.");
        }
    }
}
