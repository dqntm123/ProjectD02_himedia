using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public GameObject[] hillUnits;
    public float b_skillAtk;
    public float skillAtk; //스킬의 계수를 정하는 변수
    public GameObject[] comet;
    private CometManager cm;
    public Collider bc;
    public float speed;
    public float b_stunTime;
    public float stunTime;
    public float numberOfTimes;
    public float skillCost;
    public GameObject iceberg;
    public List<GameObject> aoeTargets;
    public int lV;


    public enum SKILLS
    {
        BULLET,
        COMET,
        HILL,
        FIRE,
        WIND,
        THUNDERSTORM,
        ICE,
        CONVERT,
        POISON
    }
    public SKILLS skills;

    void Start()
    {
     
        bc = gameObject.GetComponent<BoxCollider>();
       

      

        switch (skills)
        {
            case SKILLS.WIND:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[0];
                stunTime += b_stunTime * lV * 0.1f;
                break;

            case SKILLS.COMET:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[1];
                skillAtk += b_skillAtk * lV * 0.2f;
                aoeTargets.Clear();
                break;

            case SKILLS.FIRE:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[2];
                skillAtk += b_skillAtk * lV * 0.2f;
                break;

            case SKILLS.POISON:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[3];
                skillAtk += b_skillAtk * lV * 0.2f;
                break;

            case SKILLS.THUNDERSTORM:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[4];
                skillAtk += b_skillAtk * lV * 0.2f;

                break;

            case SKILLS.HILL:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[5];
                skillAtk += b_skillAtk * lV * 0.2f;
                break;

            case SKILLS.CONVERT:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[6];
                skillAtk += b_skillAtk * lV * 0.1f;
                Destroy(gameObject, 1);
                break;

            case SKILLS.ICE:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[7];
                stunTime += b_stunTime * lV * 0.1f;

                break;

            case SKILLS.BULLET:
                lV = SoulSkillManager.INSTANCE.stoneReinforce[8];
                skillAtk += b_skillAtk * lV * 0.2f;
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
            case SKILLS.THUNDERSTORM:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                Destroy(gameObject, stunTime);
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

        if(col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

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

                    if (aoeTargets.Count <= 2)
                    {
                        aoeTargets.Add(col.gameObject);
                    }

                }

                if (col.gameObject.tag == "Finish")
                {
                    for (int i = 0; i < aoeTargets.Count; i++)
                    {
                        comet[i].GetComponent<CometMove>().target = aoeTargets[i];
                        Instantiate(comet[i], new Vector3(comet[i].GetComponent<CometMove>().target.transform.position.x - 3.5f, comet[i].GetComponent<CometMove>().target.transform.position.y + 5, comet[i].GetComponent<CometMove>().target.transform.position.z), comet[i].transform.rotation);
                    }
                    bc.enabled = false;
                    Destroy(gameObject, 1);
                    speed = 0;
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
                    enemy.GetComponent<UnitController>().wind = true;
                    enemy.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.IDLE;
                    bc.enabled = false;
                    //enemy.transform.Translate(skillAtk*Time.deltaTime, enemy.transform.position.y, enemy.transform.position.z);

                    Destroy(gameObject,1);
                }
                
                if(col.gameObject.tag=="Finish")
                {
                    Destroy(gameObject);
                }
                break;

            case SKILLS.THUNDERSTORM:

                if (col.gameObject.tag == "Enemy")
                {
                 
                    col.gameObject.GetComponent<UnitController>().GetDamage(skillAtk);
                    col.gameObject.GetComponent<UnitController>().idleStateMaxTime = stunTime;
                    col.gameObject.GetComponent<UnitController>().stun = true;
                    col.gameObject.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.IDLE;

                    Destroy(gameObject, 0.5f);
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
                    bc.enabled = false;

                    Instantiate(iceberg,enemy.transform.position=new Vector3(enemy.transform.position.x,enemy.transform.position.y,-0.5f),enemy.transform.rotation);

                    //아이스버그가 자신의 스터타임을 찾곡 그시간만큼 얼림
                }

                if(col.gameObject.tag == "Finish")
                {
                    Destroy(gameObject);
                }


                break;

            case SKILLS.CONVERT:


               
                break;

            case SKILLS.POISON:

                if(col.gameObject.tag == "Enemy")
                {
                    enemy = col.gameObject;
                    bc.enabled = false;
                    enemy.GetComponent<UnitController>().posionTime = numberOfTimes;
                    enemy.GetComponent<UnitController>().posionDMG = skillAtk;
                    enemy.GetComponent<UnitController>().DotDamage();
                   
                    Destroy(gameObject);




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
