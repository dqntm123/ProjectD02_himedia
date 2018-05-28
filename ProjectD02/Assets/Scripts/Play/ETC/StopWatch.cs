using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour {

    public UILabel ul;
    private float sec;

	void Start () {
        sec = 0;
	}
	
	void Update () {
        sec += Time.deltaTime;
        ul.text = sec.ToString("#,#00.0 sec");
	}
}
