using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsTabUI : BaseUITab
{
    public static QuestsTabUI QuestsInstance { get; private set; }

    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private List<QuestSO> questList;
    [SerializeField] private GameObject questPrefab;

    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private TextMeshProUGUI questTitleText;

    //[SerializeField] private Button abbandonQuest;
    //[SerializeField] private Button trackQuest;

    ////TestButton
    //[SerializeField] private Button completeButton;

    //private List<Button> questButton;

    //private List<QuestSO> onGoingQuestsList;
    //private List<QuestSO> completedQuestsList;
    //private List<QuestSO> abbandonedQuestsList;

    private float questItemHeight = 25f;
    private float verticalSpacing = 2f;

    private void Awake() {

        QuestsInstance = this;

        AddQuestsToQuestList();

        //completeButton.onClick.AddListener(() =>
        //{

        //});
    }


    private void AddQuestsToQuestList() {
        if (questList != null)
        {

            for (int index = 0; index < questList.Count; index++)
            {
                //onGoingQuestsList.Add(quest);
                float prefabOffest = -index * (questItemHeight + verticalSpacing);

                GameObject questItem = Instantiate(questPrefab, scrollViewContent);

                QuestSO questSO = questList[index];
                if (questSO != null)
                {

                    questTitleText.text = questSO.questName;
                    questDescriptionText.text = questSO.questDescription;
                }

                RectTransform itemTransform = questItem.GetComponent<RectTransform>();
                itemTransform.anchoredPosition = new Vector2(0f, prefabOffest);
            }
            RectTransform contentTransform = scrollViewContent.GetComponent<RectTransform>();
            contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, questList.Count * (questItemHeight + verticalSpacing));
        }
        else
        {
            Debug.LogError("Go write some quests!");
        }

    }

    //private void CompleteQuest(QuestSO quest) => completedQuestsList.Add(quest);

    //private void AbbandonQuest(QuestSO quest) => abbandonedQuestsList.Add(quest);


}
