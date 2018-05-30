using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour {

    public GameObject met;
    public GameObject meet;

	void Start ()
    {
		if(gameObject.transform.parent.tag == "Player")
        {
            met = gameObject.transform.parent.gameObject;
        }

        if(gameObject.transform.parent.tag == "Enemy")
        {
            meet = gameObject.transform.parent.gameObject;
        }
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (gameObject.transform.parent.tag == "Player")
        {
            if (col.gameObject.tag == "Enemy")
            {

                met.GetComponent<UnitController>().look.Add(col.gameObject);
                met.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.ATTACK;

            }
        }

        if (gameObject.transform.parent.tag == "Enemy")
        {
            if (col.gameObject.tag == "Player")
            {
                meet.GetComponent<UnitController>().look.Add(col.gameObject);
                meet.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.ATTACK;
            }
        }
    }
}
