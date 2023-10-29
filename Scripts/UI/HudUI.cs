using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    public static HudUI Instance;

    [SerializeField] private Entity entity;

    [SerializeField] private Image experienceBarImage;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Image healthBarImage;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image utilityBarImage;
    [SerializeField] private TextMeshProUGUI utilityText;


    private Entity player;

    private void Awake() {
        Instance = this;
        player = entity.CreateNewEntity();

        UpdateVisual();
    }

    public void UpdateVisual() {
        if (Instance != null)
        {
            SetLevelNumber();
            SetExperienceBarSize();
            SetExperienceText();
            SetHealthBarSize();
            SetUtilityBarSize();
        }
        else
        {
            Debug.LogError("No Instance or Null");
        }
    }

    private void SetExperienceBarSize() {
        experienceBarImage.fillAmount = LevelSystem.LevelInstance.GetExperienceNormalized();
    }

    private void SetLevelNumber() {
        levelText.text = $"{LevelSystem.LevelInstance.GetLevel()}";
    }

    private void SetExperienceText() {
        experienceText.text = $"{LevelSystem.LevelInstance.GetExperience()}/{LevelSystem.LevelInstance.GetExperienceToNextLevel(LevelSystem.LevelInstance.GetLevel())}";
    }

    private void SetHealthBarSize() {
        healthText.text = $"{Entity.EntityInstance.GetHealthPoints(player)}/{Entity.EntityInstance.GetMaxHealthPoints(player)}";
        healthBarImage.fillAmount = Entity.EntityInstance.GetHealthNormalized(player);
    }

    private void SetUtilityBarSize() {
        utilityText.text = $"{Entity.EntityInstance.GetMana(player)}/{Entity.EntityInstance.GetMaxMana(player)}";
        utilityBarImage.fillAmount = Entity.EntityInstance.GetManaNormalized(player);
    }
}
