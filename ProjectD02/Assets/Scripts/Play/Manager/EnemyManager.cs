using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

   
    public float coolTime;
    public float resPawnTime;
    public GameObject[] enemys;
    public GameObject[] middleBoss;
    public GameObject[] boss;
  


	void Start ()
    {
		
	}
	
	void Update ()
    {
        coolTime += Time.deltaTime;
        if(coolTime>resPawnTime)//만약 쿨타임이 리스폰타임보다 커진다면
        {
            coolTime = 0;//쿨타임값을 0으로 되돌리고
            //int a = Random.Range(0, 5);
            Instantiate(enemys[0], transform.position, transform.rotation);//enemys배열의 0번 오브젝트를 생성한다
        }

	}

    

    
}
