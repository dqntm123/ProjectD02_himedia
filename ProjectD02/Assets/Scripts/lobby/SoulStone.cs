﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class SoulStone : MonoBehaviour {

    public GameObject jewelPN;
    public GameObject[] jewelChang;
    public GameObject[] equipChang;
    public JewelBtnManager jewemanager;
    public bool[] btnIn;
    public int costValue;
    public int firstValue;
    public int soulSkillNumber;
    public UILabel[] lvLabel;

    void Awake()
    {
        if(SoulSkillManager.INSTANCE.stoneReinforce[soulSkillNumber] == 0)
        {
            gameObject.SetActive(false);
        }
        jewemanager = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        jewelPN = GameObject.Find("JewelPanel");
        gameObject.transform.parent = jewelPN.transform;
    }
    void Start()
    {
        if (SoulSkillManager.INSTANCE.stoneReinforce[soulSkillNumber] >= 0)
        {
            lvLabel[soulSkillNumber].text = "  " + SoulSkillManager.INSTANCE.stoneReinforce[soulSkillNumber].ToString();
        }
        if (SoulSkillManager.INSTANCE.stoneReinforce[soulSkillNumber] >= 5)
        {
            lvLabel[soulSkillNumber].text = "Max";
        }
        firstValue = jewemanager.stoneValue[soulSkillNumber];
        if (firstValue==0)
        {
            //Debug.Log("0");
            for (int a = 0; a < jewelChang.Length; a++)
            {
                jewelChang[a] = GameObject.Find("Stone" + a);
                if (jewelChang[a].GetComponent<JewelBtn>().stoneIn == false)
                {
                    if (btnIn[0] == false)
                    {
                        btnIn[0] = true;
                        btnIn[1] = false;
                        jewemanager.stoneValue[soulSkillNumber] = 1;
                        jewelChang[a].GetComponent<JewelBtn>().stoneIn = true;
                        jewelChang[a].GetComponent<JewelBtn>().soulItem = gameObject;
                        gameObject.transform.position = jewelChang[a].transform.position;
                        gameObject.transform.parent = jewelChang[a].transform;
                        jewemanager.jewelslotNum[a] = soulSkillNumber;
                        jewemanager.SaveValue();
                    }
                }
            }
        }
        else if(firstValue==1)
        {
           // Debug.Log("1");
            for (int a = 0; a < jewelChang.Length; a++)
            {
                jewelChang[a] = GameObject.Find("Stone" + a);
                if (jewelChang[a].GetComponent<JewelBtn>().stoneIn == false&&jewemanager.jewelslotNum[a]==soulSkillNumber)
                {
                    if (btnIn[0] == false)
                    {
                        btnIn[0] = true;
                        btnIn[1] = false;
                        jewelChang[a].GetComponent<JewelBtn>().stoneIn = true;
                        jewelChang[a].GetComponent<JewelBtn>().soulItem = gameObject;
                        gameObject.transform.position = jewelChang[a].transform.position;
                        gameObject.transform.parent = jewelChang[a].transform;
                        jewemanager.jewelslotNum[a] = soulSkillNumber;
                        jewemanager.SaveValue();
                    }
                }
            }
            for (int i = 0; i < equipChang.Length; i++)
            {
                equipChang[i] = GameObject.Find("EquipSlot" + i);
                if (equipChang[i].GetComponent<EquipSlotBtn>().soulIn == false && jewemanager.equipslotNum[i] == soulSkillNumber)
                {
                    if (btnIn[1] == false)
                    {
                        btnIn[0] = false;
                        btnIn[1] = true;
                        equipChang[i].GetComponent<EquipSlotBtn>().soulIn = true;
                        equipChang[i].GetComponent<EquipSlotBtn>().item = gameObject;
                        gameObject.transform.position = equipChang[i].transform.position;
                        gameObject.transform.parent = equipChang[i].transform;
                        jewemanager.equipslotNum[i] = soulSkillNumber;
                        jewemanager.SaveValue();
                    }
                }
            }
        }
        if (btnIn[0] == true&&btnIn[1]==false)
        {
            jewemanager.soulStoneItem.Add(gameObject);
        }
    }

    void Update()
    {
        
    }

}
