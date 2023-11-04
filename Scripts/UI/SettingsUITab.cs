using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO:
// 1. Add buttons to change KeyBingings
// 2. Add Sound & Music settings

public class SettingsUITab : BaseUITab
{
    public static SettingsUITab SettingsTabInstance { get; private set; }


    private void Awake() {
        SettingsTabInstance = this;
    }
}
