using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO:
// 1.Learn how to implement Graph to use for skills
// 2.Create SkillsSO to add details to skills

public class SkillsTabUI : BaseUITab
{
    public static SkillsTabUI SkillsTabInstance { get; private set; }


    private void Awake() {
        SkillsTabInstance = this;
    }
}
