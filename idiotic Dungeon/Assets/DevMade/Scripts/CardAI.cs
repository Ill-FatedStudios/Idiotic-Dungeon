using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardAI : MonoBehaviour
{

    private TurnManager TM;

    private GameManager GM;

    public Transform AITarget;

    [SerializeField]
    private List<CardInfo> AIDeck;

    [SerializeField]
    private CardFielding cardFielding;

    [SerializeField]
    private GameObject MeleTelegraphing;

    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TurnManager>();
        GM = FindObjectOfType<GameManager>();
        AITarget = GM.PlayerCharacter;
        TM.PlaningStageEvent += PlanAction;
        MeleTelegraphing.GetComponent<RoadAssist>().TargetPosition = GM.PlayerCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlanAction(object sender, EventArgs e)
    {
        MeleTelegraphing.SetActive(false);
        CardInfo ChosenCard = AIDeck[Random.Range(0, AIDeck.Count)];
        cardFielding.FieldCard(ChosenCard , AITarget.position);
        if(ChosenCard.CardType == "Attack")
        {
            MeleTelegraphing.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        TM.PlaningStageEvent -= PlanAction;
    }
}
