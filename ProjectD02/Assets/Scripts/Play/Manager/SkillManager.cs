using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

    public GameObject[] skill;
    public GameObject manaMG;
    public GameObject player;
    public UILabel[] costLabel;
    public int[] skillCost;
    public float skillmo;
    public float statetime;
    public bool skillstart = false;

    void Start ()
    {
        manaMG = GameObject.Find("ManaManager");
        player = GameObject.Find("Player");
        //skillCost[0] = SoulSkillManager.INSTANCE.skillCostValue[0];
        //skillCost[1] = SoulSkillManager.INSTANCE.skillCostValue[1];
        //skillCost[2] = SoulSkillManager.INSTANCE.skillCostValue[2];
        //costLabel[0].text = skillCost[0].ToString();
        //costLabel[1].text = skillCost[1].ToString();
        //costLabel[2].text = skillCost[2].ToString();
    }
	
	void Update ()
    {
        if(skillstart == true)
        {
            statetime += Time.deltaTime;
            if (statetime > skillmo)
            {
                Instantiate(skill[0], transform.position, transform.rotation);//skill배열의 0번을 생성한다
                player.GetComponent<PlayerController>().playstate = PlayerController.PLAYSTATE.NONE;
                skillstart = false;
                statetime = 0;
                player.GetComponent<PlayerController>().moveSpeed = 0.4f;
            }
        }               
	}

    public void Skill1()
    {
        if(manaMG.GetComponent<ManaManager>().manaCount >= skillCost[0])
        {
            
            player.GetComponent<PlayerController>().playstate = PlayerController.PLAYSTATE.Attack1;
            player.GetComponent<PlayerController>().moveSpeed = 0;
            manaMG.GetComponent<ManaManager>().manaCount -= skillCost[0];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(skillCost[0] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
          
            skillstart = true;
        }
    }   

    public void Skill2()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= skillCost[1])
        {          
            manaMG.GetComponent<ManaManager>().manaCount -= skillCost[1];
            player.GetComponent<PlayerController>().moveSpeed = 0;
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(skillCost[1] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);       //skill배열의 1번을 생성한다

            skill[1].GetComponent<SkillController>().caster = player;
        }
    }
    public void Skill3()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= skillCost[2])
        {
            manaMG.GetComponent<ManaManager>().manaCount -= skillCost[2];
            player.GetComponent<PlayerController>().moveSpeed = 0;
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(skillCost[2] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[2], transform.position, transform.rotation);//skill배열의 2번을 생성한다
        }
    }
}
