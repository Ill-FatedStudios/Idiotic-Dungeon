using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    public List<GameObject> CardsInDeck;

    public Transform CardCanvas;

    public Transform SpawnPosition;     //Position for spawning cards

    public float SpawnSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCards(int Amount)
    {
        for(int i = 0; i < Amount;  i++)
        {
            int random = Random.Range(0, CardsInDeck.Count);
            float SpawnXRandomization = Random.Range(-SpawnSize, SpawnSize);
            float SpawnYRandomization = Random.Range(-SpawnSize, SpawnSize);
            Instantiate(CardsInDeck[random], SpawnPosition.position + new Vector3(SpawnXRandomization, SpawnYRandomization), Quaternion.identity, CardCanvas);
        }

    }

}
