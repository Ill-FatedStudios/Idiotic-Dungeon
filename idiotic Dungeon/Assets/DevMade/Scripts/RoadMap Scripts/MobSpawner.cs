using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{

    public List<GameObject> Mobs;

    public float SpawnSpace;

    public int MobCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMobs(List<int> SpawnRates, int MinMobs, int MaxMobs)
    {
        int MobsToSpawn = Random.Range(MinMobs, MaxMobs);
        for(int i = 0; i < MobsToSpawn; i++)
        {
            for (int a = 0; a < SpawnRates.Count; a++)
            {
                Debug.Log(a);
                int rool = Random.Range(0, 99);
                if(rool < SpawnRates[a])
                {
                    float xPosition = Random.Range(-SpawnSpace, SpawnSpace);
                    float yPosition = Random.Range(-SpawnSpace, SpawnSpace);
                    Instantiate(Mobs[a], new Vector3(xPosition, yPosition), Quaternion.identity);
                    break;
                }
            }
        }

    }

    public void ChangeMobs(int amount)
    {
        MobCount += amount;
        if(MobCount <= 0)
        {
            FindAnyObjectByType<RoadMap>().Open();
        }
    }
}
