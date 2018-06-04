using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {


    public GameObject target;
    public GameObject caster;
    public float lv;
    public GameObject UnitsManager;
    private BoxCollider bc;
   
 
    public float atk;
    public float speed;

    public enum SKILLS
    {
        UNITSKILL=0,
        ENEMYSKILL
     
    }
    public SKILLS skills;

     void Awake()
    {
        //player = gameObject.transform.parent.gameObject;  
    }

    void Start()
    {
        //atk += player.GetComponent<UnitController>().b_Atk * lv * 0.1f;
        
        bc = GetComponent<BoxCollider>();
    }

    void Update()
    {
        switch (skills)
        {
            case SKILLS.UNITSKILL:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            
            case SKILLS.ENEMYSKILL:
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                break;
           
        }
    }

    void OnTriggerEnter(Collider col)
    {
        

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


