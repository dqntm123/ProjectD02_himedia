using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour {

    public GameObject meto;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy1")
        {
            meto.GetComponent<UnitController>().lookE.Add(col.gameObject);
        }
    }
}
