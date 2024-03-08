using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : SimpleRandomWalkDungeonGeneration
{

    public MobSpawner mobSpawner;

    public GameObject RoadCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel(LevelStats LS)
    {
        RunRandomWalk(LS.RoomPref, new Vector2Int(0,0));
        mobSpawner.SpawnMobs(LS.SpawnRates, LS.MinMobs, LS.MaxMobs);
        Invoke("LevelStart", 1f);
    }

    public void LevelStart()
    {
        RoadCanvas.SetActive(false);
    }
}
