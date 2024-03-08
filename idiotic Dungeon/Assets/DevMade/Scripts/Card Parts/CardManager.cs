using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardManager : MonoBehaviour
{

    private Camera Cam;             //The main in game camera
    public Transform MouseFollower;     //Transform steadly following the mouse

    public CardFielding cardFielding;       //Field the cards
    public CardMain CardInUse;
    public CardAction CurrentCardAction;      //The construction currently being built          
    public GameObject PlaningHolo;          //Current holo of a planned building

    [SerializeField] private RoadAssist LineAim;        //Aims a line to the target
    [SerializeField] private RoadAssist MeleAssist;        //Aims a line to the target

    private Vector3 FieldPosition;           //Position at which acard was fielded 

    public LayerMask ObstacleLayers;        //Layer masks of obstacles for construction

    public Color32 CorrectHolo;             //Holo color used when the building is possible
    public Color32 IncorrectHolo;           //Holo color use when the building is impossible


    public bool Casting;               //If true the contruction check will be fielded

    public bool CanCast;               //If true then the contruction can be constructed 

    private CurrencyManager currencyManager;


    // Start is called before the first frame update
    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();

        Cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 MousePos = new Vector3();
        if (Cam != null)
        {
            MousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
        }
        float DistanceSpeed = Vector2.Distance(MouseFollower.position, MousePos);
        MouseFollower.position = Vector2.MoveTowards(MouseFollower.position, MousePos, (3 * DistanceSpeed) * Time.deltaTime);
    
        if(Casting)
        {
            Collider2D[] ConstructionObstacles = Physics2D.OverlapCircleAll(MouseFollower.position, CurrentCardAction.ActionSize, ObstacleLayers);
            if (ConstructionObstacles.Length == 0)
            {
                foreach (SpriteRenderer thing in PlaningHolo.GetComponentsInChildren<SpriteRenderer>())
                {
                    thing.color = CorrectHolo;
                    LineAim.ChangeAssistStatus(true);

                }
                CanCast = true;
            }
            else
            {
                foreach (SpriteRenderer thing in PlaningHolo.GetComponentsInChildren<SpriteRenderer>())
                {
                    thing.color = IncorrectHolo;
                    LineAim.ChangeAssistStatus(false);

                }
                CanCast = false;
            }

        }
    }

    public void Planing(CardAction cardAction, CardMain CardPlanned)
    {
        CurrentCardAction = cardAction;
        CardInUse = CardPlanned;
        PlaningHolo = Instantiate(CurrentCardAction.ActionGraphic, MouseFollower.position, Quaternion.identity, MouseFollower);

        LineAim.gameObject.SetActive(CurrentCardAction.LineHolo);
        MeleAssist.gameObject.SetActive(CurrentCardAction.MeleHolo);

        foreach (SpriteRenderer thing in PlaningHolo.GetComponentsInChildren<SpriteRenderer>())
        {
            thing.color = CorrectHolo;

        }
        LineAim.ChangeAssistStatus(true);


        Casting = true;
    }

    public void UseCard()
    {
        Casting = false;
        if (CanCast && currencyManager.TryBuying(CardInUse.CardCost))
        {
            FieldPosition = MouseFollower.position;
            CardInUse.CardUsed();
            Invoke("UsingCard", 0.6f);
        }
        else
        {
            CardInUse.CardFailed();
        }
        LineAim.gameObject.SetActive(false);
        MeleAssist.gameObject.SetActive(false);
        Destroy(PlaningHolo);
    }

    //Void activated when construction is possible and is being carried out 
    public void UsingCard()
    {
        cardFielding.FieldCard(CardInUse.MyInfo, FieldPosition);
        FindObjectOfType<ScreenShakeReusable>().Shake(0.0125f);
    }

    public void CancellCard()
    {
        CardInUse.CardFailed();
        Casting = false;
        LineAim.gameObject.SetActive(false);
        MeleAssist.gameObject.SetActive(false);
        Destroy(PlaningHolo);

    }


    public void OnCancellCard(InputValue direction)
    {
        if (!Casting)
            return;

        
        CancellCard();
        Debug.Log("cancelling");
    }

}
