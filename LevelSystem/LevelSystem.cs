using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelSystem
{

    private int level = 1;
    private int experience = 0;
    private int maxLevel = 20;



    public void AddExperience(int amount) {
        if (!IsMaxLevel())
        {
            experience += amount;
            while (!IsMaxLevel() && experience >= GetExperienceToNextLevel(level))
            {
                //Enough experience to level
                experience -= GetExperienceToNextLevel(level);
                level++;
            }
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
            return (float)experience / GetExperienceToNextLevel(level);
        }
    }

    public int GetExperience() { return experience; }

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
