using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem LevelInstance { get; private set; }

    private int experiencePoints = 0;
    private int level = 1;
    private int maxLevel = 20;


    private void Awake() {
        LevelInstance = this;


    }

    public void AddExperience(int amount) {
        if (!IsMaxLevel())
        {
            experiencePoints += amount;
            while (!IsMaxLevel() && experiencePoints >= GetExperienceToNextLevel(level))
            {
                //Enough experience to level
                experiencePoints -= GetExperienceToNextLevel(level);
                level++;
            }
        }
    }

    public void RemoveExperience(int amount) {
        if (level != 1)
        {
            experiencePoints -= amount;
            while (level != 1 && experiencePoints <= 0)
            {

                level--;
                experiencePoints += GetExperienceToNextLevel(level);
            }
        }
        else if (level == 1 && experiencePoints < 0)
        {
            experiencePoints = 0;
        }
        else
        {
            Debug.Log($"Level is set below required ammount: {level}. RESETING!");
            level = 1;
            experiencePoints = 0;
        }
    }

    public int GetLevel() { return level; }

    public float GetExperienceNormalized() {
        if (IsMaxLevel())
        {
            return 1f;
        }
        else
        {
            return (float)experiencePoints / GetExperienceToNextLevel(level);
        }
    }

    public int GetExperience() { return experiencePoints; }

    public int GetExperienceToNextLevel(int level) {
        if (level < maxLevel)
        {
            return (int)Mathf.Pow((level / 0.13f), 2);
        }
        else
            //Invalid level
            Debug.LogError("Level invalid" + level);
        return 999999999;
    }

    public bool IsMaxLevel() {
        return IsMaxLevel(level);
    }

    public bool IsMaxLevel(int level) {
        return level == maxLevel;
    }
}
