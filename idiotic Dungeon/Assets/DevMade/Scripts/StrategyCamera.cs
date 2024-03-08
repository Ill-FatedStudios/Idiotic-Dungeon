using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StrategyCamera : MonoBehaviour
{

    public float speed;
    public float MaxDistance;
    public float CombackSpeed;



    public Transform MyPlayer;

    public Vector2 MoveVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float PlayerDistance = Vector2.Distance(MyPlayer.position, transform.position);
        if(PlayerDistance > MaxDistance / 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, MyPlayer.position, (PlayerDistance - (MaxDistance / 2) + CombackSpeed) * Time.deltaTime );
        }
        transform.position += new Vector3(MoveVector.x * speed * Time.deltaTime, MoveVector.y * speed * Time.deltaTime, 0);

    }

    public void OnMove(InputValue direction)
    {
        MoveVector = direction.Get<Vector2>();

    }
}