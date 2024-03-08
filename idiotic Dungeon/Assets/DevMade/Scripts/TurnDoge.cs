using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnDoge : MonoBehaviour
{

    [SerializeField] private CardFielding cardFielding;
    [SerializeField] private HealthManager healthManager;

    private TurnManager TM;

    public CardInfo cardInfo;

    public Vector3 targetPosition;

    public Transform CharacterTransform;
    [SerializeField] private Transform CharacterBody;       //Graphicall body of the character


    public float Speed;

    public float DogeTime;
    public float TimeMultiplyer, TimeLeft;


    public bool MovementAction;
    public bool IsMoving;

    [Header("Movement Effects")]
    [SerializeField] private AnimeRE CharacterAnime;


    [SerializeField] private AudioSource DogeSound;

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
            TimeLeft -= Time.deltaTime;
            float TargetDistance = Vector2.Distance(CharacterTransform.position, targetPosition);
            if (!IsMoving)
            {
                IsMoving = true;
                DogeSound.Play();
                healthManager.Immortall = true;
            }

            if (TimeLeft <= 0)
            {
                StopDoge();
            }
        }
        else if (MovementAction && IsMoving)
        {
            StopDoge();
        }
    }

    public void StopDoge()
    {
        MovementAction = false;
        IsMoving = false;
        CharacterAnime.BoolParameterSet("Doging", false);
        DogeSound.Stop();
        healthManager.Immortall = true;


    }

    public void ActionEvent(object sedner, EventArgs e)
    {
        MovementAction = false;
        cardInfo = cardFielding.cardInfo;
        if (cardInfo.CardType == "Doge")
        {

            DogeTime = cardInfo.CardStrength * TimeMultiplyer;
            TimeLeft = DogeTime;
            targetPosition = cardFielding.FieldPosition;
            MovementAction = true;
            CharacterAnime.BoolParameterSet("Doging", true);
            CharacterAnime.TriggerSet("Doge");

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
