using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotBtn : MonoBehaviour {

    public JewelBtnManager jewelMg;
    public GameObject item;
    public bool soulIn = false;
    public int equipCount;
    public int myNum;
    public GameObject sel;
    public Vector3 selPos;
    public UILabel sdL;         //stone detail label
    public string sdStr;        //stone detail string
    public List<GameObject> ssi;        //jewelBtnManager - soul stone item 
    public List<string> stoneDetails;
    void Awake()
    {
        jewelMg = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        sel = GameObject.Find("Selector");
        selPos = sel.transform.localPosition;
        stoneDetails = GameObject.Find("SoulStoneDetailList").GetComponent<SoulStoneDetailList>().stoneDetailStr;
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
        ssi = jewelMg.soulStoneItem;
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
        foreach (GameObject ss in ssi)
        {
            if (gameObject.transform.GetChild(0).name == "SoulStone" + ssi.IndexOf(ss) ||
                gameObject.transform.GetChild(1).name == "SoulStone" + ssi.IndexOf(ss))
            {
                sdStr = stoneDetails[ssi.IndexOf(ss)];
            }
        }
        //sdStr = "이것은 아무 영혼석이나 클릭해도 뜨는 임시 설명이에요!";
        if (equipCount > 1)
        {
            equipCount = 0;
            sel.transform.parent = jewelMg.transform;
            sel.transform.localPosition = selPos;
            if (gameObject.transform.childCount < 2)
            {
                sdStr = "선택된 영혼석이 없어요!";
            }
        }
        //if (equipCount==0)
        //{
        //    sdStr = "선택된 영혼석이 없어요!";
        //}
        jewelMg.releaseBtn = gameObject;
        sdL.text = sdStr;
    }
}
