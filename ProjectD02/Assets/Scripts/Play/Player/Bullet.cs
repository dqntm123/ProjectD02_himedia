using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        //if(gameObject.tag == "Enemy")
        //{
        //    enemy = col.gameObject;
        //    enemy.GetComponent<EnemyController>().enemyHP -= player.GetComponent<UnitController>().atk;
        //}
        if(gameObject.tag =="Enemy")
        {
            //player.GetComponent<UnitController>().enemy = col.gameObject;
        }

    }

}
