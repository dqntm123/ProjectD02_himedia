using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyByDistance : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if(transform.position.x > 20 || transform.position.y < 0)
        {
            Destroy(gameObject);
        }
	}
}
