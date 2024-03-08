using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMovement : MonoBehaviour
{
    private Transform MainCanva;        //The main card canva

    private CardHand MyHand;       //The hand this card is attached to
    private Transform MyHandEntrance;       //The entrance to the hand this card is attached to

    public Transform CardTransform;   

    private Camera Cam;             //The main in game camera

    public bool Following = false;      //When true the card is following the mouse
    public bool Decking = false;        //When true the card is going to the deck

    [SerializeField]
    private AudioSource HandSound;      //Sound activated when entering a hand
    [SerializeField]
    private AudioSource MovementSound;      //Sound activated when moving

    // Start is called before the first frame update
    void Start()
    {
        MyHand = FindObjectOfType<CardHand>();
        MyHandEntrance = MyHand.CardEntrance;
        MainCanva = FindObjectOfType<Canvas>().transform;
        Cam = FindObjectOfType<Camera>();
        transform.SetParent(MainCanva);
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        Invoke("LateStart", 1f);
        
    }

    public void LateStart()
    {
        Decking = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Decking)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            float Dist = Vector2.Distance(new Vector2(MyHandEntrance.position.x, MyHandEntrance.position.y), new Vector2(transform.position.x, transform.position.y));
            if (Dist > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, MyHandEntrance.position, 0.1f + (1.5f * Dist) * Time.deltaTime);
            }
            else
            {
                HandSound.Play();
                CardTransform.localEulerAngles = new Vector3(0, 0, 0);
                transform.SetParent(MyHand.transform);
                Decking = false;
            }


            if (Dist >= 10 && !MovementSound.isPlaying)
            {
                MovementSound.Play();
            }

        }
        else if (Following)
        {
            Vector3 MousePos = new Vector3();
            if (Cam != null)
            {
                MousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
            }
            float DistanceSpeed = Vector2.Distance(transform.position, MousePos);
            transform.position = Vector2.MoveTowards(transform.position, MousePos, (3 * DistanceSpeed) * Time.deltaTime);

            if (transform.position.x > MousePos.x)
            {
                CardTransform.localEulerAngles = new Vector3(0, 0, DistanceSpeed);

            }
            else
            {
                //transform.rotation.SetEulerRotation(0, 0, );

                CardTransform.localEulerAngles = new Vector3(0, 0, -DistanceSpeed);

            }

            if (DistanceSpeed >= 10 && !MovementSound.isPlaying)
            {
                MovementSound.Play();
            }
        }

    }


    public void Picked()
    {
        transform.SetParent(MainCanva);
        Following = true;
    }
}
