using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTarget : MonoBehaviour {

	
	void Update ()
    {
	    if(gameObject.transform.parent.GetComponent<getButtonIndex>().clickCt==0)
        {
            gameObject.SetActive(false);
        }
	}
}
