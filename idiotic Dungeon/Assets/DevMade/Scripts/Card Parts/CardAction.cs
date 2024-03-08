using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardAction", fileName = "CardAction_")]
public class CardAction : ScriptableObject
{
    public float ActionSize;

    public GameObject ActionGraphic;

    public bool LineHolo, MeleHolo;
    //LineHolo - if true a line holo will be used for this card
    //MeleHolo = if true a MeleHolo will be used for this card
}
