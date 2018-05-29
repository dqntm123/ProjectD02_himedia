using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float enemyHP;
    public List<GameObject> lookp;
    public float atk = 10;
    public float lv;
    public float stateTime = 0;
    public Collider diecol;
    public GameObject sensor;
   
    public float idleStateMaxTime;
    public float attackStateMaxTime;

 

    public enum ENEMYSTATE
    {
        IDLE,
        MOVE,
        ATTACK,
        DAMAGE,
        KILL,
        DEAD
    }
    public ENEMYSTATE enemystate;

     void Awake()
    {
        diecol = GetComponent<Collider>();
    }

    void Start ()
    {
       // player = GameObject.Find("Player");
	}
	
	void Update ()
    {
        switch (enemystate)
        {

            case ENEMYSTATE.IDLE:
                stateTime = 0;
                stateTime = Time.deltaTime;

                if (stateTime > idleStateMaxTime)
                {
                    if (lookp.Count > 0)
                    {
                        enemystate = ENEMYSTATE.ATTACK;
                    }

                    else
                    {
                        enemystate = ENEMYSTATE.MOVE;
                    }
                }

                break;

            case ENEMYSTATE.MOVE:
                transform.Translate(-speed * Time.deltaTime, 0, 0);//왼쪽이동

                //if (lookp.Count < 1)
                //{
                //    enemystate = ENEMYSTATE.MOVE;
                //}

                if (lookp.Count > 0)
                {
                    enemystate = ENEMYSTATE.ATTACK;
                }

                break;

            case ENEMYSTATE.ATTACK:
                stateTime += Time.deltaTime;
                if(stateTime>attackStateMaxTime)
                {
                    stateTime = 0f;
                    lookp[0].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.DAMAGE;
                    enemystate = ENEMYSTATE.IDLE;
                }
               
               if( lookp[0].GetComponent<UnitController>().unitHP<=0)
                {
                    lookp.RemoveAt(0);
                    enemystate = ENEMYSTATE.MOVE;
                }

                break;

            case ENEMYSTATE.DAMAGE:


                if (enemyHP <= 0)
                {
                    enemystate = ENEMYSTATE.DEAD;
                }

                if (enemyHP >0)
                {
                    enemyHP -= lookp[0].GetComponent<UnitController>().atk;
                    Debug.Log(enemyHP);
                    enemystate = ENEMYSTATE.IDLE;
                }

                    break;

            case ENEMYSTATE.KILL:

                lookp.RemoveAt(0);
                enemystate = ENEMYSTATE.MOVE;

                break;

            case ENEMYSTATE.DEAD:

                Destroy(gameObject);//오브젝트를 파괴한다
                diecol.enabled = false;
                Destroy(sensor);
                lookp[0].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.KILL;
            
                
                

                break;

        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        //if(col.gameObject.tag=="Unit1")//만약 태그된게 Unit1이라면
        //{
        //    lookp.Add(col.gameObject);
        //    enemystate = ENEMYSTATE.ATTACK;//enemystate를 DEAD로 바꾼다

        //}

        //if (col.gameObject.tag == "Player")//만약 태그된게 Player라면
        //{
        //    enemystate = ENEMYSTATE.ATTACK;//enemystate를 DEAD로 바꾼다
        //    lookp.Add(col.gameObject);
        //}

        if (col.gameObject.tag == "EnemyGoal")
        {
            gameObject.transform.position = new Vector3(5, -0.2f, -0.3f);
        }

    }
}
