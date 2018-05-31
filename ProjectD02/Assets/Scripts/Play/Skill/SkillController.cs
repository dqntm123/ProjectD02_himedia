using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {


    public GameObject enemy;
 
    public float atk;
    public float speed;

    public enum SKILLS
    {
        SKILL1=0,
        SKILL2,
        SKILL3
    }
    public SKILLS skills;

    void Start()
    {

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
            case SKILLS.SKILL3:
                break;
            
        }
    }

    void OnTriggerEnter(Collider col)
    {
        switch (skills)
        {
            case SKILLS.SKILL1:

                if (gameObject.tag == "Enemy")
                {
                    enemy = col.gameObject;
                    enemy.GetComponent<UnitController>().hP -= atk;
                    Destroy(gameObject);
                }


                if (gameObject.tag == "Castle")
                {
                    enemy = col.gameObject;
                    enemy.GetComponent<Castle>().hp -= atk;
                    Destroy(gameObject);
                }

                break;

            case SKILLS.SKILL2:

                break;

            case SKILLS.SKILL3:

                break;

        }

        //if (gameObject.tag =="Enemy")
        //{
        //player.GetComponent<UnitController>().enemy = col.gameObject;
        //}

    }

}
