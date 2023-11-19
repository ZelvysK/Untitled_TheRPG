using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// TODO:
// Add status bar animations

public class HudUI : MonoBehaviour
{

    [SerializeField] private Entity entity;
    [SerializeField] private LevelSystem levelSystem;

    [SerializeField] private Image experienceBarImage;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Image healthBarImage;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image utilityBarImage;
    [SerializeField] private TextMeshProUGUI utilityText;


    private Entity player;

    private void Awake() {
        player = entity.CreateNewPlayer();

        UpdateVisual();
    }


    public void UpdateVisual() {
        if (player != null)
        {
            SetLevelNumber();
            SetExperienceBarSize();
            SetExperienceText();
            SetHealthBarSize();
            SetUtilityBarSize();
        }
        else
        {
            Debug.LogError("No entity or Null");
        }
    }

    private void SetExperienceBarSize() {
        if (player != null)
        {
            experienceBarImage.fillAmount = levelSystem.GetExperienceNormalized(player);
        }
        else Debug.LogError("No entity instance!");
    }

    private void SetLevelNumber() {
        if (player != null)
        {
            levelText.text = $"{player.Level}";
        }
        else Debug.LogError("No entity instance!");
    }

    private void SetExperienceText() => experienceText.text = $"{player.ExperiencePoints}/{levelSystem.GetExperienceToNextLevel(player.Level)}";

    private void SetHealthBarSize() {
        healthText.text = $"{player.HealthPoints} / {player.MaxHealthPoints}";
        healthBarImage.fillAmount = player.GetHealthNormalized();
    }

    private void SetUtilityBarSize() {
        utilityText.text = $"{player.Mana} / {player.MaxMana}";
        utilityBarImage.fillAmount = player.GetManaNormalized();
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);


}
