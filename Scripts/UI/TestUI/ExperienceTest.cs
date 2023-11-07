using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceTest : MonoBehaviour
{
    public static ExperienceTest Instance { get; private set; }
    [SerializeField] private Button buttonAdd10;
    [SerializeField] private Button buttonAdd100;
    [SerializeField] private Button buttonAdd1000;
    [SerializeField] private Button buttonAdd5000;

    [SerializeField] private Button buttonRemove10;
    [SerializeField] private Button buttonRemove100;
    [SerializeField] private Button buttonRemove1000;
    [SerializeField] private Button buttonRemove5000;

    [SerializeField] private Button closeButton;

    [SerializeField] private LevelSystem levelSystem;

    private int experiencePoints;
    private int level = 1;


    private void Awake() {
        Instance = this;

        buttonAdd10.onClick.AddListener(() => { AddExperience(10); HudUI.Instance.UpdateVisual(); });
        buttonAdd100.onClick.AddListener(() => { AddExperience(100); HudUI.Instance.UpdateVisual(); });
        buttonAdd1000.onClick.AddListener(() => { AddExperience(1000); HudUI.Instance.UpdateVisual(); });
        buttonAdd5000.onClick.AddListener(() => { AddExperience(5000); HudUI.Instance.UpdateVisual(); });

        buttonRemove10.onClick.AddListener(() => { RemoveExperience(10); HudUI.Instance.UpdateVisual(); });
        buttonRemove100.onClick.AddListener(() => { RemoveExperience(100); HudUI.Instance.UpdateVisual(); });
        buttonRemove1000.onClick.AddListener(() => { RemoveExperience(1000); HudUI.Instance.UpdateVisual(); });
        buttonRemove5000.onClick.AddListener(() => { RemoveExperience(5000); HudUI.Instance.UpdateVisual(); });

        closeButton.onClick.AddListener(() => { Hide(); });

        gameObject.SetActive(false);
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void AddExperience(int amount) {
        if (levelSystem.IsMaxLevel()) return;

        experiencePoints += amount;
        while (!levelSystem.IsMaxLevel() && experiencePoints >= levelSystem.GetExperienceToNextLevel(level))
        {
            //Enough experience to level
            experiencePoints -= levelSystem.GetExperienceToNextLevel(level);
            level++;
        }
        Debug.Log($"Added: {amount} of experience!\n New level is {level} with experience: {experiencePoints}");
    }

    public void RemoveExperience(int amount) {
        if (level != 1)
        {
            experiencePoints -= amount;
            while (level != 1 && experiencePoints <= 0)
            {
                level--;
                experiencePoints += levelSystem.GetExperienceToNextLevel(level);
            }
            Debug.Log($"Removed {amount} experience!\nNew level is {level} with experience: {experiencePoints}");
        }
        else if (level == 1 && experiencePoints < 0)
        {
            experiencePoints = 0;
            Debug.Log("Couldn't remove experience!");
        }
        else
        {
            Debug.Log($"Level is set below minimal ammount: {level}. RESETING!");
            level = 1;
            experiencePoints = 0;
        }
    }
}
