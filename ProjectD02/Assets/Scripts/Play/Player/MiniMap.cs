using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public GameObject player;
    public float playerLocation;

	void Start () {
		
	}
	
	void Update () {
        playerLocation = player.transform.position.x;
        transform.position = new Vector3((playerLocation - 1) * 0.3f, transform.position.y, transform.position.z);
	}
}
