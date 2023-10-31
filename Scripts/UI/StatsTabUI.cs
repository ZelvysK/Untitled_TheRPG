using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsTabUI : BaseUITab
{
    public static StatsTabUI StatInstance { get; private set; }

    //Current tab buttons
    [SerializeField] private List<Button> statButtonsList;

    [SerializeField] private Button applyButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button cancelButton;

    //Current tab text fields
    [SerializeField] private TextMeshProUGUI strengthText;
    [SerializeField] private TextMeshProUGUI staminaText;
    [SerializeField] private TextMeshProUGUI agilityText;
    [SerializeField] private TextMeshProUGUI dexterityText;

    [SerializeField] private TextMeshProUGUI strengthAddText;
    [SerializeField] private TextMeshProUGUI staminaAddText;
    [SerializeField] private TextMeshProUGUI agilityAddText;
    [SerializeField] private TextMeshProUGUI dexterityAddText;

    [SerializeField] private TextMeshProUGUI statPointsText;

    //Equiped items visuals
    [SerializeField] private Image helmetImage;
    [SerializeField] private Image necklaceImage;
    [SerializeField] private Image chestplateImage;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Image secondaryImage;
    [SerializeField] private Image ringImage;
    [SerializeField] private Image leggingsImage;
    [SerializeField] private Image bootsImage;

    private int addStrength = 0;
    private int addStamina = 0;
    private int addAgility = 0;
    private int addDexterity = 0;



    [SerializeField] private Entity entity;

    private void Awake() {
        StatInstance = this;
        
        var statPointsMax = entity.StatPoints;

        UpdateStatValuesText();
        UpdateStatPointsText();

        for (int i = 0; i < statButtonsList.Count; i++)
        {
            //Local var to catch index
            int buttonIndex = i;
            statButtonsList[i].onClick.AddListener(() => ButtonClickHandler(buttonIndex, statPointsMax));
        }

        applyButton.onClick.AddListener(() =>
        {
            //Apply changes
            statPointsMax = entity.StatPoints;
            UpdateStatPointsText();
            //Set text
            strengthText.text = (entity.Strength += addStrength).ToString();
            staminaText.text = (entity.Stamina += addStamina).ToString();
            agilityText.text = (entity.Agility += addAgility).ToString();
            dexterityText.text = (entity.Dexterity += addDexterity).ToString();

            //Set back to default
            addStrength = 0;
            addStamina = 0;
            addAgility = 0;
            addDexterity = 0;


            //Set add text to default
            strengthAddText.text = $"{addStrength}";
            staminaAddText.text = $"{addStamina}";
            agilityAddText.text = $"{addAgility}";
            dexterityAddText.text = $"{addDexterity}";
        });

        resetButton.onClick.AddListener(() =>
        {
            entity.StatPoints = statPointsMax;
            UpdateStatPointsText();
            //Set back to zero
            addStrength = 0;
            addStamina = 0;
            addAgility = 0;
            addDexterity = 0;


            //Set text to default
            strengthAddText.text = $"{addStrength}";
            staminaAddText.text = $"{addStamina}";
            agilityAddText.text = $"{addAgility}";
            dexterityAddText.text = $"{addDexterity}";
        });

        cancelButton.onClick.AddListener(() =>
        {
            entity.StatPoints = statPointsMax;
            UpdateStatPointsText();
            //Set back to zero
            addStrength = 0;
            addStamina = 0;
            addAgility = 0;
            addDexterity = 0;


            //Set text to default
            strengthAddText.text = $"{addStrength}";
            staminaAddText.text = $"{addStamina}";
            agilityAddText.text = $"{addAgility}";
            dexterityAddText.text = $"{addDexterity}";
        });
    }

    private void UpdateStatValuesText() {
        strengthText.text = entity.Strength.ToString();
        staminaText.text = entity.Stamina.ToString();
        agilityText.text = entity.Agility.ToString();
        dexterityText.text = entity.Dexterity.ToString();

        strengthAddText.text = $"{addStrength}";
        staminaAddText.text = $"{addStamina}";
        agilityAddText.text = $"{addAgility}";
        dexterityAddText.text = $"{addDexterity}";

    }

    private void UpdateStatPointsText() => statPointsText.text = $"Remaining points: {entity.StatPoints}";

    private void ButtonClickHandler(int buttonIndex, int statPointsMax) {
        int tempStatPoints = entity.StatPoints + addStrength + addStamina + addAgility + addDexterity;

        switch (buttonIndex)
        {
            case 0:
                //Add to Strength
                if (entity.StatPoints > 0)
                {
                    entity.StatPoints--;
                    addStrength++;
                    strengthAddText.text = $"+{addStrength}";
                    UpdateStatPointsText();
                }
                else Debug.Log("You dont have enough stat point to distribute!");
                break;
            case 1:
                //Remove from Strenght
                if (entity.StatPoints >= 0 && entity.StatPoints < statPointsMax && tempStatPoints - addStrength < statPointsMax)
                {
                    addStrength--;
                    entity.StatPoints++;
                    UpdateStatPointsText();
                    if (addStrength > 0)
                    {
                        strengthAddText.text = $"+{addStrength}";
                    }
                    else
                    {
                        addStrength = 0;
                        strengthAddText.text = $"{addStrength}";
                    }
                }
                else Debug.Log("Unable remove more points!");
                break;
            case 2:
                //Add to Stamina
                if (entity.StatPoints > 0)
                {
                    entity.StatPoints--;
                    addStamina++;
                    staminaAddText.text = $"+{addStamina}";
                    UpdateStatPointsText();
                }
                else Debug.Log("You dont have enough stat point to distribute!");
                break;
            case 3:
                //Remove from Stamina
                if (entity.StatPoints >= 0 && entity.StatPoints < statPointsMax && tempStatPoints - addStamina < statPointsMax)
                {
                    addStamina--;
                    entity.StatPoints++;
                    UpdateStatPointsText();
                    if (addStamina > 0)
                    {
                        staminaAddText.text = $"+{addStamina}";
                    }
                    else
                    {
                        addStamina = 0;
                        staminaAddText.text = $"{addStamina}";
                    }
                }
                else Debug.Log("Unable remove more points!");
                break;
            case 4:
                //Add to Agility
                if (entity.StatPoints > 0)
                {
                    entity.StatPoints--;
                    addAgility++;
                    agilityAddText.text = $"+{addAgility}";
                    UpdateStatPointsText();
                }
                else Debug.Log("You dont have enough stat point to distribute!");
                break;
            case 5:
                //Remove from Agility
                if (entity.StatPoints >= 0 && entity.StatPoints < statPointsMax && tempStatPoints - addAgility < statPointsMax)
                {
                    addAgility--;
                    entity.StatPoints++;
                    UpdateStatPointsText();
                    if (addAgility > 0)
                    {
                        agilityAddText.text = $"+{addAgility}";
                    }
                    else
                    {
                        addAgility = 0;
                        agilityAddText.text = $"{addAgility}";
                    }
                }
                else Debug.Log("Unable remove more points!");
                break;
            case 6:
                //Add to Dexterity
                if (entity.StatPoints > 0)
                {
                    entity.StatPoints--;
                    addDexterity++;
                    dexterityAddText.text = $"+{addDexterity}";
                    UpdateStatPointsText();
                }
                else Debug.Log("You dont have enough stat point to distribute!");
                break;
            case 7:
                //Remove from Dexterity
                if (entity.StatPoints >= 0 && entity.StatPoints < statPointsMax && tempStatPoints - addDexterity < statPointsMax)
                {
                    addDexterity--;
                    entity.StatPoints++;
                    UpdateStatPointsText();
                    if (addDexterity > 0)
                    {
                        dexterityAddText.text = $"+{addDexterity}";
                    }
                    else
                    {
                        addDexterity = 0;
                        dexterityAddText.text = $"{addDexterity}";
                    }
                }
                else Debug.Log("Unable remove more points!");
                break;
        }
    }

}

