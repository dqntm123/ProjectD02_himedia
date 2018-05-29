using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public float speed;
    public float hP;
    public float atk;
    public int b_Atk;

    public List<GameObject> look;

    public float lv;
    public float stateTime = 0;
    public Collider diecol;
    public GameObject sensor;
    public float attackStateMaxTime;
    public bool isDead = false;


    public enum UNIT
    {
        PLAYER = 0,
        ENEMY
    }
    public UNIT unit;

    public enum UNITSTATE
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        DEAD
    }
    public UNITSTATE unitstate;

     void Awake()
    {
       diecol = gameObject.GetComponent<BoxCollider>();
        atk += b_Atk * lv * 0.1f;
    }
    void Start ()
    {
        unitstate = UNITSTATE.MOVE;
        look = new List<GameObject>();
    }
	
	void Update ()
    {
        if(hP <= 0)
        {
            isDead = true;
            DeadProcess();
        }

        if(isDead == false)
        {
            switch (unitstate)
            {
                case UNITSTATE.IDLE:
                    if(look[0] == null)
                    {
                        look.RemoveAt(0);
                        unitstate = UNITSTATE.MOVE;
                    }

                    else
                    {
                        unitstate = UNITSTATE.ATTACK;
                    }

                    break;

                case UNITSTATE.MOVE:

                    switch(unit)
                    {
                        case UNIT.PLAYER:
                            transform.Translate(speed * Time.deltaTime, 0, 0);
                            break;
                        case UNIT.ENEMY:
                            transform.Translate(-speed * Time.deltaTime, 0, 0);
                            break;
                    }
                  
                    break;

                case UNITSTATE.ATTACK:
                    if(look.Count>0)
                    {
                        if(look[0] != null)
                        {
                            stateTime += Time.deltaTime;
                            if(stateTime>attackStateMaxTime)
                            {
                                stateTime = 0;
                                look[0].GetComponent<UnitController>().GetDamage(atk);
                            }
                        }

                        else
                        {
                            look.RemoveAt(0);
                        }
                    }

                    else
                    {
                        unitstate = UNITSTATE.MOVE;
                    }
                    break;

                case UNITSTATE.DEAD:

                    Destroy(sensor);
                    Destroy(gameObject);//오브젝트를 파괴한다
                    diecol.enabled = false;
                  
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
       
    }

    public void GetDamage(float dmg)
    {
        hP -= dmg;

    }

    public void DeadProcess()
    {
        if(gameObject.tag == "Player")
        {
           
        }
    }
}
