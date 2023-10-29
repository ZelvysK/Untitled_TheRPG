using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{
    public static Entity EntityInstance { get; private set; }

    //private string characterName;
    //private int level;
    //private int experiencePoints;
    private int health = 100;
    private int mana = 100;
    private int maxHealth = 100;
    private int maxMana = 100;
    private int strength = 10;
    private int stamina = 10;
    private int agility = 10;
    private int dexterity = 10;


    public string CharacterName { get; private set; }
    public int Level { get; private set; }
    public int ExperiencePoints { get; private set; }
    public int StatPoints { get; set; } = 20;
    public int HealthPoints { get; private set; }
    public int MaxHealthPoints { get; private set; }
    public int Mana { get; private set; }
    public int MaxMana { get; private set; }
    public int Strength { get; private set; }
    public int Stamina { get; private set; }
    public int Agility { get; private set; }
    public int Dexterity { get; private set; }


    private void Awake() { EntityInstance = this; }

    public Entity CreateNewPlayer() {

        Entity player = this;

        player.CharacterName = "Charlie";
        player.Level = LevelSystem.LevelInstance.GetLevel();
        player.ExperiencePoints = LevelSystem.LevelInstance.GetExperience();
        player.MaxHealthPoints = maxHealth;
        player.HealthPoints = health;
        player.MaxMana = maxMana;
        player.Mana = mana;
        player.Strength = strength;
        player.Stamina = stamina;
        player.Agility = agility;
        player.Dexterity = dexterity;

        return player;
    }

    public int GetMaxHealthPoints(Entity entity) {

        return entity.MaxHealthPoints;
    }
    public int GetHealthPoints(Entity entity) {
        return entity.HealthPoints;
    }
    public int GetMaxMana(Entity entity) {
        return entity.MaxMana;
    }
    public int GetMana(Entity entity) {
        return entity.Mana;
    }
    public float GetHealthNormalized(Entity entity) {
        return (float)entity.HealthPoints / entity.MaxHealthPoints;
    }
    public float GetManaNormalized(Entity entity) {
        return (float)entity.Mana / entity.MaxMana;
    }

}