using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using System;

public class ParticleHit : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem ParticleBurst;

    public Transform RotT;



    // Start is called before the first frame update
    void Start()
    {
        /*
        BurstEvent += Burst;
        BurstCord.ExtendCord(BurstEvent);
        */
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Burst(float CounterRot)
    {
        //Rotation for the Burst

        //The precise value must be the wanted z angle
        RotT.localEulerAngles = new Vector3(0, 0, CounterRot);
        ParticleBurst.Play();
    }


    public void DelayedParticles(float delay)
    {
        Invoke("Burst", delay);
    }

    public void Burst()
    {
        ParticleBurst.Play();
    }

}
