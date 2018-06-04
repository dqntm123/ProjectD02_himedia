using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class SoulStone : MonoBehaviour {

    public GameObject jewelPN;
    public GameObject[] jewelChang;
    public GameObject[] equipChang;
    public bool[] btnIn;
    public int costValue;
    public int[] firstValue;
    public int soulSkillNumber;
    void Awake()
    {
        jewelPN = GameObject.Find("JewelPanel");
        gameObject.transform.parent = jewelPN.transform;
    }
    void Start()
    {
        //LoadedFirstValue();
        if (firstValue[soulSkillNumber] == 0)
        {
            Debug.Log("0");
            for (int a = 0; a < jewelChang.Length; a++)
            {
                jewelChang[a] = GameObject.Find("Stone" + a);
                if (jewelChang[a].GetComponent<JewelBtn>().stoneIn == false)
                {
                    if (btnIn[0] == false)
                    {
                        btnIn[0] = true;
                        btnIn[1] = false;
                        jewelChang[a].GetComponent<JewelBtn>().stoneIn = true;
                        jewelChang[a].GetComponent<JewelBtn>().soulItem = gameObject;
                        gameObject.transform.position = jewelChang[a].transform.position;
                        gameObject.transform.parent = jewelChang[a].transform;
                        //firstValue[soulSkillNumber] = 1;
                        jewelChang[a].GetComponent<JewelBtn>().slotSoulNum[a] = soulSkillNumber;
                    }
                }
            }
        }
        else if (firstValue[soulSkillNumber] == 1)
        {
            Debug.Log("1");
            for (int i = 0; i < jewelChang.Length; i++)
            {
                jewelChang[i] = GameObject.Find("Stone" + i);
                if (jewelChang[i].GetComponent<JewelBtn>().stoneIn == false)
                {
                    if (jewelChang[i].GetComponent<JewelBtn>().slotSoulNum[jewelChang[i].GetComponent<JewelBtn>().myNumber] == soulSkillNumber)
                    {
                        if (btnIn[0] == false)
                        {
                            btnIn[0] = true;
                            btnIn[1] = false;
                            jewelChang[i].GetComponent<JewelBtn>().stoneIn = true;
                            jewelChang[i].GetComponent<JewelBtn>().soulItem = gameObject;
                            gameObject.transform.position = jewelChang[i].transform.position;
                            gameObject.transform.parent = jewelChang[i].transform;
                        }
                    }
                }
            }
            for (int a = 0; a < equipChang.Length; a++)
            {
                equipChang[a] = GameObject.Find("Slot" + a);
                if (equipChang[a].GetComponent<EquipSlotBtn>().soulIn == false)
                {
                    if (equipChang[a].GetComponent<EquipSlotBtn>().equipSoulNum[equipChang[a].GetComponent<EquipSlotBtn>().myNum] == soulSkillNumber)
                    {
                        if (equipChang[a].GetComponent<EquipSlotBtn>().item != null)
                        {
                            if (equipChang[a].GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn[0] == false)
                            {
                                equipChang[a].GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn[0] = true;
                                equipChang[a].GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn[1] = false;
                                equipChang[a].GetComponent<EquipSlotBtn>().item = gameObject;
                                gameObject.transform.position = equipChang[a].transform.position;
                                gameObject.transform.parent = equipChang[a].transform;
                            }
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        //SaveFirstValue();
    }

    public void SaveFirstValue()
    {
        //for (int i = 0; i < firstValue.Length; i++)
        //{
        //    PlayerPrefs.SetInt("FirstValue0" + i, firstValue[i]);
        //}
    }
    public void LoadedFirstValue()
    {
        //for (int i = 0; i < firstValue.Length; i++)
        //{
        //    firstValue[i] = PlayerPrefs.GetInt("FirstValue0"+i,firstValue[i]);
        //}
    }
}
