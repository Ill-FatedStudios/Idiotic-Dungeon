using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Reusable EventArgs
public class ArgumentsRE : EventArgs
{

    public List<Hashtable> EventHashes = new List<Hashtable>();
    //Hashes going thfrou the event 


    public List<GameObject> EventObjects = new List<GameObject>();
    public GameObject EventObject;

    public Transform EventTransform; 


    public Vector3 EventPosition;


    public float PreciseValue = 0;


    public int Value = 0;
    public int SecondValue = 0;

    public List<int> Values = new List<int>();


    public string content = "";

    public List<string> Contents;
    public List<List<string>> Contents2D = new List<List<string>>();


    public bool ZeroAction = false;
    public bool FirstAction = false;
}
