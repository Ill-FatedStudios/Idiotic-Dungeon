using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeReusable : MonoBehaviour
{

    public Transform ShakeTransform;       //Acceses   the screen shake transform

    public float ShakeScale;               //Saves      the scale of screen shake
    public float LeftShake;                //Saves      amount of shake left to be done

    public int XShake;                     //Saves      the type of X shake
    public int YShake;                     //Saves      the type of Y shake

    public bool Working;                   //Tells     if the shaking is on

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Shake(float Scale)
    {
        if (!Working)
        {
            Working = true;
            ShakeScale = Scale;
            LeftShake = Scale;

            XShake = Random.Range(-1, 2);
            YShake = Random.Range(-1, 2);
            if(YShake == 0 && XShake == 0)
            {
                YShake = 1;
            }
            ShakeTransform.localPosition += new Vector3(0.1f * ShakeScale * XShake, 0.1f * ShakeScale * YShake, 0);
            InvokeRepeating("Shaking", 0.01f, 0.01f);
        }
    }

    public void Shaking()
    {
        //if (ShakeTransform.localPosition.x > 0.1f * -ShakeScale * XShake || ShakeTransform.localPosition.y > 0.1f * -ShakeScale * YShake)
        if (LeftShake <= 0)
        {
            CancelInvoke("Shaking");
            ShakeTransform.localPosition = new Vector3(0, 0, 0);
            Working = false;
        }
        else
        {
            LeftShake -= 0.1f * ShakeScale;
            ShakeTransform.localPosition += new Vector3(0.1f * ShakeScale * XShake, 0.1f * ShakeScale * YShake, 0);

        }
    }

}
