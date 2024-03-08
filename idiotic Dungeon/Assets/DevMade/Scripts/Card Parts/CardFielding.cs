using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardFielding : MonoBehaviour
{


    public CardInfo cardInfo;

    public EventHandler FieldEvent;

    public Vector3 FieldPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FieldCard(CardInfo CI, Vector3 fieldPosition )
    {
        cardInfo = CI;
        FieldPosition  = fieldPosition;
        FieldEvent?.Invoke(this, null);
    }


}
