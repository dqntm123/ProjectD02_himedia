using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour {

    public UILabel ul;
    public float sec;
    public bool gameFinish = false;

	void Start ()
    {
        sec = 0;
	}
	
	void Update ()
    {
        if(gameFinish==false)
        {
            sec += Time.deltaTime;
            ul.text = sec.ToString("#,#00.0 sec");
        }
	}
}
