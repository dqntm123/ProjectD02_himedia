using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour {

    public GameObject met;
    public GameObject meet;
    public Transform playerPos;

	void Start ()
    {
       

        if (gameObject.transform.parent.tag == "Player")
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
        playerPos = GameObject.FindGameObjectWithTag("Darking").transform;
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
            if (col.gameObject.tag == "Castle")
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


            if (col.gameObject.tag == "Darking")
            {
                meet.GetComponent<UnitController>().look.Add(col.gameObject);
                meet.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.ATTACK;
            }

        }

    }

    private void OnTriggerExit(Collider col)
    {
        //if (gameObject.tag == "Darking")
        //{
        //    if (meet.GetComponent<UnitController>().look[0].tag == "Darking")
        //    {
        //        //meet.GetComponent<UnitController>().look.RemoveAt(0);
        //        meet.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
        //    }
        //}

        //if (gameObject.tag == "Player")
        //{
        //    if (meet.GetComponent<UnitController>().look[0].tag == "Player")
        //    {
        //        meet.GetComponent<UnitController>().look.RemoveAt(0);
        //        meet.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
        //    }
        //}
    }

}
