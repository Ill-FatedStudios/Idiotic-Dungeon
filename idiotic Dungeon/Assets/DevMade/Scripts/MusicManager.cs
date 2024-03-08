using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public SoundPlayer MusicGroup;       //A reusable script this time used to play music tracks


    private Dictionary<AudioClip , int> PrioritySongs = new Dictionary<AudioClip, int>();

    public AudioClip[] AvaliableSongs;  //Saves all music clips avaliable in this scene 
    private AudioClip LastSong;          //Saves the last song played


    public float TimeLeft;              //Amount of time left before the next music ends

    public int CurrentPriority;

    // Start is called before the first frame update
    void Start()
    {

        AudioClip next = AvaliableSongs[0];
        TimeLeft = next.length;
        MusicGroup.ChangedPlay(0, next);
        LastSong = next;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }
        else
        {
            NextSong();
        }

    }

    //void actiated automaticly when a song ends
    public void NextSong()
    {
        AudioClip next = LastSong;
        CurrentPriority = 0;
        if (PrioritySongs.Count >= 0)
        {
            foreach (KeyValuePair<AudioClip, int> thing in PrioritySongs)
            {

                Debug.Log(thing.Key.name + "Checking" );
                if (CurrentPriority == 0)
                {
                    next = thing.Key;
                    CurrentPriority = thing.Value;
                }
                if(thing.Value >= CurrentPriority)
                {
                    next = thing.Key;
                    CurrentPriority = thing.Value;
                }
            }
        }
        else
        {
            while (next == LastSong)
            {
                next = AvaliableSongs[Random.Range(0, AvaliableSongs.Length)];
            }
        }
        TimeLeft = next.length;
        MusicGroup.ChangedPlay(0, next);
        LastSong = next;
    }

    
    public void RemovePriority(AudioClip NewSong)
    {
        PrioritySongs.Remove(NewSong);

    }

    public void AddPriority(AudioClip NewSong , int SongPriority)
    {
        Debug.Log("Added Priority");
        PrioritySongs.Add(NewSong, SongPriority);
        
        if (SongPriority >= CurrentPriority)
        {
            NextSong();
        }
    }

}
