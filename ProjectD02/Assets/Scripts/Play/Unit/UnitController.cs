using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour {

    public float speed;
    public float hP;
    public float b_Hp;
    public float atk;
    public int b_Atk;
    public float maxHp;
    public Animator anime;
    public int sn;
    public StageManager sm;
    public List<GameObject> look;
    public float lv;
    public float stateTime = 0;
    private Collider diecol;
    public GameObject sensor;
    public float attackStateMaxTime;
    public float idleStateMaxTime;
    public bool isDead = false;
    public GameObject[] dmgcheck;
    public GameObject[] effect;
    public GameObject Bullets;
    public GameObject lvManager;
    public GameObject[] hpBar;
    public GameObject Main;
    public GameObject[] somon;
    public int[] SomonRound;
    public RoundManager rm;
    public bool stun=false;
    public GameObject skill;
    public float posionTime;
    public float posionDMG;
    public GameObject dropGold;
    public GameObject dropSoul;
    private int goldRate;
    private int soulRate;
    public GameObject mm;






    public enum UNIT //케릭터의 종류를 정함
    {
        PLAYER = 0,
        GUARDIAN,
        ENEMY,
        MIDDLEBOSS,
        PLAYERACHER,
        ENEMYACHER,
        BOSS

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
        Main = GameObject.FindGameObjectWithTag("Darking");
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        diecol = gameObject.GetComponent<BoxCollider>();
        anime.GetComponent<TweenAlpha>().enabled = false;
        sn = sm.currentStageNum;
        rm = GameObject.Find("RoundManager").GetComponent<RoundManager>();
        mm = GameObject.Find("MoneyManager");
        //Bullets.SetActive(false);
        //lv=lvManager.GetComponent<LevelManager>().
        if (gameObject.tag == "Player")
        {
            atk += b_Atk * lv * 0.1f;
            hP += b_Hp * lv * 0.1f;
            maxHp = hP;
        }
        if(gameObject.tag == "Enemy")
        {
            atk += b_Atk * sn * 0.1f;
            hP += b_Hp * sn * 0.1f;
            maxHp = hP;
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
        

      if(Main.GetComponent<PlayerController>().hp<=0)
        {
            isDead = true;
            DeadProcess();
        }

        if(hP <= 0)
        {
            hP = 0;
            hpBar[1].transform.localScale = new Vector3(0, 1, 1);
            isDead = true;
        
            DeadProcess();

         
            if (goldRate <= 19)
            {
                if(dropGold!=null)
                {
                    Instantiate(dropGold, transform.position, transform.rotation);
                    MoneyManager.inStance.AssaGoldDeuck();
                    
                    dropGold = null;
                }

                else
                {
                    dropGold = null;
                }
            }

            else
            {
                dropGold = null;
            }


            if (soulRate <= 19)
            {
                if (dropSoul != null)
                {
                    Instantiate(dropSoul, transform.position, transform.rotation);
                    MoneyManager.inStance.AssaGoldDeuck();
                    dropSoul = null;
                }

                else
                {
                    dropSoul = null;
                }
            }

            else
            {
                dropSoul = null;
            }


        }

        if(isDead == false)
        {
            switch (unitstate)
            {
                case UNITSTATE.IDLE:
                    
                    if (stun == false)
                    {
                        if (look.Count==0 || look[0]==null)
                        {
                            look.Clear();
                            unitstate = UNITSTATE.MOVE;
                        }

                        else
                        {
                            unitstate = UNITSTATE.ATTACK;
                        }

                     
                    }
                   
                    if(stun==true)
                    {
                     
                        stateTime += Time.deltaTime;
                        if(stateTime>idleStateMaxTime)
                        {
                            stateTime = 0;
                            unitstate = UNITSTATE.IDLE;
                            stun = false;
                        }

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
                            if(gameObject.transform.position.x<=3.5f)
                            {
                                unitstate = UNITSTATE.ATTACK;
                            }
                            break;

                        case UNIT.PLAYERACHER:
                            anime.SetBool("Attack", false);
                            anime.SetBool("Move", true);
                            transform.Translate(speed * Time.deltaTime, 0, 0);
                            break;

                        case UNIT.BOSS:
                            anime.SetBool("Attack", false);
                            anime.SetBool("Move", true);
                            transform.Translate(-speed * Time.deltaTime, 0, 0);
                            break;
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
                                if (look[0] != null)
                                {
                                    stateTime += Time.deltaTime;
                                    anime.SetBool("Attack", true);

                                    if (look[0].tag == "Player")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {
                                            stateTime = 0;
                                            look[0].GetComponent<UnitController>().GetDamage(atk);
                                        }
                                    }


                                    if (look[0].tag == "Darking")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {

                                            stateTime = 0;
                                            look[0].GetComponent<PlayerController>().hp -= atk;

                                            //float distance = Vector3.Distance(sensor.GetComponent<PlayerSensor>().playerPos.position, sensor.transform.position);

                                            float distance = sensor.GetComponent<PlayerSensor>().playerPos.position.x - sensor.transform.position.x;

                                            if (distance < -0.5f)
                                            {
                                                look.RemoveAt(0);
                                                unitstate = UNITSTATE.MOVE;
                                            }

                                            if (distance > 0)
                                            {
                                                look.RemoveAt(0);
                                                unitstate = UNITSTATE.MOVE;
                                            }

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

                        case UNIT.MIDDLEBOSS:

                            stateTime += Time.deltaTime;
                            anime.SetBool("Attack", true);
                            if (sn == SomonRound[0])
                            {
                                if (stateTime > attackStateMaxTime)
                                {
                                    stateTime = 0;
                                    Instantiate(somon[0], transform.position, transform.rotation);
                                }
                            }

                            if(sn== SomonRound[1])
                            {
                                if (stateTime > attackStateMaxTime)
                                {
                                    stateTime = 0;
                                    Instantiate(somon[0], transform.position, transform.rotation);
                                }
                            }

                            break;

                        case UNIT.BOSS:


                            if (look.Count > 0)
                            {
                                if (look[0] != null)
                                {
                                    stateTime += Time.deltaTime;
                                    anime.SetBool("Attack", true);

                                    if (look[0].tag == "Player")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {
                                            stateTime = 0;
                                            look[0].GetComponent<UnitController>().GetDamage(atk);
                                        }
                                    }


                                    if (look[0].tag == "Darking")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {

                                            stateTime = 0;
                                            look[0].GetComponent<PlayerController>().hp -= atk;

                                            //float distance = Vector3.Distance(sensor.GetComponent<PlayerSensor>().playerPos.position, sensor.transform.position);

                                            float distance = sensor.GetComponent<PlayerSensor>().playerPos.position.x - sensor.transform.position.x;

                                            if (distance < -0.5f)
                                            {
                                                look.RemoveAt(0);
                                                unitstate = UNITSTATE.MOVE;
                                            }

                                            if (distance > 0)
                                            {
                                                look.RemoveAt(0);
                                                unitstate = UNITSTATE.MOVE;
                                            }

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

                        case UNIT.PLAYERACHER:

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
                                         
                                            Bullets.GetComponent<SkillController>().atk = atk;
                                            Bullets.GetComponent<SkillController>().lv = lv;
                                            Instantiate(Bullets, transform.position, transform.rotation);
                                       
                                         
                                         


                                        }
                                    }

                                    if (look[0].tag == "Castle")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {

                                            stateTime = 0;
                                            Bullets.GetComponent<SkillController>().atk = atk;
                                            Bullets.GetComponent<SkillController>().lv = lv;
                                            Instantiate(Bullets, transform.position, transform.rotation);

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


                        case UNIT.ENEMYACHER:

                            if (look.Count > 0)
                            {
                                if (look[0] != null)
                                {
                                    stateTime += Time.deltaTime;
                                    anime.SetBool("Attack", true);

                                    if (look[0].tag == "Player")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {
                                            stateTime = 0;
                                            Instantiate(Bullets, transform.position, transform.rotation);
                                        }
                                    }


                                    if (look[0].tag == "Darking")
                                    {
                                        if (stateTime > attackStateMaxTime)
                                        {

                                            stateTime = 0;
                                            Instantiate(Bullets, transform.position, transform.rotation);

                                            //float distance = Vector3.Distance(sensor.GetComponent<PlayerSensor>().playerPos.position, sensor.transform.position);

                                            float distance = sensor.GetComponent<PlayerSensor>().playerPos.position.x - sensor.transform.position.x;

                                            if (distance < -0.5f)
                                            {
                                                look.RemoveAt(0);
                                                unitstate = UNITSTATE.MOVE;
                                            }

                                            if (distance > 0)
                                            {
                                                look.RemoveAt(0);
                                                unitstate = UNITSTATE.MOVE;
                                            }

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




                    }

                    break;
                    
                case UNITSTATE.DEAD:


                    break;

            }
        }
        if(hP<maxHp)
        {
            if (isDead == false)
            {
                hpBar[0].SetActive(true);
                hpBar[1].SetActive(true);
                if (hpBar[1].transform.localScale.x < 0)
                {
                    hpBar[1].transform.localScale = new Vector3(0, 1, 1);
                }
                hpBar[1].transform.localScale = new Vector3(hP / maxHp * 1, 1, 1);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
       if(gameObject.tag == "Enemy")
        {
            if(col.gameObject.tag == "EnemyGoal")
            {
                gameObject.transform.position = new Vector3(5, -0.05f, -0.3f);
            }
        }

       if(col.gameObject.tag=="Skill")
        {
            skill = col.gameObject;
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
        if(unit ==UNIT.BOSS)
        {
            rm.GetComponent<RoundManager>().bossDead = true;
        }

        if (unit == UNIT.MIDDLEBOSS)
        {
            rm.GetComponent<RoundManager>().bossDead = true;
        }

        if(unit==UNIT.ENEMY)
        {
            goldRate = Random.Range(0, 99);
            soulRate = Random.Range(0, 99);
        }
        anime.SetBool("Dead", true);
        Destroy(sensor);      
        diecol.enabled = false;
        anime.GetComponent<TweenAlpha>().enabled = true;
        Destroy(gameObject,1f);//오브젝트를 파괴한다
    }

    public void DotDamage()
    {
        StartCoroutine(DotCo());
    }

    public IEnumerator DotCo()
    {
        for (int i = 0; i < posionTime; i++)
        {
            gameObject.GetComponent<UnitController>().GetDamage(posionDMG);
            UISprite spr = gameObject.GetComponent<UISprite>();
            // Color green = new Color(53 / 255, 188 / 255, 12 / 255);
            //spr.color = Color.green;
            //rfuILabel[i].color = Color.red;
            if (i==10)
            {
                //spr.color = Color.white;
                yield return null;
            }
            if (hP <= 0)
            {
                hP = 0;
                isDead = true;
                DeadProcess();
            }
            yield return new WaitForSeconds(1f);
        }

    }
}
