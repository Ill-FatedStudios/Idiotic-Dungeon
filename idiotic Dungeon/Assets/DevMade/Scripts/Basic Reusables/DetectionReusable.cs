using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectionReusable : MonoBehaviour
{

    public EventHandler EntranceEvent;      //Activated when the wanted object enters detection
    public EventHandler QuitingEvent;       //Activated when the wanted object exits detection

    public List<EventHandler> EntranceEvents;       //Events that are to be activated when entrance is detected
    public List<EventHandler> ExitingEvents;        //Events that are to be activated when exit is detected

    public GameObject EnteredObject;        //Acceses the last entering object
    public GameObject ExitedObject;         //Acceses the last exiting object

    [SerializeField]
    private EventCordRE EnteringCord;
    [SerializeField]
    private EventCordRE ExitingCord;


    public List<string> SearchedTags;       //Tags of objects that are searched for


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D thing)
    {
        foreach(string id in SearchedTags)
        {
            if(thing.CompareTag(id))
            {
                TargetEntered(thing.gameObject);
                break;
            }
        }
    }


    public void TargetEntered(GameObject target)
    {

        EnteredObject = target;
        EntranceEvent?.Invoke(this, EventArgs.Empty);

        if (EnteringCord != null)
        {
            ArgumentsRE newArgs = new ArgumentsRE();
            newArgs.EventObject = target;
            EnteringCord.ActivateCord(newArgs);
        }
    }


    private void OnTriggerExit2D(Collider2D thing)
    {
        foreach(string id in SearchedTags)
        {
            if(thing.CompareTag(id))
            {
                TargetExited(thing.gameObject);
                break;
            }
        }
    }


    public void TargetExited(GameObject target)
    {
        ExitedObject = target;
        QuitingEvent?.Invoke(this, EventArgs.Empty);

        if (ExitingCord != null)
        {
            ArgumentsRE newArgs = new ArgumentsRE();
            newArgs.EventObject = target;
            ExitingCord.ActivateCord(newArgs);
        }
    }

}
