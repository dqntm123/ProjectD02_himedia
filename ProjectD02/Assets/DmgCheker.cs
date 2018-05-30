using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgCheker : MonoBehaviour {

    public GameObject dmgte;
    public float speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        gameObject.transform.Translate(0, speed*Time.deltaTime, 0);
        Destroy(gameObject, 1);
	}
}
