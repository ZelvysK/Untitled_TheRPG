using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EntitySO", menuName ="ScriptableObjects/EntitySO")]
public class EntitySO : ScriptableObject
{
    public string entityName = "EntityName";
    public int entityLevel = 1;
    public int entityMaxLevel = 20;
    public int entityExperiencePoints = 0;

    public int entityHealth;
    public int entityMaxHealth;
    public int entityMana;
    public int entityMaxMana;

    public int entityStrength;
    public int entityStamina;
    public int entityAgility;
    public int entityDexterity;

    public int entityStatPoints = 20;

}
