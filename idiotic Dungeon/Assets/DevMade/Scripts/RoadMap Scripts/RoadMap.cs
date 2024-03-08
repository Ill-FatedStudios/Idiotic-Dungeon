using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadMap : MonoBehaviour
{

    public Transform MapPlayer;

    public float PlayerSpeed;

    public bool Moving = false;

    public RoadPoint CurrentPoint;

    public LevelStarter levelStarter;

    public GameObject Graphics, EndGraphics;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(MapPlayer.transform.position, CurrentPoint.transform.position);
        MapPlayer.transform.position = Vector3.MoveTowards(MapPlayer.transform.position, CurrentPoint.transform.position, (PlayerSpeed + distance) * Time.deltaTime);
        if(Moving && distance < 0.1f)
        {
            Moving = false;
            Arrived();
        }
        
    }

    private void Arrived()
    {
        levelStarter.StartLevel(CurrentPoint.levelStats);
        Graphics.SetActive(false);

    }

    public void ChangePoint(RoadPoint RP)
    {
        foreach (Button thing in CurrentPoint.NextPoints)
        {
            thing.interactable = false;
        }

        CurrentPoint = RP;
        Moving = true;

    }

    public void Open()
    {
        if (CurrentPoint.EndPoint)
        {
            EndGraphics.SetActive(true);
            return;
        }
        foreach (Button thing in CurrentPoint.NextPoints)
        {
            thing.interactable = true;
        }
        Graphics.SetActive(true);

    }
}
