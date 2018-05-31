﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour {

    public float speed;
    public float hP;
    public float b_Hp;
    public float atk;
    public int b_Atk;
    public Animator anime;
    public float[] exp;
    public int sn;
    public Animation ani;

    public StageManager sm;

    public List<GameObject> look;

    public float lv;
    public float stateTime = 0;
    public Collider diecol;
    public GameObject sensor;
    public float attackStateMaxTime;
    public bool isDead = false;
    public GameObject[] dmgcheck;
    public GameObject[] effect;


    public enum UNIT //케릭터의 종류를 정함
    {
        PLAYER = 0,
        GUARDIAN,
        ENEMY,
        MIDDLEBOSS
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
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        diecol = gameObject.GetComponent<BoxCollider>();
        anime.GetComponent<TweenAlpha>().enabled = false;
        sn = sm.currentStageNum;

        if (gameObject.tag == "Player")
        {
            atk += b_Atk * lv * 0.1f;
            hP += b_Hp * lv * 0.1f;
        }
        if(gameObject.tag == "Enemy")
        {
            atk += b_Atk * sn * 0.1f;
            hP += b_Hp * sn * 0.1f;
        }

    }
    void Start ()
    {
        isDead = false;
        unitstate = UNITSTATE.MOVE;
        look = new List<GameObject>();
    }
	
	void Update ()
    {
        if (look.Count > 0)
        {
          //look[0].GetComponent<UnitController>()
            if (look[0].GetComponent<UnitController>().hP <= 0)
            {
                 look.Clear();
                 unitstate = UNITSTATE.MOVE;
            }
            
        }
        if(hP <= 0)
        {
           
            isDead = true;
            unitstate = UNITSTATE.DEAD;
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
                            anime.SetBool("Attack", false);
                            anime.SetBool("Move", true);
                            transform.Translate(speed * Time.deltaTime, 0, 0);
                            break;
                        case UNIT.GUARDIAN:
                            anime.SetBool("Attack", false);
                            anime.SetBool("Move", true);
                            transform.Translate(speed * Time.deltaTime, 0, 0);
                            break;
                        case UNIT.ENEMY:
                            anime.SetBool("Attack", false);
                            anime.SetBool("Move", true);
                            transform.Translate(-speed * Time.deltaTime, 0, 0);
                            break;
                        case UNIT.MIDDLEBOSS:
                            anime.SetBool("Attack", false);
                            anime.SetBool("Move", true);
                            transform.Translate(-speed * Time.deltaTime, 0, 0);
                            break;
                        //case UNIT.BOSS:
                        //    anime.SetBool("Move", true);
                        //    transform.Translate(-speed * Time.deltaTime, 0, 0);
                        //    break;
                    }
                  
                    break;

                case UNITSTATE.ATTACK:
                    anime.SetBool("Move", false);
                    anime.SetBool("Attack", false);
                    
                    switch(unit)
                    {
                        case UNIT.PLAYER:

                            if (look.Count > 0)
                            {

                                if (look[0] != null)
                                {
                                    stateTime += Time.deltaTime;
                                    anime.SetBool("Attack", true);
                                    if (look[0].tag == "Enemy")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {
                                            
                                            stateTime = 0;
                                            look[0].GetComponent<UnitController>().GetDamage(atk);

                                        }
                                    }

                                    if (look[0].tag == "Castle")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {
                                          
                                            stateTime = 0;
                                            look[0].GetComponent<Castle>().hp -= atk;

                                        }
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

                        case UNIT.ENEMY:


                            if (look.Count > 0)
                            {
                                if (look[0].tag == "Darking")
                                {

                                    stateTime += Time.deltaTime;
                                    anime.SetBool("Attack", true);



                                    if (stateTime > attackStateMaxTime)
                                    {

                                        stateTime = 0;
                                        look[0].GetComponent<PlayerController>().hp = -atk;

                                        float distance = Vector3.Distance(sensor.GetComponent<PlayerSensor>().pPos.position, sensor.transform.position);

                                        if (distance > 1f)
                                        {
                                            look.RemoveAt(0);
                                            unitstate = UNITSTATE.MOVE;
                                        }

                                        if (distance < 1f)
                                        {
                                            look.RemoveAt(0);
                                            unitstate = UNITSTATE.MOVE;
                                        }
                                    }

                                }



                                if (look[0].tag == "Player")
                                {
                                    stateTime += Time.deltaTime;
                                    anime.SetBool("Attack", true);


                                    if (stateTime > attackStateMaxTime)
                                    {

                                        stateTime = 0;
                                        look[0].GetComponent<UnitController>().GetDamage(atk);
                                    }
                                }

                            }

                            else
                            {
                                unitstate = UNITSTATE.MOVE;
                            }
                            break;

                        case UNIT.MIDDLEBOSS:

                            break;

                      
                    }

                    break;
                    
                case UNITSTATE.DEAD:


                    break;


            }

        }
      
        

    }

    void OnTriggerEnter(Collider col)
    {
       if(gameObject.tag == "Enemy")
        {
            if(col.gameObject.tag == "EnemyGoal")
            {
                gameObject.transform.position = new Vector3(5, -0.2f, -0.3f);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        //if (gameObject.tag == "Darking")
        //{
        //    look.Clear();
        //}
    }

    public void GetDamage(float dmg)
    {
        hP -= dmg;
          
        if(gameObject.tag=="Player")
        {
            //Instantiate(effect[0], transform.position, transform.rotation);
            GameObject dmgValue = Instantiate(dmgcheck[0]) as GameObject;
            dmgValue.transform.position = transform.position;
            dmgValue.transform.rotation = transform.rotation;
            dmgValue.GetComponent<TextMesh>().text = "-" + dmg;
        }

        else
        {
           // Instantiate(effect[1], transform.position, transform.rotation);
            GameObject dmgValue = Instantiate(dmgcheck[1]) as GameObject;
            dmgValue.transform.position = transform.position;
            dmgValue.transform.rotation = transform.rotation;
            dmgValue.GetComponent<TextMesh>().text = "-" + dmg;
        }

    }

    public void DeadProcess()
    {
        anime.SetBool("Dead", true);
        Destroy(sensor);
        look.Clear();
        
        diecol.enabled = false;
        anime.GetComponent<TweenAlpha>().enabled = true;
        Destroy(gameObject,1f);//오브젝트를 파괴한다
    }
}
