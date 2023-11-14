using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] public ItemTypes itemType;
    [SerializeField] public string itemName;
    //[SerializeField] public int itemLevel;
    //[SerializeField] public int attackPowerMin;
    //[SerializeField] public int attavkPowerMax;
    [SerializeField] public int requiredLevel;
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public GameObject itemPrefab = null;
    //[SerializeField] public List<ItemStats> itemStatValues;
}
