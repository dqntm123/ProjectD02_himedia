using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour {

    public float speed;
    public float hP;
    public float atk;
    public int b_Atk;
    public Animator anime;

    public List<GameObject> look;

    public float lv;
    public float stateTime = 0;
    public Collider diecol;
    public GameObject sensor;
    public float attackStateMaxTime;
    public bool isDead = false;
    public GameObject[] dmgcheck;
    public GameObject[] effect;


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

        if (gameObject.tag == "Player")
        {
                atk += b_Atk * lv * 0.1f; 
        }

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
                            anime.SetBool("Move", true);
                            transform.Translate(speed * Time.deltaTime, 0, 0);
                            break;
                        case UNIT.ENEMY:
                            anime.SetBool("Move", true);
                            transform.Translate(-speed * Time.deltaTime, 0, 0);
                            break;
                    }
                  
                    break;

                case UNITSTATE.ATTACK:
                    anime.SetBool("Move", false);
                    anime.SetBool("Attack", false);
                    if (look.Count>0)
                    {
                        if(look[0] != null)
                        {
                            stateTime += Time.deltaTime;
                            anime.SetBool("Attack", true);
                            if (stateTime>attackStateMaxTime)
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
        diecol.enabled = false;
        //gameObject.GetComponent<TweenAlpha>().enabled = true;
        Destroy(gameObject,1f);//오브젝트를 파괴한다
    }
}
