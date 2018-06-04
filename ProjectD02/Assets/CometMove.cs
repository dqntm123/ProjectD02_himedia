using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometMove : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update ()
    {
      gameObject.transform.Translate(3 * Time.deltaTime, -5 * Time.deltaTime, 0);
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject, 1);
        }
    }

}
