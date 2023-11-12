using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// TODO:
// 1. Implement how do these values affect gameplay
// 2. Strategy design pattern for buttons



public class StatsTabUIExample : BaseUITab
{
    public static StatsTabUIExample StatInstance { get; private set; }

    //Current tab buttons
    [SerializeField] private ButtonDictionary statButtonDictionary;

    [SerializeField] private List<Button> statButtonsList;

    //[SerializeField] private Button applyButton;
    //[SerializeField] private Button resetButton;
    //[SerializeField] private Button cancelButton;

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
    private int statPointsMax;

    [SerializeField] private Entity entity;

    private Dictionary<TabButtons, IButtonStrategy> buttonStrategies = new Dictionary<TabButtons, IButtonStrategy>();

    private void Awake() {
        StatInstance = this;

        InitializeButtonDictionary();

        AddButtonStrategies();
        DoButtonClickEvents();
        var statPointsMax = entity.StatPoints;

        UpdateStatValuesText();
        UpdateStatPointsText();
    }

    private void ExecuteButtonStrategy(TabButtons button) {
        if (buttonStrategies.ContainsKey(button))
        {
            buttonStrategies[button].Execute(this);
        }
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
        statPointsMax = entity.StatPoints;
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
        statPointsMax = entity.StatPoints;
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
        statPointsMax = entity.StatPoints;
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

    public void ApplyButton() {
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
    public void ResetButton() {
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
    public void CancelButton() {
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

    private int UpdateStatPointsMax() => statPointsMax = entity.StatPoints;

    private int RestoreStatPointsMax() => entity.StatPoints = statPointsMax;

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

    private void UpdateStatPointsText() => statPointsText.text = $"Remaining points: {entity.StatPoints}";

    private void AddButtonStrategies() {
        buttonStrategies[TabButtons.AddStrength] = new AddStrengthStrategy();
        buttonStrategies[TabButtons.RemoveStrength] = new RemoveStrengthStrategy();
        buttonStrategies[TabButtons.AddStamina] = new AddStaminaStrategy();
        buttonStrategies[TabButtons.RemoveStamina] = new RemoveStaminaStrategy();
        buttonStrategies[TabButtons.AddAgility] = new AddAgilityStrategy();
        buttonStrategies[TabButtons.RemoveAgility] = new RemoveAgilityStrategy();
        buttonStrategies[TabButtons.AddDexterity] = new AddDexterityStrategy();
        buttonStrategies[TabButtons.RemoveDexterity] = new RemoveDexterityStrategy();
        buttonStrategies[TabButtons.Apply] = new ApplyStrategy();
        buttonStrategies[TabButtons.Reset] = new ResetStrategy();
        buttonStrategies[TabButtons.Cancel] = new CancelStrategy();
    }

    private void DoButtonClickEvents() {
        statButtonDictionary.GetButtonDictionary()[TabButtons.AddStrength].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.AddStrength));
        statButtonDictionary.GetButtonDictionary()[TabButtons.RemoveStrength].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.RemoveStrength));
        statButtonDictionary.GetButtonDictionary()[TabButtons.AddStamina].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.AddStamina));
        statButtonDictionary.GetButtonDictionary()[TabButtons.RemoveStamina].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.RemoveStamina));
        statButtonDictionary.GetButtonDictionary()[TabButtons.AddAgility].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.AddAgility));
        statButtonDictionary.GetButtonDictionary()[TabButtons.RemoveAgility].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.RemoveAgility));
        statButtonDictionary.GetButtonDictionary()[TabButtons.AddDexterity].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.AddDexterity));
        statButtonDictionary.GetButtonDictionary()[TabButtons.RemoveDexterity].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.RemoveDexterity));
        statButtonDictionary.GetButtonDictionary()[TabButtons.Apply].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.Apply));
        statButtonDictionary.GetButtonDictionary()[TabButtons.Reset].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.Reset));
        statButtonDictionary.GetButtonDictionary()[TabButtons.Cancel].onClick.AddListener(() => ExecuteButtonStrategy(TabButtons.Cancel));
    }

    private void InitializeButtonDictionary() {
        statButtonDictionary.buttonDataList = new List<ButtonDictionary.ButtonData>
    {
        new ButtonDictionary.ButtonData { type = TabButtons.AddStrength, button = statButtonsList[0]},
        new ButtonDictionary.ButtonData { type = TabButtons.RemoveStrength, button = statButtonsList[1] },
        new ButtonDictionary.ButtonData { type = TabButtons.AddStamina, button = statButtonsList[2] },
        new ButtonDictionary.ButtonData { type = TabButtons.RemoveStamina, button = statButtonsList[3] },
        new ButtonDictionary.ButtonData { type = TabButtons.AddAgility, button = statButtonsList[4] },
        new ButtonDictionary.ButtonData { type = TabButtons.RemoveAgility, button = statButtonsList[5] },
        new ButtonDictionary.ButtonData { type = TabButtons.AddDexterity, button = statButtonsList[6] },
        new ButtonDictionary.ButtonData { type = TabButtons.RemoveDexterity, button = statButtonsList[7] },
        new ButtonDictionary.ButtonData { type = TabButtons.Apply, button = statButtonsList[8] },
        new ButtonDictionary.ButtonData { type = TabButtons.Reset, button = statButtonsList[9] },
        new ButtonDictionary.ButtonData { type = TabButtons.Cancel, button = statButtonsList[10] },
        // Add other buttons as needed
    };
    }

}

public enum TabButtons
{
    AddStrength,
    RemoveStrength,
    AddStamina,
    RemoveStamina,
    AddAgility,
    RemoveAgility,
    AddDexterity,
    RemoveDexterity,
    Apply,
    Reset,
    Cancel,
}

public interface IButtonStrategy
{
    void Execute(StatsTabUIExample statsTab);
}

public class AddStrengthStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.AddStrength();
}
public class RemoveStrengthStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.RemoveStrength();
}
public class AddStaminaStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.AddStamina();
}
public class RemoveStaminaStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.RemoveStamina();
}
public class AddAgilityStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.AddAgility();
}
public class RemoveAgilityStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.RemoveAgility();

}
public class AddDexterityStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.AddDexterity();
}
public class RemoveDexterityStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.RemoveDexterity();
}
public class ApplyStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.ApplyButton();
}
public class ResetStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.ResetButton();
}
public class CancelStrategy : IButtonStrategy
{
    public void Execute(StatsTabUIExample statsTab) => statsTab.CancelButton();
}
