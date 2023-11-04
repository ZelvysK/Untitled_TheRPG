using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// TODO:
// Implement experience rewards after:
// 1. Killing enemies
// 2. Completing quests
// 3. Crafting?



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

    public float GetExperienceNormalized(Entity player) => IsMaxLevel(player) ? 1f : (float)player.ExperiencePoints / GetExperienceToNextLevel(player.Level);

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
