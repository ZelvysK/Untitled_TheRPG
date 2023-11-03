using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "ScriptableObjects/QuestSO")]
public class QuestSO : ScriptableObject
{
    public string questName = "TestQuest";

    public string questDescription = string.Empty;
    public int experienceRewards;
    public int goldRewards;

    //public ItemObject questRewards;
    
    //NiceToHave
    //public int reputationRewards;



}
