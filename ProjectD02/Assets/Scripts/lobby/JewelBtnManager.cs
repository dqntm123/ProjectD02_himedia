using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JewelBtnManager : MonoBehaviour {

    public GameObject[] jewelBtn;
    public GameObject[] equipSlot;
    public GameObject[] equipBtn;
    public GameObject[] baseSoulsStone;
    public BtnManager btnmg;
    public List<GameObject> soulStoneItem;
    public GameObject clickBtn;
    public GameObject releaseBtn;
    public List<int> equipslotNum;
    public List<int> jewelslotNum;
    public List<int> stoneValue;
    void Awake()
    {
        for (int i = 0; i < baseSoulsStone.Length; i++)
        {
            if (SoulSkillManager.INSTANCE.stoneReinforce[baseSoulsStone[i].GetComponent<SoulStone>().soulSkillNumber] == 1)
            {
                baseSoulsStone[i].SetActive(true);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            equipslotNum.Add(-1);
        }
        for (int i = 0; i < 11; i++)
        {
            jewelslotNum.Add(-1);
        }
        
        LoadedValue();
        for (int i = 0; i < jewelBtn.Length; i++)
        {
            jewelBtn[i] = GameObject.Find("Stone" + i);
            jewelBtn[i].AddComponent<JewelBtn>();
            jewelBtn[i].GetComponent<JewelBtn>().myNumber = i;
            jewelBtn[i].GetComponent<JewelBtn>().sdL = GameObject.Find("ExplanationLabel").GetComponent<UILabel>();
        }
        for (int a = 0; a < equipSlot.Length; a++)
        {
            equipSlot[a] = GameObject.Find("EquipSlot" + a);
            equipSlot[a].AddComponent<EquipSlotBtn>();
            equipSlot[a].GetComponent<EquipSlotBtn>().myNum = a;
            equipSlot[a].GetComponent<EquipSlotBtn>().sdL = GameObject.Find("ExplanationLabel").GetComponent<UILabel>();
        }
        btnmg = GameObject.Find("BtnManager").GetComponent<BtnManager>();
        btnmg.jewelMg = gameObject;
    }

    void Start()
    {

    }
    void Update()
    {

    }
    public void Equip()//장착버튼
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (clickBtn != null)
        {
            for (int i = 0; i < equipSlot.Length; i++)
            {
                if(equipSlot[i].GetComponent<EquipSlotBtn>().soulIn==false)
                {
                    if(clickBtn.GetComponent<JewelBtn>().soulItem!=null)
                    {
                        if (clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().btnIn[1] == false)
                        {
                            clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().btnIn[0] = false;
                            clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().btnIn[1] = true;
                            equipSlot[i].GetComponent<EquipSlotBtn>().item = clickBtn.GetComponent<JewelBtn>().soulItem;
                            equipslotNum[equipSlot[i].GetComponent<EquipSlotBtn>().myNum] =jewelslotNum[clickBtn.GetComponent<JewelBtn>().myNumber];
                            jewelslotNum[clickBtn.GetComponent<JewelBtn>().myNumber] = -1;
                            clickBtn.GetComponent<JewelBtn>().soulItem.transform.parent = equipSlot[i].transform;
                            clickBtn.GetComponent<JewelBtn>().soulItem.transform.position = equipSlot[i].transform.position;
                            equipSlot[i].GetComponent<EquipSlotBtn>().soulIn = true;
                            soulStoneItem.Remove(clickBtn.GetComponent<JewelBtn>().soulItem);
                            SoulSkillManager.INSTANCE.soulskillNunber.Insert(i, clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber);
                            SoulSkillManager.INSTANCE.soulskillNunber.RemoveAt(3);
                            SoulSkillManager.INSTANCE.skillCostValue.Insert(i, clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().costValue);
                            SoulSkillManager.INSTANCE.skillCostValue.RemoveAt(3);
                            SaveValue();
                            SoulSkillManager.INSTANCE.SaveSoulStone();
                        }
                    }
                }
            }
        }
    }
    public void release()//해제 버튼
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (releaseBtn != null)
        {
            for (int a = 0; a < jewelBtn.Length; a++)
            {
                if (jewelBtn[a].GetComponent<JewelBtn>().stoneIn == false)
                {
                    if(releaseBtn.GetComponent<EquipSlotBtn>().item!=null)
                    {
                        if (releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn[0] == false)
                        {
                            releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn[0] = true;
                            releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn[1] = false;
                            releaseBtn.GetComponent<EquipSlotBtn>().item.transform.parent = jewelBtn[a].transform;
                            jewelslotNum[jewelBtn[a].GetComponent<JewelBtn>().myNumber] = equipslotNum[releaseBtn.GetComponent<EquipSlotBtn>().myNum];
                            equipslotNum[releaseBtn.GetComponent<EquipSlotBtn>().myNum] = -1;
                            jewelBtn[a].GetComponent<JewelBtn>().soulItem = releaseBtn.GetComponent<EquipSlotBtn>().item;
                            releaseBtn.GetComponent<EquipSlotBtn>().item.transform.position = jewelBtn[a].transform.position;
                            jewelBtn[a].GetComponent<JewelBtn>().stoneIn = true;
                            soulStoneItem.Add(releaseBtn.GetComponent<EquipSlotBtn>().item);
                            SoulSkillManager.INSTANCE.soulskillNunber[releaseBtn.GetComponent<EquipSlotBtn>().myNum]=-1;
                            SoulSkillManager.INSTANCE.skillCostValue[releaseBtn.GetComponent<EquipSlotBtn>().myNum]=-1;
                            SaveValue();
                            SoulSkillManager.INSTANCE.SaveSoulStone();
                        }
                    }
                }
            }
        }
    }
    public void ReArangeBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        for (int i = 0; i < soulStoneItem.Count; i++)
        {
            soulStoneItem[i].transform.position = jewelBtn[i].transform.position;
            jewelBtn[i].GetComponent<JewelBtn>().soulItem = soulStoneItem[i];
            jewelBtn[i].GetComponent<JewelBtn>().soulItem.transform.parent = jewelBtn[i].transform;
            jewelBtn[i].GetComponent<JewelBtn>().stoneIn = true;
            jewelslotNum[i] = jewelBtn[i].GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber;
        }
        for (int i = 0; i < jewelslotNum.Count; i++)
        {
            if (jewelBtn[i].GetComponent<JewelBtn>().soulItem!=null&& jewelBtn[i].GetComponent<JewelBtn>().soulItem.transform.parent!= jewelBtn[i].transform)
            {
                jewelslotNum[i] = -1;
            }
        }
        SoulSkillManager.INSTANCE.SaveSoulStone();
        SaveValue();
    }
    public void SaveValue()
    {
        //Debug.Log("저장!");
        for (int i = 0; i < equipslotNum.Count; i++)
        {
            PlayerPrefs.SetInt("EquipSlotNumBer" + i, equipslotNum[i]);
        }
        for (int i = 0; i < jewelslotNum.Count; i++)
        {
            PlayerPrefs.SetInt("JewelSlotNumBer" + i, jewelslotNum[i]);
        }
        for (int i = 0; i < stoneValue.Count; i++)
        {
            PlayerPrefs.SetInt("StoneFirstNumBer" + i, stoneValue[i]);
        }
    }
    public void LoadedValue()
    {
        //Debug.Log("불러옴!");
        for (int i = 0; i < equipslotNum.Count; i++)
        {
            equipslotNum[i]= PlayerPrefs.GetInt("EquipSlotNumBer" + i, equipslotNum[i]);
        }
        for (int i = 0; i < jewelslotNum.Count; i++)
        {
            jewelslotNum[i] = PlayerPrefs.GetInt("JewelSlotNumBer" + i, jewelslotNum[i]);
        }
        for (int i = 0; i < stoneValue.Count; i++)
        {
            stoneValue[i] = PlayerPrefs.GetInt("StoneFirstNumBer" + i, stoneValue[i]);
        }
    }
}
