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
}
