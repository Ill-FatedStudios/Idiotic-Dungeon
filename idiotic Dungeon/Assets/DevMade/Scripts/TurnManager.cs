using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TurnManager : MonoBehaviour
{

    [SerializeField]
    private CardFielding PlayerCardFielding;

    public int GameStage;       //0 - Planing , 1 - Acting

    public float TurnTime, LeftTurnTime;


    [Header("Pasive Income Stats")]
    public EventHandler PlaningStageEvent;      //Event starting when planing starts

    [SerializeField] private int PassiveIncomeDelay, TimeToPassiveIncome, PassiveIncome;

    [SerializeField] private TextMeshProUGUI timeToPassiveIncomeText;  
    [SerializeField] private Button DrawCardsButton;  



    // Start is called before the first frame update
    void Start()
    {
        PlayerCardFielding.FieldEvent += PlayerActed;
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftTurnTime > 0 && GameStage == 1)
        {
            LeftTurnTime -= Time.deltaTime;
        }
        else if(GameStage != 0)
        {
            PlaningStage();
        }
    }

    public void PlayerActed(object sender, EventArgs e)
    {
        GameStage = 1;
        LeftTurnTime = TurnTime;

        TurnPassed();
    }

    public void DrawnCards()
    {
        GameStage = 1;
        LeftTurnTime = TurnTime;
        TurnPassed();
    }

    public void TurnPassed()
    {
        TimeToPassiveIncome -= 1;
        timeToPassiveIncomeText.text = TimeToPassiveIncome.ToString();
        if (TimeToPassiveIncome == 0)
        {
            TimeToPassiveIncome = PassiveIncomeDelay;
            FindObjectOfType<CurrencyManager>().SpawnCurrency(PassiveIncome);
            timeToPassiveIncomeText.text = PassiveIncomeDelay.ToString();

        }
    }

    public void PlaningStage()
    {
        GameStage = 0;
        PlaningStageEvent?.Invoke(this, null);
        DrawCardsButton.interactable = true;

    }


}
