using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelBtn : MonoBehaviour {

    public JewelBtnManager jewelManager;
    public GameObject soulItem;
    public GameObject select;
    public GameObject soulupmg;
    public Vector3 selectPos;
    public bool stoneIn = false;
    public int clickCount;
    public int myNumber;
    public UILabel sdL;         //stone detail label
    public string sdStr;        //stone detail string
    public List<GameObject> ssi;        //jewelBtnManager - soul stone item
    public List<string> stoneDetails;
    public int lV;

    void Awake()
    {
        jewelManager = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        select = GameObject.Find("Selector");
        selectPos = select.transform.localPosition;
        stoneDetails = GameObject.Find("SoulStoneDetailList").GetComponent<SoulStoneDetailList>().stoneDetailStr;
        soulupmg = GameObject.Find("UpgradeManager");
    }

    void Start()
    {
       //if(soulItem!=null)
       // {
       //     soulItem.GetComponent<SoulStone>().lvLabel[soulItem.GetComponent<SoulStone>().soulSkillNumber].text = SoulSkillManager.INSTANCE.stoneReinforce[soulItem.GetComponent<SoulStone>().soulSkillNumber].ToString();
       //     if(SoulSkillManager.INSTANCE.stoneReinforce[soulItem.GetComponent<SoulStone>().soulSkillNumber]==5)
       //     {
       //         soulItem.GetComponent<SoulStone>().lvLabel[soulItem.GetComponent<SoulStone>().soulSkillNumber].text = "Max";
       //     }
       // }
    }

    void Update ()
    {
        if (select.transform.parent != gameObject.transform)
        {
            clickCount = 0;
        }
        if (soulItem!=null&&soulItem.transform.parent != gameObject.transform)
        {
            soulItem = null;
            stoneIn = false;
            //jewelManager.jewelslotNum[myNumber] = -1;
        }
        ssi = jewelManager.soulStoneItem;
    }

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        jewelManager.equipBtn[0].SetActive(true);
        jewelManager.equipBtn[1].SetActive(false);
        select.transform.parent = gameObject.transform;
        select.transform.position = gameObject.transform.position;
        clickCount += 1;
        foreach (GameObject ss in ssi)
        {
            if (gameObject.transform.GetChild(0).name == "SoulStone" + ssi.IndexOf(ss) )
                //gameObject.transform.GetChild(1).name == "SoulStone" + ssi.IndexOf(ss))
            {
                sdStr = stoneDetails[ssi.IndexOf(ss)];
            }           
        }
        //sdStr = "이것은 아무 영혼석이나 클릭해도 뜨는 임시 설명이에요!";
        if (clickCount > 1 )
        {
            clickCount = 0;
            soulupmg.GetComponent<SoulUpGrade>().ValueChang.SetActive(false);
            select.transform.parent = jewelManager.transform;
            select.transform.localPosition = selectPos;
            if (gameObject.transform.childCount < 2)
            {
                sdStr = "선택된 영혼석이 없어요!";
            }
        }
        jewelManager.clickBtn = gameObject;       
        sdL.text = sdStr;
        soulupmg.GetComponent<SoulUpGrade>().targetSlot = gameObject;
        soulupmg.GetComponent<SoulUpGrade>().equipSlot = null;
        if (soulupmg.GetComponent<SoulUpGrade>().targetSlot != null && soulItem != null)
        {
            soulupmg.GetComponent<SoulUpGrade>().ValueChang.SetActive(true);
            soulupmg.GetComponent<SoulUpGrade>().soulValue.text = MoneyManager.inStance.stoneReinFoecValue[soulItem.GetComponent<SoulStone>().soulSkillNumber].ToString();
            if (SoulSkillManager.INSTANCE.stoneReinforce[soulItem.GetComponent<SoulStone>().soulSkillNumber] >= 5)
            {
                soulupmg.GetComponent<SoulUpGrade>().soulValue.text = " Max";
            }
        }
        if (soulItem == null)
        {
            soulupmg.GetComponent<SoulUpGrade>().ValueChang.SetActive(false);
        }
    }
}
