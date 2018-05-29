using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {

    public GameObject meto;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Unit1")
        {
            meto.GetComponent<EnemyController>().lookp.Add(col.gameObject);
        }
    }
}
