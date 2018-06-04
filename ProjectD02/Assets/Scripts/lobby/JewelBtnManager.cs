using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JewelBtnManager : MonoBehaviour {

    public GameObject[] jewelBtn;
    public GameObject[] equipSlot;
    public GameObject[] equipBtn;
    public BtnManager btnmg;
    public List<GameObject> soulStoneItem;
    public GameObject clickBtn;
    public GameObject releaseBtn;
    public bool sibal = false;

    void Awake()
    {
        btnmg = GameObject.Find("BtnManager").GetComponent<BtnManager>();
        btnmg.jewelMg = gameObject;
        for (int i = 0; i < jewelBtn.Length; i++)
        {
            jewelBtn[i] = GameObject.Find("Stone" + i);
            jewelBtn[i].AddComponent<JewelBtn>();
            jewelBtn[i].GetComponent<JewelBtn>().myNumber = i;
            jewelBtn[i].GetComponent<JewelBtn>().sdL = GameObject.Find("ExplanationLabel").GetComponent<UILabel>();
        }
        for (int a = 0; a < equipSlot.Length; a++)
        {
            equipSlot[a] = GameObject.Find("Slot" + a);
            equipSlot[a].AddComponent<EquipSlotBtn>();
            equipSlot[a].GetComponent<EquipSlotBtn>().myNum = a;
            equipSlot[a].GetComponent<EquipSlotBtn>().sdL = GameObject.Find("ExplanationLabel").GetComponent<UILabel>();
        }
    }

    void Start()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.buildIndex==1)
        {
            sibal = false;
        }
    }
    void Update()
    {
        if (sibal == false)
        {
            for (int i = 0; i < jewelBtn.Length; i++)
            {
                if (jewelBtn[i].GetComponent<JewelBtn>().stoneIn == true)
                {
                    soulStoneItem.Insert(i, jewelBtn[i].GetComponent<JewelBtn>().soulItem);
                }
            }
            sibal = true;
        }
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
                            //equipSlot[i].GetComponent<EquipSlotBtn>().equipSoulNum[i] = clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber;
                            //clickBtn.GetComponent<JewelBtn>().slotSoulNum[clickBtn.GetComponent<JewelBtn>().myNumber] = -1;
                            //equipSlot[i].GetComponent<EquipSlotBtn>().SaveEquipSoulNumber();
                            equipSlot[i].GetComponent<EquipSlotBtn>().item = clickBtn.GetComponent<JewelBtn>().soulItem;
                            clickBtn.GetComponent<JewelBtn>().soulItem.transform.parent = equipSlot[i].transform;
                            clickBtn.GetComponent<JewelBtn>().soulItem.transform.position = equipSlot[i].transform.position;
                            equipSlot[i].GetComponent<EquipSlotBtn>().soulIn = true;
                            soulStoneItem.Remove(clickBtn.GetComponent<JewelBtn>().soulItem);
                            SoulSkillManager.INSTANCE.soulskillNunber.Insert(i, clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber);
                            SoulSkillManager.INSTANCE.skillCostValue.Insert(i, clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().costValue);
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
                            jewelBtn[a].GetComponent<JewelBtn>().slotSoulNum[a] = releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber;
                            //releaseBtn.GetComponent<EquipSlotBtn>().equipSoulNum[releaseBtn.GetComponent<EquipSlotBtn>().myNum] = -1;
                            //jewelBtn[a].GetComponent<JewelBtn>().soulItem = releaseBtn.GetComponent<EquipSlotBtn>().item;
                            releaseBtn.GetComponent<EquipSlotBtn>().item.transform.parent = jewelBtn[a].transform;
                            releaseBtn.GetComponent<EquipSlotBtn>().item.transform.position = jewelBtn[a].transform.position;
                            jewelBtn[a].GetComponent<JewelBtn>().stoneIn = true;
                            soulStoneItem.Add(releaseBtn.GetComponent<EquipSlotBtn>().item);
                            SoulSkillManager.INSTANCE.soulskillNunber.Remove(releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber);
                            SoulSkillManager.INSTANCE.skillCostValue.Remove(releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().costValue);
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
            //jewelBtn[i].GetComponent<JewelBtn>().slotSoulNum[i] = jewelBtn[i].GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber;
        }
    }
    public void SaveStonePos()
    {

    }
    public void LoadedStonePos()
    {

    }
}
