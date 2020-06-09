using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats 
{
    [Header("General Stuff")]
    public string PlayerName;
    public int[] Colors;
    public int[] Armor;

    [Header("Unlocks")]
    public bool[] weaponsUnlocked;
    public bool[] ArmorsUnlocked;
    public bool[] CutscenesUnlocked;

    [Header("StageData")]
    public bool[] stagesCompleted;
    public bool[] stagesUnlocked;
    public bool[,] stageSecrets;

    public PlayerStats() {
        //general player data
        PlayerName = "Prototype V5";
        CutscenesUnlocked = new bool[8] { false, false, false, false, false, false, false, false };
        Colors = new int[4] { 0, 2, 4, 2 };
        Armor = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0};
        weaponsUnlocked = new bool[5] { true, false, false, false, false };
        ArmorsUnlocked = new bool[5] {true, false, false, false, false};
        stagesUnlocked = new bool[8] { true, false, false, false, false, false, false, false };
        stagesCompleted = new bool[8] { false, false, false, false, false, false,false,false };
        stageSecrets = new bool[4,3] { { false, false, false }, { false, false, false } , { false, false, false } , { false, false, false } };
    }
}
