using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingManager : MonoBehaviour
{
    public AnimeRE AttackAnime;         //Animator managing attacking


    public Rigidbody2D WeaponHand;        //The hand holding our weapon

    public Transform WeaponPosition;

    public LayerMask TargetLayers;      //The layers that are targeted

    public float AttackSize;
    public float AttackRange;

    public float AttackCooldown;
    public float LeftAttackCooldown;

    public int AttackDamage;

    public Vector3 TargetEnenemy;

    public AudioSource AttackSound;


    // Update is called once per frame
    void Update()
    {
        if(LeftAttackCooldown > 0)
        {
            LeftAttackCooldown -= Time.deltaTime;
        }

        if(TargetEnenemy != null)
        {
            WeaponHand.transform.localPosition = new Vector3(0, 0, 0);
            Vector2 EnemyPosition = TargetEnenemy;
            Vector2 lookDir = EnemyPosition - WeaponHand.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// - 90f;
            WeaponHand.transform.localEulerAngles = new Vector3(0,0,angle);
            // MyBS.DirectionsPrefs = AimArrow.up
        }
    }

    public void Attack(Vector3 Who)
    {
        TargetEnenemy = Who;

        AttackAnime.TriggerSet("Attack");
        if (!AttackSound.isPlaying)
        {
            AttackSound.Play();
        }
        Invoke("Attacked", 0.5f);
    }

    public void Attacked()
    {
        if (TargetEnenemy == null)
            return;

        WeaponHand.transform.localPosition = new Vector3(0, 0, 0);
        Vector2 EnemyPosition = TargetEnenemy;
        Vector2 lookDir = EnemyPosition - WeaponHand.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// - 90f;
        WeaponHand.rotation = angle;
        // MyBS.DirectionsPrefs = AimArrow.up
        WeaponPosition.transform.localPosition = new Vector3(AttackRange, 0, 0);


        Collider2D[] TargetsHit = Physics2D.OverlapCircleAll(WeaponPosition.position, AttackSize, TargetLayers);
        foreach (Collider2D thing in TargetsHit)
        {
            thing.GetComponent<HealthManager>().RecieveDamage(AttackDamage, transform.position);
        }
        LeftAttackCooldown = AttackCooldown;
    }
}
