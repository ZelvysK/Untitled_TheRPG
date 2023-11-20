using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSaveData : MonoBehaviour
{
    public int currentHealth = 100;
    private PlayerData MyData = new PlayerData();

    private Player player;


    private void Awake() {
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update() {
        var transform1 = transform;
        MyData.PlayerPosition = transform1.position;
        MyData.PlayerRotation = transform1.rotation;
        MyData.CurrentHealth = currentHealth;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SaveGameManager.CurrentSaveData.PlayerData = MyData;
            SaveGameManager.SaveGame();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            player.enabled = false;

            SaveGameManager.LoadGame();
            MyData = SaveGameManager.CurrentSaveData.PlayerData;
            transform1.position = MyData.PlayerPosition;
            transform1.rotation = MyData.PlayerRotation;
            MyData.CurrentHealth = currentHealth;

            Invoke(nameof(EnablePlayer), 0.25f);
        }
    }
    private void EnablePlayer() {
        player.enabled = true;
    }
}


[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public int CurrentHealth;
}
