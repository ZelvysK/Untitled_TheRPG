using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : Entity
{
    private Entity entity;

    private void Start() {
        entity = CreateNewEntity();


        //Debug.Log($"{entity.CharacterName}" +
        //    $"\nLevel: {entity.Level}" +
        //    $"\nExperience: {entity.ExperiencePoints}" +
        //    $"\nStrenght: {entity.Strength}" +
        //    $"\nStamina: {entity.Stamina}" +
        //    $"\nAgility: {entity.Agility}" +
        //    $"\nDexterity: {entity.Dexterity}" +
        //    $"\nStrenght: {entity.Strength}" +
        //    $"\nStrenght: {entity.Strength}" +
        //    $"\nHealth: {entity.HealthPoints}" +
        //    $"\nMana: {entity.Mana}");

    }
    
}
