using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO:
// 1. Implement Map and display player position
// 2. Display enemy position when added
// 3. Display NPC position when added

public class MapTabUI : BaseUITab
{
    public static MapTabUI MapTabInstance {  get; private set; }


    private void Awake() {
        MapTabInstance = this;
    }
}
