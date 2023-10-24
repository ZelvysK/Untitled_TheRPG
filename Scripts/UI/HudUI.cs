using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    [SerializeField] private Image experienceBarImage;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI levelText;

    private LevelSystem levelSystem = new LevelSystem();

    private void Awake() {

        SetLevelNumber();
        SetExperienceBarSize();
        SetExperienceText();
    }

    private void SetExperienceBarSize() {
        experienceBarImage.fillAmount = levelSystem.GetExperienceNormalized();
    }

    private void SetLevelNumber() {
        levelText.text = levelSystem.GetLevel().ToString();
    }

    private void SetExperienceText() {
        experienceText.text = levelSystem.GetExperience().ToString() + "/" + levelSystem.GetExperienceToNextLevel(levelSystem.GetLevel()).ToString();
    }
}
