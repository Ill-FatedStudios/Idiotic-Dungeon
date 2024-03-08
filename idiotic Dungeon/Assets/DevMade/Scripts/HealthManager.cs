using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int Health;

    public bool Immortall;

    public AnimeRE FlashLight;
    public AnimeRE BodyAnime;

    public ParticleHit PH;
    public ParticleHit ParticleCircleHit;

    public Rigidbody2D Rb2D;

    public Transform SpriteBody;        //The visual bod of this being with no components
    //Used for creating dead bodies

    public HealthVizualizer healthVizualizer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveDamage(int Damage, Vector3 FromWhere)
    {
        if (Immortall)
            return;


        Health -= Damage;
        FlashLight.TriggerSet("Flash");
        if (Health < 0)
        {
            BodyAnime.BoolParameterSet("Death", true);
            BodyAnime.TriggerSet("Dead");
            if (SpriteBody != null)
            {
                SpriteBody.SetParent(null);
            }
            Destroy(gameObject);
        }
        else
        {
            BodyAnime.BoolParameterSet("Hit", true);
            healthVizualizer.VizualizeHealth(Health);
        }

        Vector2 lookDir = FromWhere - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// - 90f;
        PH.Burst(angle);

        Vector2 reverselookDir = transform.position - FromWhere;
        float ReverseAngle = Mathf.Atan2(reverselookDir.y, reverselookDir.x) * Mathf.Rad2Deg;// - 90f;
        ParticleCircleHit.Burst(ReverseAngle);


        Knockback(FromWhere, 1);
    }

    public void Knockback(Vector3 From, float Force)
    {
        Vector2 distanceVector = Rb2D.transform.position - From;
        if (distanceVector.magnitude > 0) //so you will not get NaN error, a nice tips is to not devide by 0 :)
        {
            float explosionForce = Force / (distanceVector.magnitude * 0.001f);
            Rb2D.AddForce(distanceVector.normalized * explosionForce);
        }
    }
}
