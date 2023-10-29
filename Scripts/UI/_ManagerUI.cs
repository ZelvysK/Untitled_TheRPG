using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ManagerUI : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    // Seperate script for each UI element to show/hide
    // This is for main control

    private void Start() {
        gameInput.OnExperienceTest += GameInput_OnExperienceTest;
    }

    private void GameInput_OnExperienceTest(object sender, System.EventArgs e) {
            ExperienceTest.Instance.Show();
    }

}
