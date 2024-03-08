using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeRE : MonoBehaviour
{
    //Reusable animation component made to be used in all animation situations

    public Animator MyAnime;        //Saves animator of the object animated by this script

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IntParameterSet(string which, int change)
    {
        MyAnime.SetInteger(which, change);
    }

    public void BoolParameterSet(string which, bool state)
    {
        MyAnime.SetBool(which, state);
    }

    public void FloatParameterSet(string which, float change)
    {
        MyAnime.SetFloat(which, change);
    }

    public void TriggerSet(string which)
    {
        MyAnime.SetTrigger(which);
    }

    public void SetingControler(string AnimeFolder, string AnimeName)
    {
        //Debug.Log("Loadable/Arena/SpellsAnims/" + AnimeName);
        MyAnime.runtimeAnimatorController = Resources.Load("Loadable/" + AnimeFolder + "/" + AnimeName) as RuntimeAnimatorController;
    }

    public void CorrectingControler(string AnimeFolder, string AnimeName)
    {
        if (MyAnime.runtimeAnimatorController != Resources.Load("Loadable/" + AnimeFolder + "/") as RuntimeAnimatorController)
        {
            MyAnime.runtimeAnimatorController = Resources.Load("Loadable/" + AnimeFolder + "/") as RuntimeAnimatorController;
        }
    }

}
