using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {


    public GameObject enemy;
    public GameObject player;
    public float lv;
    public GameObject UnitsManager;
 
    public float atk;
    public float speed;

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
    }

    void Update()
    {
        switch (skills)
        {
            case SKILLS.UNITSKILL:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.SKILL2:
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                break;

            case SKILLS.ENEMYSKILL:
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                break;
           
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (player.tag == "Player")
        {
            if (col.gameObject.tag == "Enemy")
            {
                enemy = col.gameObject;
                enemy.GetComponent<UnitController>().GetDamage(atk);
                Destroy(gameObject);
        
            }


            if (col.gameObject.tag == "Castle")
            {
                enemy = col.gameObject;
                enemy.GetComponent<Castle>().hp -= atk;
                Destroy(gameObject);
            }
        }

        if (player.tag == "Enemy")
        {
            if (col.gameObject.tag == "Player")
            {
                enemy = col.gameObject;
                enemy.GetComponent<UnitController>().GetDamage(player.GetComponent<UnitController>().atk);
                Destroy(gameObject);
             
            }


            if (col.gameObject.tag == "Darking")
            {
                enemy = col.gameObject;
                enemy.GetComponent<PlayerController>().hp -= atk;
                Destroy(gameObject);
            }
        }


    }

        //if (gameObject.tag =="Enemy")
        //{
        //player.GetComponent<UnitController>().enemy = col.gameObject;
        //}

    }


