using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public GameObject[] skill;
    public GameObject manaMG;
    public float[] skillCost;
	void Start ()
    {
        manaMG = GameObject.Find("ManaManager");	
	}
	
	void Update ()
    {
		
	}

    public void Skill1()
    {
        if(manaMG.GetComponent<ManaManager>().manaCount >= skillCost[0])
        {
            manaMG.GetComponent<ManaManager>().manaCount -= skillCost[0];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(skillCost[0] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[0], transform.position, transform.rotation);//skill배열의 0번을 생성한다
        }
    }
    public void Skill2()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= skillCost[1])
        {
            manaMG.GetComponent<ManaManager>().manaCount -= skillCost[1];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(skillCost[1] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[1], transform.position, transform.rotation);//skill배열의 1번을 생성한다
        }
    }
    public void Skill3()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= skillCost[2])
        {
            manaMG.GetComponent<ManaManager>().manaCount -= skillCost[2];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(skillCost[2] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[2], transform.position, transform.rotation);//skill배열의 2번을 생성한다
        }
    }
}
