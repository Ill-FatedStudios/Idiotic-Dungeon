using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MobSpawner>().ChangeMobs(1);
    }

    private void OnDestroy()
    {
        FindObjectOfType<MobSpawner>().ChangeMobs(-1);
    }
}
