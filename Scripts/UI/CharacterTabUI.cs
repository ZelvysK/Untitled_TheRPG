using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTabUI : BaseUITab
{
    //REFERENCES
    [SerializeField] private Entity entity;
    //private TabUIManager tabUIManager;

    //Tab Buttons
    [SerializeField] private List<ExtendedButton> buttons;

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

    //VARIABLES
    //Local
    private int addStrength = 0;
    private int addStamina = 0;
    private int addAgility = 0;
    private int addDexterity = 0;
    private int statPointsMax;
    

    private Dictionary<CharacterTabButtons, Action> ButtonToActionMap;

    private void Awake() {
        //BaseUITab playerTab = new BaseUITab();
        //tabUIManager.AddTab(playerTab);

        InitializeButtonActionMap();

        Debug.Log($"Start Awake statP: {statPointsMax}");

        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => Execute(button.ButtonType));
        }

        UpdateStatValuesText();
        UpdateStatPointsText();

        statPointsMax = entity.StatPoints;
        Debug.Log($"End Awake statP: {statPointsMax}");

    }

    private void InitializeButtonActionMap() {
        ButtonToActionMap = new Dictionary<CharacterTabButtons, Action>
        {
            { CharacterTabButtons.AddStrength, AddStrength },
            { CharacterTabButtons.RemoveStrength, RemoveStrength },
            { CharacterTabButtons.AddStamina, AddStamina },
            { CharacterTabButtons.RemoveStamina, RemoveStamina },
            { CharacterTabButtons.AddAgility, AddAgility },
            { CharacterTabButtons.RemoveAgility, RemoveAgility },
            { CharacterTabButtons.AddDexterity, AddDexterity },
            { CharacterTabButtons.RemoveDexterity, RemoveDexterity },
            { CharacterTabButtons.Apply, ApplyStatChanges },
            { CharacterTabButtons.Reset, ResetStatChanges },
            { CharacterTabButtons.Cancel, CancelStatChanges },
        };
    }
    public void Execute(CharacterTabButtons buttonType) {
        ButtonToActionMap[buttonType].Invoke();
    }
    public void AddStrength() {
        //Add to Strength
        if (entity.StatPoints > 0)
        {
            entity.StatPoints--;
            addStrength++;
            strengthAddText.text = $"+{addStrength}";
            UpdateStatPointsText();
        }
        else Debug.Log("You dont have enough stat point to distribute!");
    }
    public void RemoveStrength() {
        //Remove from Strenght
        var tempStatPoints = entity.StatPoints + addStrength + addStamina + addAgility + addDexterity;

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
        UpdateStatPointsMax();
    }
    public void AddStamina() {
        //Add to Stamina
        if (entity.StatPoints > 0)
        {
            entity.StatPoints--;
            addStamina++;
            staminaAddText.text = $"+{addStamina}";
            UpdateStatPointsText();
        }
        else Debug.Log("You dont have enough stat point to distribute!");
    }
    public void RemoveStamina() {
        //Remove from Stamina
        var tempStatPoints = entity.StatPoints + addStrength + addStamina + addAgility + addDexterity;

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
    }
    public void AddAgility() {
        //Add to Agility
        if (entity.StatPoints > 0)
        {
            entity.StatPoints--;
            addAgility++;
            agilityAddText.text = $"+{addAgility}";
            UpdateStatPointsText();
        }
        else Debug.Log("You dont have enough stat point to distribute!");
    }
    public void RemoveAgility() {
        //Remove from Agility
        var tempStatPoints = entity.StatPoints + addStrength + addStamina + addAgility + addDexterity;

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
    }
    public void AddDexterity() {
        //Add to Dexterity
        if (entity.StatPoints > 0)
        {
            entity.StatPoints--;
            addDexterity++;
            dexterityAddText.text = $"+{addDexterity}";
            UpdateStatPointsText();
        }
        else Debug.Log("You dont have enough stat point to distribute!");
    }
    public void RemoveDexterity() {
        //Remove from Dexterity
        var tempStatPoints = entity.StatPoints + addStrength + addStamina + addAgility + addDexterity;

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
    }
    public void ApplyStatChanges() {
        //Apply changes
        UpdateStatPointsMax();
        UpdateStatPointsText();

        //Set text
        entity.Strength += addStrength;
        strengthText.text = entity.Strength.ToString();
        entity.Stamina += addStamina;
        staminaText.text = entity.Stamina.ToString();
        entity.Agility += addAgility;
        agilityText.text = entity.Agility.ToString();
        entity.Dexterity += addDexterity;
        dexterityText.text = entity.Dexterity.ToString();

        //Set back to default
        addStrength = 0;
        addStamina = 0;
        addAgility = 0;
        addDexterity = 0;

        //Set add text to default
        strengthAddText.text = addStrength.ToString();
        staminaAddText.text = addStamina.ToString();
        agilityAddText.text = addAgility.ToString();
        dexterityAddText.text = addDexterity.ToString();
    }
    public void ResetStatChanges() {
        RestoreStatPointsMax();
        UpdateStatPointsText();

        //Set back to default
        addStrength = 0;
        addStamina = 0;
        addAgility = 0;
        addDexterity = 0;

        //Set text to default
        strengthAddText.text = addStrength.ToString();
        staminaAddText.text = addStamina.ToString();
        agilityAddText.text = addAgility.ToString();
        dexterityAddText.text = addDexterity.ToString();
    }
    public void CancelStatChanges() {
        RestoreStatPointsMax();
        UpdateStatPointsText();

        //Set back to zero
        addStrength = 0;
        addStamina = 0;
        addAgility = 0;
        addDexterity = 0;

        //Set text to default
        strengthAddText.text = addStrength.ToString();
        staminaAddText.text = addStamina.ToString();
        agilityAddText.text = addAgility.ToString();
        dexterityAddText.text = addDexterity.ToString();
    }
    private int RestoreStatPointsMax() => entity.StatPoints = statPointsMax;
    private void UpdateStatPointsText() => statPointsText.text = $"Remaining points: {entity.StatPoints}";
    private int UpdateStatPointsMax() => statPointsMax = entity.StatPoints;
    private void UpdateStatValuesText() {
        strengthText.text = entity.Strength.ToString();
        staminaText.text = entity.Stamina.ToString();
        agilityText.text = entity.Agility.ToString();
        dexterityText.text = entity.Dexterity.ToString();

        strengthAddText.text = addStrength.ToString();
        staminaAddText.text = addStamina.ToString();
        agilityAddText.text = addAgility.ToString();
        dexterityAddText.text = addDexterity.ToString();
    }

}


