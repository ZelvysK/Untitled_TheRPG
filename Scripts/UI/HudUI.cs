using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    public static HudUI Instance;

    [SerializeField] private Image experienceBarImage;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Image healthBarImage;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image utilityBarImage;
    [SerializeField] private TextMeshProUGUI utilityText;

    private void Awake() {
        Instance = this;
        //levelSystem.AddComponent<LevelSystem>();

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
        experienceBarImage.fillAmount = LevelSystem.Instance.GetExperienceNormalized();
    }

    private void SetLevelNumber() {
        levelText.text = LevelSystem.Instance.GetLevel().ToString();
    }

    private void SetExperienceText() {
        experienceText.text = LevelSystem.Instance.GetExperience().ToString() + "/" + LevelSystem.Instance.GetExperienceToNextLevel(LevelSystem.Instance.GetLevel()).ToString();
    }

    private void SetHealthBarSize() {

    }

    private void SetUtilityBarSize() {

    }
}
