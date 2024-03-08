using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMain : MonoBehaviour
{
    public Button CardButton;

    private CardManager cardManager;        //Script Managing Construction

    public CardMovement MyMovement;                 //The movement for this card

    public AnimeRE CardAnimations;                  //Manages all animations for this card

    public CardAction MyAction;         //Basic information needed to showcase the fielidng of a card
    public CardInfo MyInfo;           //Infromation about this card stats

    public int CardCost;

    public bool Cancelled;          //true if card was recently canceled

    // Start is called before the first frame update
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardShowing()
    { 
        CardAnimations.BoolParameterSet("Showing", true);
        
    }
    
    public void CardShown()
    { 
        CardAnimations.BoolParameterSet("Showing", false);
        
    }

    public void InUse()
    {
        Cancelled = false;
        CardAnimations.BoolParameterSet("Using", true);
        cardManager.Planing(MyAction, this);
    }

    public void CardPut()
    {
        if(!Cancelled)
            cardManager.UseCard();
    }

    public void CardUsed()
    {
        CardAnimations.TriggerSet("Cast");
        Invoke("CardEnd", 1);
    }

    public void CardEnd()
    {
        Destroy(gameObject);

    }

    public void CardFailed()
    {
        Cancelled = true;
        CardAnimations.BoolParameterSet("Using", false);
        CardAnimations.TriggerSet("Decking");
        MyMovement.Following = false;
        MyMovement.Decking = true;

    }

}
