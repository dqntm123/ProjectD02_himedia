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
    public int[] equipSoulNum = new int[3];
    void Awake()
    {
        //for (int i = 0; i < equipSoulNum.Length; i++)
        //{
        //    equipSoulNum[i] = -1;
        //}
        //LoadedEquipSoulNumber();
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
            item = null;
            soulIn = false;
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
            if (gameObject.transform.GetChild(0).name == "SoulStone" + ssi.IndexOf(ss))
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

    public void SaveEquipSoulNumber()
    {
        //PlayerPrefs.SetInt("Equip", equipSoulNum[myNum]);
        //PlayerPrefs.SetInt("EquipSloT1", equipSoulNum[0]);
        //PlayerPrefs.SetInt("EquipSloT2", equipSoulNum[1]);
        //PlayerPrefs.SetInt("EquipSloT3", equipSoulNum[2]);
    }
    public void LoadedEquipSoulNumber()
    {
         //equipSoulNum[myNum]=PlayerPrefs.GetInt("Equip", equipSoulNum[myNum]);
        //equipSoulNum[0] = PlayerPrefs.GetInt("EquipSloT1", equipSoulNum[0]);
        //equipSoulNum[1] = PlayerPrefs.GetInt("EquipSloT2", equipSoulNum[1]);
        //equipSoulNum[2] = PlayerPrefs.GetInt("EquipSloT3", equipSoulNum[2]);
    }
}
