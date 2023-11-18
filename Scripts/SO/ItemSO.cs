using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    //public int itemLevel;
    //public int attackPowerMin;
    //public int attavkPowerMax;
    public int requiredLevel;
    public int stackSize;
    public Sprite itemSprite;
    public GameObject itemPrefab = null;
    //public List<ItemStats> itemStatValues;
}
