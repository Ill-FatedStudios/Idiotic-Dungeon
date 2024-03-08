using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{

    public int PlayerCurrency;

    public TextMeshProUGUI CurrencyText;

    public Transform CollectionSpot;


    [Header("Currency Spawning")]
    [SerializeField] private float SpawnSize;

    [SerializeField] private GameObject Currency;

    [SerializeField] private Transform SpawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        ChangeCurrency(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCurrency(int how)
    {
        PlayerCurrency += how;
        CurrencyText.text = PlayerCurrency.ToString();
    }

    public bool TryBuying(int Cost)
    {
        if(Cost <= PlayerCurrency)
        {
            ChangeCurrency(-Cost);
            return true;
        }
        else
        {
            return false;
        }
    }


    public void SpawnCurrency(int Amount)
    {
        for (int i = 0; i < Amount; i++)
        {
            float SpawnXRandomization = Random.Range(-SpawnSize, SpawnSize);
            float SpawnYRandomization = Random.Range(-SpawnSize, SpawnSize);
            Instantiate(Currency, SpawnPosition.position + new Vector3(SpawnXRandomization, SpawnYRandomization), Quaternion.identity);
        }

    }

}
