using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public float atk;

    public enum SKILLS
    {
       SKILL1,
       SKILL2,
       SKILL3
    }
    public SKILLS skills;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
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
                }

                break;

            case SKILLS.SKILL2:

                break;

            case SKILLS.SKILL3:

                break;
            
        }
       
        if (gameObject.tag =="Enemy")
        {
            //player.GetComponent<UnitController>().enemy = col.gameObject;
        }

    }

}
