using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVizualizer : MonoBehaviour
{

    public List<AnimeRE> Healths;

    public void VizualizeHealth(int amount)
    {
        foreach(AnimeRE thing in Healths)
        {
            thing.TriggerSet("Fade");
            thing.gameObject.SetActive(false);
        }

        for(int i = 0; i < amount; i++)
        {
            Healths[i].gameObject.SetActive(true);
        }
    }
}
