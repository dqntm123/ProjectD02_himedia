using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public float speed;
    public float unitHP;
    public float atk;
    public float b_Atk;
    public GameObject enemy;
    public List<GameObject> lookE;
    public float lv;
    public float stateTime = 0;
    public float idleStateMaxTime;
    public Collider diecol;
    public GameObject sensor;
    public float attackStateMaxTime;
    

    public enum UNITSTATE
    {
        IDLE,
        MOVE,
        ATTACK,
        DAMAGE,
        KILL,
        DEAD
    }
    public UNITSTATE unitstate;

     void Awake()
    {
        atk += b_Atk * lv * 0.1f;
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
        switch (unitstate)
        {
            case UNITSTATE.IDLE:
                stateTime = 0;
                stateTime = Time.deltaTime;

                if (stateTime > idleStateMaxTime)
                {
                    if (lookE.Count > 0)
                    {
                        unitstate = UNITSTATE.ATTACK;
                    }

                    else
                    {
                        unitstate = UNITSTATE.MOVE;
                    }
                }

                break;

            case UNITSTATE.MOVE:
                transform.Translate(speed * Time.deltaTime, 0, 0);//왼쪽이동

                if (lookE.Count > 0)
                {
                    unitstate = UNITSTATE.ATTACK;
                }

                break;

            case UNITSTATE.ATTACK:
                stateTime += Time.deltaTime;
                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0f;
                    lookE[0].GetComponent<EnemyController>().enemystate = EnemyController.ENEMYSTATE.DAMAGE;
                    unitstate = UNITSTATE.IDLE;
                }
              
                if (lookE[0].GetComponent<EnemyController>().enemyHP <= 0)
                {
                    lookE.RemoveAt(0);
                    unitstate = UNITSTATE.MOVE;
                }
                break;

            case UNITSTATE.DAMAGE:
                if (unitHP <= 0)
                {
                    unitstate = UNITSTATE.DEAD;
                }

                if (unitHP> 0)
                {
                    unitHP -= lookE[0].GetComponent<EnemyController>().atk;
                    unitstate = UNITSTATE.IDLE;
                }
                break;

            case UNITSTATE.KILL:

                lookE.RemoveAt(0);
                unitstate = UNITSTATE.MOVE;

                break;

            case UNITSTATE.DEAD:
                Destroy(sensor);
                Destroy(gameObject);//오브젝트를 파괴한다
                                       //  diecol.enabled = false;
                lookE[0].GetComponent<EnemyController>().enemystate = EnemyController.ENEMYSTATE.KILL;
              
                break;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        //if (col.gameObject.tag == "Enemy1")//만약 태그된게 Enemy1이라면
        //{
        //    unitstate = UNITSTATE.DEAD;//unitstate를 DEAD로 바꾼다
        //}
        //if (col.gameObject.tag == "Castle")//만약 태그된게 Castle라면
        //{
        //    unitstate = UNITSTATE.DEAD;//unitstate를 DEAD로 바꾼다
        //}
    }
}
