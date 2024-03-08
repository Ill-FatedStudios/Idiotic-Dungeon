using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnAttack : MonoBehaviour
{

    [SerializeField] private CardFielding cardFielding;

    private TurnManager TM;

    public AttackingManager AM;

    public CardInfo cardInfo;

    [SerializeField] private Transform CharacterBody;       //Graphicall body of the character


    public Vector3 targetPosition;


    public float attackDamage, DamageMultiplyer;

    public bool AttackAction;


    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TurnManager>();
        cardFielding.FieldEvent += ActionEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackAction && TM.GameStage == 1)
        {
           
            AM.Attack(targetPosition);
            AttackAction = false;
        }
    }

    public void ActionEvent(object sedner, EventArgs e)
    {
        cardInfo = cardFielding.cardInfo;
        if (cardInfo.CardType == "Attack")
        {
            attackDamage = cardInfo.CardStrength * DamageMultiplyer;
            AM.AttackDamage = (int)attackDamage;
            targetPosition = cardFielding.FieldPosition;
            AttackAction = true;
            if (transform.position.x > targetPosition.x)
            {
                CharacterBody.localEulerAngles = new Vector3(0, 180, 0);

            }
            else
            {

                CharacterBody.localEulerAngles = new Vector3(0, 0, 0);

            }
        }
    }

}
