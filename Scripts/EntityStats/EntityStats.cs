using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : LevelSystem
{
    
    public static int SetMaxHealth(int level) {
        int health = 100;

        return health;
    }

    public static int SetMaxMana(int level) { 
        int mana = 100;

        return mana;
    }
}

public class Entity : EntityStats
{
    public string CharacterName { get; private set; }
    public int Level { get; private set; }
    public int ExperiencePoints { get; private set; }
    public int HealthPoints { get; private set; }
    public int Mana { get; private set; }



    public Entity CreateEntity() {

        Entity entity = new Entity();

        entity.CharacterName = CharacterName;
        entity.Level = Instance.GetLevel();
        entity.ExperiencePoints = Instance.GetExperience();
        entity.HealthPoints = SetMaxHealth(entity.Level);
        entity.Mana = SetMaxMana(entity.Level);

        return entity;
    }

}