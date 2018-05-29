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

    void Start()
    {
        // player = GameObject.Find("Player");
    }

    void Update()
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

                if (lookp.Count > 0)
                {
                    enemystate = ENEMYSTATE.ATTACK;
                }

                break;

            case ENEMYSTATE.ATTACK:
                stateTime += Time.deltaTime;

                //if (lookp[0].GetComponent<UnitController>().unitHP <= 0)
                //{
                //    lookp.RemoveAt(0);
                //    enemystate = ENEMYSTATE.MOVE;
                //}

                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0f;
                    //lookp[0].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.DAMAGE;
                    enemystate = ENEMYSTATE.IDLE;
                }



                if (lookp.Count < 1)
                {
                    enemystate = ENEMYSTATE.MOVE;
                }

                break;

            case ENEMYSTATE.DAMAGE:


                if (enemyHP <= 0)
                {
                    enemyHP = 0;
                    enemystate = ENEMYSTATE.DEAD;
                }

                if (enemyHP > 0)
                {
                    enemyHP -= lookp[0].GetComponent<UnitController>().atk;
                    Debug.Log(enemyHP);
                    enemystate = ENEMYSTATE.ATTACK;

                    if (enemyHP <= 0)
                    {
                        enemyHP = 0;
                        enemystate = ENEMYSTATE.DEAD;
                    }
                }

                break;

            case ENEMYSTATE.KILL:


                enemystate = ENEMYSTATE.MOVE;

                break;

            case ENEMYSTATE.DEAD:

                //for (int i = 0; i < lookp.Count; i++)
                //{
                //    lookp[i].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.KILL;
                //}

                //diecol.enabled = false;
                //Destroy(sensor);
                //lookp[0].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.KILL;
                Destroy(gameObject);//오브젝트를 파괴한다

                break;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyGoal")
        {
            gameObject.transform.position = new Vector3(5, -0.2f, -0.3f);
        }
    }
}
