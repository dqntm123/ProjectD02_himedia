using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBerg : MonoBehaviour {

    public GameObject iceball;
    public float iceTime;

     void Awake()
    {
        
    }

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        Destroy(gameObject, iceTime);
	}
}
