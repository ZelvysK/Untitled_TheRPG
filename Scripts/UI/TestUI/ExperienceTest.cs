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



    private void Awake() {
        Instance = this;

        buttonAdd10.onClick.AddListener(() => { LevelSystem.LevelInstance.AddExperience(10); HudUI.Instance.UpdateVisual(); });
        buttonAdd100.onClick.AddListener(() =>{ LevelSystem.LevelInstance.AddExperience(100); HudUI.Instance.UpdateVisual(); });
        buttonAdd1000.onClick.AddListener(() =>{ LevelSystem.LevelInstance.AddExperience(1000); HudUI.Instance.UpdateVisual(); });
        buttonAdd5000.onClick.AddListener(() =>{ LevelSystem.LevelInstance.AddExperience(5000); HudUI.Instance.UpdateVisual(); });

        buttonRemove10.onClick.AddListener(() =>{ LevelSystem.LevelInstance.RemoveExperience(10); HudUI.Instance.UpdateVisual(); });
        buttonRemove100.onClick.AddListener(() =>{ LevelSystem.LevelInstance.RemoveExperience(100); HudUI.Instance.UpdateVisual(); });
        buttonRemove1000.onClick.AddListener(() =>{ LevelSystem.LevelInstance.RemoveExperience(1000); HudUI.Instance.UpdateVisual(); });
        buttonRemove5000.onClick.AddListener(() =>{ LevelSystem.LevelInstance.RemoveExperience(5000); HudUI.Instance.UpdateVisual(); });

        closeButton.onClick.AddListener(() => { Hide(); });

        gameObject.SetActive(false);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
