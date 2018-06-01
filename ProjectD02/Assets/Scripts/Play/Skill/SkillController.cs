using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {


    public GameObject target;
    public GameObject caster;
    public float lv;
    public GameObject UnitsManager;
 
    public float atk;
    public float speed;

    public List<GameObject> aoeTargets;

    public enum SKILLS
    {
        UNITSKILL=0,
        ENEMYSKILL,
        SKILL1,
        SKILL2,
        SKILL3
    }
    public SKILLS skills;

     void Awake()
    {
        //player = gameObject.transform.parent.gameObject;  
    }

    void Start()
    {
        //atk += player.GetComponent<UnitController>().b_Atk * lv * 0.1f;
        aoeTargets.Clear();
    }

    void Update()
    {
        switch (skills)
        {
            case SKILLS.UNITSKILL:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.SKILL2:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.ENEMYSKILL:
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                break;
           
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(caster.tag == "Darking")
        {
            if(col.gameObject.tag == "Enemy")
            {
                if (aoeTargets.Count <= 2)
                {
                    aoeTargets.Add(col.gameObject);                    
                }
                if(aoeTargets.Count == 3)
                {
                    foreach (GameObject i in aoeTargets)
                    {
                        Debug.Log(i.name);
                    }
                }
            }
        }

        if (caster.tag == "Player")
        {
            if (col.gameObject.tag == "Enemy")
            {
                target = col.gameObject;
                target.GetComponent<UnitController>().GetDamage(atk);
                Destroy(gameObject);
            }

            if (col.gameObject.tag == "Castle")
            {
                target = col.gameObject;
                target.GetComponent<Castle>().hp -= atk;
                Destroy(gameObject);
            }
        }

        if (caster.tag == "Enemy")
        {
            if (col.gameObject.tag == "Player")
            {
                target = col.gameObject;
                target.GetComponent<UnitController>().GetDamage(caster.GetComponent<UnitController>().atk);
                Destroy(gameObject);
             
            }

            if (col.gameObject.tag == "Darking")
            {
                target = col.gameObject;
                target.GetComponent<PlayerController>().hp -= atk;
                Destroy(gameObject);
            }
        }
    }

        //if (gameObject.tag =="Enemy")
        //{
        //player.GetComponent<UnitController>().enemy = col.gameObject;
        //}

}


