using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float enemyHP;
    public GameObject player;
    public GameObject unit;
    public List<GameObject> lookp;
    public float Atk;
    public float stateTime = 0;
    public float attackRange = 1;
    public float idleStateMaxTime;

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
                stateTime=Time.deltaTime;

                if (stateTime > idleStateMaxTime)
                {
                    if (lookp.Count > 0)
                    {
                        enemystate = ENEMYSTATE.ATTACK;
                    }
                }
                break;

            case ENEMYSTATE.MOVE:
                transform.Translate(-speed * Time.deltaTime, 0, 0);//왼쪽이동

                if (lookp.Count > 0)
                {
                    enemystate = ENEMYSTATE.ATTACK;
                }
                break;

            case ENEMYSTATE.ATTACK:
                lookp[0].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.DAMAGE;
               if( lookp[0].GetComponent<UnitController>().unitHP<=0)
                {
                    lookp.RemoveAt(0);
                }

                break;

            case ENEMYSTATE.DEAD:

                lookp[0].GetComponent<UnitController>().lookE.RemoveAt(0);
                Destroy(gameObject);//오브젝트를 파괴한다

                break;


            case ENEMYSTATE.DAMAGE:

                if (enemyHP <= 0)
                {
                    enemystate = ENEMYSTATE.DEAD;
                }

                if(enemyHP >0)
                {
                    enemyHP -= lookp[0].GetComponent<UnitController>().Atk;
                    if(lookp.Count>0)
                    {
                        enemystate = ENEMYSTATE.ATTACK;
                    }

                    else
                    {
                        enemystate = ENEMYSTATE.MOVE;
                    }
                }

                    break;

            case ENEMYSTATE.KILL:

                break;

        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Unit1")//만약 태그된게 Unit1이라면
        {
            enemystate = ENEMYSTATE.ATTACK;//enemystate를 DEAD로 바꾼다
            lookp.Add(col.gameObject);
        }
       
        if (col.gameObject.tag == "Player")//만약 태그된게 Player라면
        {
            enemystate = ENEMYSTATE.ATTACK;//enemystate를 DEAD로 바꾼다
            lookp.Add(col.gameObject);
        }

        if(col.gameObject.tag == "EnemyGoal")
        {
            gameObject.transform.position = new Vector3(5, -0.2f, -0.3f);
        }
    }
}
