using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{ 

//REUSABLE sound playing component

    public AudioSource[] AvaliableSources;       //A list of sounds avaliable to this script

    public AudioSource CurrentSource;       //Current Source in use

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BasicPlay(int which)
    {
        AvaliableSources[which].Play();
    }
    public void DelayedPlay(float delay, int which)
    {
        CurrentSource = AvaliableSources[which];
        Invoke("PlayCurrent", delay);
    }

    public void PlayCurrent()
    {
        CurrentSource.Play();
    }

    public void AdvancedPlay(int which, float Volume)
    {
        AvaliableSources[which].volume = Volume;
        AvaliableSources[which].Play();
    }

    public void TranscendedPlay(int which, float Volume, float Pitch)
    {
        AvaliableSources[which].volume = Volume;
        AvaliableSources[which].pitch = Pitch;
        AvaliableSources[which].Play();
    }

    public void BasicStop(int which)
    {
        AvaliableSources[which].Stop();
    }

    public void ChangedPlay(int which, AudioClip change)
    {
        AvaliableSources[which].clip = change;
        AvaliableSources[which].Play();
    }



}
