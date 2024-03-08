using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "levelStats" , fileName = "Level_")]
public class LevelStats : ScriptableObject 
{
    public List<int> SpawnRates;

    public int MaxMobs, MinMobs;

    public SimpleRandomWalkSO RoomPref;
}

