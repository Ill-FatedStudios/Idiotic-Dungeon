using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This scirpt exist solely for collecting and distributing events
public class EventCordRE : MonoBehaviour
{
    [SerializeField]
    private List<EventHandler<ArgumentsRE>> Cord = new List<EventHandler<ArgumentsRE>>();        //Saves all events in the cord


    public void ExtendCord(EventHandler<ArgumentsRE> thing)
    {

        Cord.Add(thing);

    }


    public void EditCord(EventHandler<ArgumentsRE> thing)
    {
        for (int i = 0; i < Cord.Count; i++)
        {
            if (thing == Cord[i])
            {
                Cord.RemoveAt(i);

                break;

            }

        }
    }


    public List<EventHandler<ArgumentsRE>> GetCord()
    {
        return Cord;
    }

    public void ActivateCord(ArgumentsRE NewArguments)
    {
        foreach (EventHandler<ArgumentsRE> thing in Cord)
        {
            thing?.Invoke(this, NewArguments);
        }
    }    
    
    public void ActivateGUICord()
    {
        foreach (EventHandler<ArgumentsRE> thing in Cord)
        {
            thing?.Invoke(this, new ArgumentsRE());
        }
    }

}
