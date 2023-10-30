using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private EntitySO entitySO;

    public static LevelSystem Instance { get; private set; }

    private readonly float slope = 0.13f;
    private readonly int offset = 2;

    //private int experiencePoints;
    //private int level = 1;


    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("There is more than one LevelSystem instance");
        }
        Instance = this;
    }

    //public void AddExperience(int amount) {
    //    if (!IsMaxLevel())
    //    {
    //        experiencePoints += amount;
    //        while (!IsMaxLevel() && experiencePoints >= GetExperienceToNextLevel(level))
    //        {
    //            //Enough experience to level
    //            experiencePoints -= GetExperienceToNextLevel(level);
    //            level++;
    //        }
    //    }
    //}

    //public void RemoveExperience(int amount) {
    //    if (level != 1)
    //    {
    //        experiencePoints -= amount;
    //        while (level != 1 && experiencePoints <= 0)
    //        {

    //            level--;
    //            experiencePoints += GetExperienceToNextLevel(level);
    //        }
    //    }
    //    else if (level == 1 && experiencePoints < 0)
    //    {
    //        experiencePoints = 0;
    //    }
    //    else
    //    {
    //        Debug.Log($"Level is set below minimal ammount: {level}. RESETING!");
    //        level = 1;
    //        experiencePoints = 0;
    //    }
    //}

    public float GetExperienceNormalized(Entity player) {
        if (IsMaxLevel(player))
        {
            return 1f;
        }
        else
        {
            return (float)player.ExperiencePoints/ GetExperienceToNextLevel(player.Level);
        }
    }

    public int GetExperienceToNextLevel(int level) {
        if (level < entitySO.entityMaxLevel)
        {
            return (int)Mathf.Pow((level / slope), offset);
        }
        else
        {
            //Invalid level
            Debug.LogError("Level invalid" + level);
            return int.MaxValue;
        }
    }

    public bool IsMaxLevel() => IsMaxLevel(entitySO.entityLevel);

    public bool IsMaxLevel(int level) => level == entitySO.entityMaxLevel;

    public bool IsMaxLevel(Entity entity) => entity.Level == entitySO.entityMaxLevel;
}
