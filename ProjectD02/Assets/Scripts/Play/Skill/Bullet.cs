using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public GameObject[] hillUnits;
    public float skillAtk; //스킬의 계수를 정하는 변수
    public GameObject comet;
    private CometManager cm;
    private BoxCollider bc;
    public float speed;
    public float stunTime;
    public float numberOfTimes;
    public float skillCost;
    public GameObject iceberg;


    public enum SKILLS
    {
        BULLET,
        COMET,
        HILL,
        FIRE,
        WIND,
        THUNDERBOLT,
        ICE,
        CONVERT,
        POISON
    }
    public SKILLS skills;

    void Start()
    {
        switch (skills)
        {
            case SKILLS.COMET:
                cm = GameObject.Find("CometManager").GetComponent<CometManager>();
                cm.aoeTargets.Clear();
                break;
        }
    }
	void Update ()
    {
       
        switch (skills)
        {
            case SKILLS.BULLET:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.COMET:
                 transform.Translate(speed * Time.deltaTime, 0, 0);
                 //comet.transform.Translate(3 * Time.deltaTime, -5 * Time.deltaTime, 0);
                break;
            case SKILLS.HILL:
                player =GameObject.Find("Player");
                gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Destroy(gameObject, 2);
                break;
            case SKILLS.FIRE:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.WIND:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.THUNDERBOLT:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.ICE:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.CONVERT:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.POISON:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
         
        }

    }

    void OnTriggerEnter(Collider col)
    {
        switch (skills)
        {
            case SKILLS.BULLET:

                if (col.gameObject.tag == "Enemy")
                {
                    enemy = col.gameObject;
                    enemy.GetComponent<UnitController>().GetDamage(skillAtk);
                    Destroy(gameObject);
                }

                

                break;

            case SKILLS.COMET:


                if (col.gameObject.tag == "Enemy")
                {
                    if (cm.aoeTargets.Count <= 2)
                    {
                        cm.aoeTargets.Add(col.gameObject);
                    }

                    if (cm.aoeTargets.Count == 3 || col.gameObject.tag == "Finish")
                    {
                        foreach (GameObject target in cm.aoeTargets)
                        {
                            Debug.Log(target.name);
                            Instantiate(comet, new Vector3(target.transform.position.x - 3.5f, target.transform.position.y + 5, target.transform.position.z), comet.transform.rotation);
                            comet.name = "Comet" + cm.aoeTargets.IndexOf(target);
                            //transform.parent = target.transform;
                            target.GetComponent<UnitController>().GetDamage(skillAtk);
                        }

                        //for (int i = 0; i < cm.aoeTargets.Count; i++)
                        //{


                        //    Instantiate(comet, new Vector3(target[i].transform.position.x - 3.5f, target[i].transform.position.y + 5, target[i].transform.position.z), comet.transform.rotation);
                        //    transform.parent = target[i].transform;
                        //    target[i].GetComponent<UnitController>().GetDamage(skillAtk);
                        //}



                        Debug.Log("유성 3개 떨어뜨림!");
                    }
                }

                if (col.gameObject.tag == "Finish")
                {
                    Destroy(gameObject, 1);
                }

                break;

            case SKILLS.HILL:

                if(col.gameObject.tag=="Player")
                {
                    if(col.gameObject.GetComponent<UnitController>().hP>=0)
                    {
                       col.gameObject.GetComponent<UnitController>().hP += skillAtk;
                        
                    }
                }
             
                break;

            case SKILLS.FIRE:

                if(col.gameObject.tag=="Enemy")
                {
                    if(col.gameObject.GetComponent<UnitController>().hP>0)
                    {
                        col.gameObject.GetComponent<UnitController>().GetDamage(skillAtk);
                        Destroy(gameObject, 1.5f);
                    }
                }

                break;

            case SKILLS.WIND:

                if(col.gameObject.tag=="Enemy")
                {
                    enemy = col.gameObject;
                    enemy.GetComponent<UnitController>().idleStateMaxTime = stunTime;
                    enemy.GetComponent<UnitController>().stun = true;
                    enemy.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.IDLE;
                    enemy.transform.Translate(skillAtk*Time.deltaTime, enemy.transform.position.y, enemy.transform.position.z);
                    //bc.enabled = false;
                    Destroy(gameObject);
                }
                
                break;

            case SKILLS.THUNDERBOLT:

                if(col.gameObject.tag=="Enemy")
                {
                    col.gameObject.GetComponent<UnitController>().GetDamage(skillAtk);
                    col.gameObject.GetComponent<UnitController>().idleStateMaxTime = stunTime;
                    col.gameObject.GetComponent<UnitController>().stun = true;
                    col.gameObject.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.IDLE;
                    Destroy(gameObject, 1);
                }

               
                break;

            case SKILLS.ICE:


                if (col.gameObject.tag == "Enemy")
                {
                    enemy = col.gameObject;
                    enemy.GetComponent<UnitController>().idleStateMaxTime = stunTime;  //idleStateMaxTime은 idle 상태에서 머무르게 하는 시간이며, 머무르는 시간과 스턴 타임을 동일하게해서 스턴타임 만큼 아이들상태에서 기다리게함
                    enemy.GetComponent<UnitController>().stun = true; //스턴이 켜져있음을 알림
                    enemy.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.IDLE; 
                    gameObject.SetActive(false);
                    iceberg.GetComponent<IceBerg>().iceTime = stunTime;
                    Destroy(gameObject, stunTime);
                    
                    Instantiate(iceberg,enemy.transform.position=new Vector3(enemy.transform.position.x,enemy.transform.position.y,-0.5f),enemy.transform.rotation);

                    //아이스버그가 자신의 스터타임을 찾곡 그시간만큼 얼림
                }


                break;

            case SKILLS.CONVERT:


               
                break;

            case SKILLS.POISON:

                if(col.gameObject.tag == "Enemy")
                {
                    enemy = col.gameObject;
                    enemy.GetComponent<UnitController>().posionTime = numberOfTimes;
                    enemy.GetComponent<UnitController>().posionDMG = skillAtk;
                    enemy.GetComponent<UnitController>().DotDamage();
                    Destroy(gameObject);
                    //bc.enabled = false;

                    //if (dot < stunTime)
                    //{
                    //    dot += Time.deltaTime;
                    //    if (dot >= numberOfTimes)
                    //    {
                    //        numberOfTimes += 1;
                    //        enemy.GetComponent<UnitController>().GetDamage(skillAtk);
                    //        Debug.Log(numberOfTimes);

                    //    }

                    //    if (dot >= stunTime)
                    //    {
                    //        Destroy(gameObject);
                    //    }
                    //}
                }
            
                break;

        }
       
        
    }


}
