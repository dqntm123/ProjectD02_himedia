﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float coolTime;
    public float resPawnTime;
    public GameObject[] enemys;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        coolTime += Time.deltaTime;
        if(coolTime>resPawnTime)//만약 쿨타임이 리스폰타임보다 커진다면
        {
            coolTime = 0;//쿨타임값을 0으로 되돌리고
            enemys[0].GetComponent<EnemyController>().enemystate = EnemyController.ENEMYSTATE.MOVE;//enemys배열의 0번째에 해당스크립트를 가져와서 선언한 스테이트를 MOVE로 바꾼다
            Instantiate(enemys[0], transform.position, transform.rotation);//enemys배열의 0번 오브젝트를 생성한다
        }
	}
}