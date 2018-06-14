using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlotBtn : MonoBehaviour {

    public JewelBtnManager jewelMg;
    public GameObject item;
    public GameObject soulUpMg;
    public bool soulIn = false;
    public int equipCount;
    public int myNum;
    public GameObject sel;
    public Vector3 selPos;
    public UILabel sdL;         //stone detail label
    public string sdStr;        //stone detail string
    public List<string> stoneDetails;
    void Awake()
    {
        jewelMg = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        sel = GameObject.Find("Selector");
        selPos = sel.transform.localPosition;
        stoneDetails = GameObject.Find("SoulStoneDetailList").GetComponent<SoulStoneDetailList>().stoneDetailStr;
        soulUpMg = GameObject.Find("UpgradeManager");
    }
    void Start()
    {
        //if (item != null)
        //{
        //    item.GetComponent<SoulStone>().lvLabel[item.GetComponent<SoulStone>().soulSkillNumber].text = SoulSkillManager.INSTANCE.stoneReinforce[item.GetComponent<SoulStone>().soulSkillNumber].ToString();
        //    if(SoulSkillManager.INSTANCE.stoneReinforce[item.GetComponent<SoulStone>().soulSkillNumber]>=5)
        //    {
        //        item.GetComponent<SoulStone>().lvLabel[item.GetComponent<SoulStone>().soulSkillNumber].text = "Max";
        //    }
        //}
    }
    void Update()
    {
        if (sel.transform.parent != gameObject.transform)
        {
            equipCount = 0;
        }
        if (item != null && item.transform.parent != gameObject.transform)
        {
            //item = null;
            soulIn = false;
        }
        if(soulIn==false)
        {
            item = null;
        }
    }

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        jewelMg.equipBtn[0].SetActive(false);
        jewelMg.equipBtn[1].SetActive(true);
        sel.transform.parent = gameObject.transform;
        sel.transform.position = gameObject.transform.position;
        equipCount += 1;
        if(item!=null)
        {
            sdStr = stoneDetails[item.GetComponent<SoulStone>().soulSkillNumber];
        }
        if(item==null)
        {
            sdStr = "선택된 영혼석이 없어요!";
        }
        //sdStr = "이것은 아무 영혼석이나 클릭해도 뜨는 임시 설명이에요!";
        if (equipCount > 1)
        {
            equipCount = 0;
            soulUpMg.GetComponent<SoulUpGrade>().ValueChang.SetActive(false);
            sel.transform.parent = jewelMg.transform;
            sel.transform.localPosition = selPos;
            sdStr = "선택된 영혼석이 없어요!";
        }
        jewelMg.releaseBtn = gameObject;
        sdL.text = sdStr;
        soulUpMg.GetComponent<SoulUpGrade>().equipSlot = gameObject;
        soulUpMg.GetComponent<SoulUpGrade>().targetSlot = null;
        if(soulUpMg.GetComponent<SoulUpGrade>().equipSlot!=null&&item!=null)
        {
            soulUpMg.GetComponent<SoulUpGrade>().ValueChang.SetActive(true);
            soulUpMg.GetComponent<SoulUpGrade>().soulValue.text = MoneyManager.inStance.stoneReinFoecValue[item.GetComponent<SoulStone>().soulSkillNumber].ToString();
            if (SoulSkillManager.INSTANCE.stoneReinforce[item.GetComponent<SoulStone>().soulSkillNumber] >= 5)
            {
                soulUpMg.GetComponent<SoulUpGrade>().soulValue.text = " Max";
            }
        }
        if (item==null)
        {
            soulUpMg.GetComponent<SoulUpGrade>().ValueChang.SetActive(false);
        }
    }
}
