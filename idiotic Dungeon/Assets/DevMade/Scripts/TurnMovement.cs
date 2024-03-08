using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMovement : MonoBehaviour
{

    [SerializeField] private CardFielding cardFielding;

    private TurnManager TM;

    public CardInfo cardInfo;

    public Vector3 targetPosition;

    public Transform CharacterTransform;
    [SerializeField] private Transform CharacterBody;       //Graphicall body of the character


    public float Speed;
    public float speedMultiplyer;

    public bool MovementAction;
    public bool IsMoving;

    [Header("Movement Effects")]
    [SerializeField] private AnimeRE CharacterAnime;


    [SerializeField] private AudioSource Sneak, Walk, Run;
    
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TurnManager>();
       cardFielding.FieldEvent += ActionEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementAction && TM.GameStage == 1)
        {
            CharacterTransform.position = Vector2.MoveTowards(CharacterTransform.position, targetPosition, Speed * Time.deltaTime);
            float TargetDistance = Vector2.Distance(CharacterTransform.position, targetPosition);
            if (!IsMoving)
            {
                IsMoving = true; 
                if(Speed >= 5)
                {
                    Run.Play();
                }
                else if(Speed >= 2)
                {
                    Walk.Play();
                }
                else
                {
                    Sneak.Play();
                }
            }

            if (TargetDistance <= 0.1f)
            {
                StopMovement();
            }
        }
        else if(MovementAction && IsMoving)
        {
            StopMovement();
        }
    }

    public void StopMovement()
    {
        MovementAction = false;
        IsMoving = false;
        CharacterAnime.BoolParameterSet("Moving", false);
        Sneak.Stop();
        Walk.Stop();
        Run.Stop();
    }

    public void ActionEvent(object sedner, EventArgs e)
    {
        MovementAction = false;
        cardInfo = cardFielding.cardInfo;
        if (cardInfo.CardType == "Movement")
        {

            Speed = cardInfo.CardStrength * speedMultiplyer;
            targetPosition = cardFielding.FieldPosition;
            MovementAction = true;
            CharacterAnime.BoolParameterSet("Moving", true);
            CharacterAnime.TriggerSet("Move");

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
