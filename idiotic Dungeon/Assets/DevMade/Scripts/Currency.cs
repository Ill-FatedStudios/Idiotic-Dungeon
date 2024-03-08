using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public float speed, speedIncrease;

    public int currency;

    private bool CashingIn = false;

    private CurrencyManager currencyManager;

    [SerializeField] AudioSource FlySound, CashInSound;

    public GameObject GraphicallGroup;

    [SerializeField] ParticleHit CashInParticles;

    // Start is called before the first frame update
    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        Invoke("LateStart" , 0.5f);
    }

    public void LateStart()
    {
        FlySound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currencyManager.CollectionSpot.position, speed);
        speed += speedIncrease * Time.deltaTime;
        float dist = Vector2.Distance(transform.position, currencyManager.CollectionSpot.position);
        if(dist < 0.1 && !CashingIn)
        {
            CashingIn = true;
            CashInSound.Play();
            GraphicallGroup.SetActive(false);
            currencyManager.ChangeCurrency(currency);

            Vector2 EnemyPosition = currencyManager.CollectionSpot.position;
            Vector2 lookDir = EnemyPosition - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// - 90f;
            CashInParticles.Burst(angle);

            Invoke("LateDestroy", 0.5f);
        }
    }

    public void LateDestroy()
    {
        Destroy(gameObject);
    }
}
