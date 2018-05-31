using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {


    public GameObject enemy;
    public GameObject player;
 
    public float atk;
    public float speed;

    public enum SKILLS
    {
        SKILL1=0,
        SKILL2
    }
    public SKILLS skills;

    void Start()
    {
        atk = player.GetComponent<UnitController>().atk;
    }

    void Update()
    {
        switch (skills)
        {
            case SKILLS.SKILL1:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case SKILLS.SKILL2:
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
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
                enemy.GetComponent<UnitController>().GetDamage(atk);
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


