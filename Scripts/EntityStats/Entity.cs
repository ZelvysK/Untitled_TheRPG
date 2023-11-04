using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{
    //public static Entity Instance { get; private set; }

    [SerializeField] private EntitySO entitySO;

    //private string characterName;
    //private int level;
    //private int experiencePoints;
    //private int statPoints = 20;
    //private int health = 100;
    //private int mana = 100;
    //private int maxHealth = 100;
    //private int maxMana = 100;
    //private int strength = 10;
    //private int stamina = 10;
    //private int agility = 10;
    //private int dexterity = 10;


    public string CharacterName { get;  set; }
    public int Level { get;  set; }
    public int ExperiencePoints { get; set; }
    public int StatPoints { get; set; }
    public int HealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public int Strength { get; set; }
    public int Stamina { get; set; }
    public int Agility { get; set; }
    public int Dexterity { get; set; }


    private void Awake() {
        //Instance = this;
    }

    public Entity CreateNewPlayer() {

        Entity player = this;

        player.CharacterName = entitySO.entityName;
        player.Level = entitySO.entityLevel;
        player.ExperiencePoints = entitySO.entityExperiencePoints;
        player.MaxHealthPoints = entitySO.entityMaxHealth;
        player.HealthPoints = entitySO.entityHealth;
        player.MaxMana = entitySO.entityMaxMana;
        player.Mana = entitySO.entityMana;
        player.Strength = entitySO.entityStrength;
        player.Stamina = entitySO.entityStamina;
        player.Agility = entitySO.entityAgility;
        player.Dexterity = entitySO.entityDexterity;
        player.StatPoints = entitySO.entityStatPoints;

        return player;
    }

    public float GetHealthNormalized() => (float)HealthPoints / MaxHealthPoints;

    public float GetManaNormalized() => (float)Mana / MaxMana;

}