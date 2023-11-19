using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a scriptable object that describes an Item in the game.
/// This could be inherited from this to have different versions of Items
/// (e.g. Weapons, Armor, Potions...)
/// </summary>

[CreateAssetMenu(fileName ="InvItem", menuName = "Inventory System/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public int ID;
    public string DisplayName;
    [TextArea(4,4)] 
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    public int GoldValue;
}
