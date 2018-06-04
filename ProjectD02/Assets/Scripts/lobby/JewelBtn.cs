using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelBtn : MonoBehaviour {

    public JewelBtnManager jewelManager;
    public GameObject soulItem;
    public GameObject select;
    public Vector3 selectPos;
    public bool stoneIn = false;
    public int clickCount;
    public int myNumber;
    public UILabel sdL;         //stone detail label
    public string sdStr;        //stone detail string
    public List<GameObject> ssi;        //jewelBtnManager - soul stone item
    public List<string> stoneDetails;
    public int[] slotSoulNum = new int[11];
    void Awake()
    {
        //for (int i = 0; i < slotSoulNum.Length; i++)
        //{
        //    slotSoulNum[i] = -1;
        //}
        jewelManager = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        select = GameObject.Find("Selector");
        selectPos = select.transform.localPosition;
        stoneDetails = GameObject.Find("SoulStoneDetailList").GetComponent<SoulStoneDetailList>().stoneDetailStr;
    }
	
	void Update ()
    {
        if (select.transform.parent != gameObject.transform)
        {
            clickCount = 0;
        }
        if (soulItem!=null&&soulItem.transform.parent != gameObject.transform)
        {
            stoneIn = false;
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
            if (gameObject.transform.GetChild(0).name == "SoulStone" + ssi.IndexOf(ss))
            {
                sdStr = stoneDetails[ssi.IndexOf(ss)];
            }           
        }
        //sdStr = "이것은 아무 영혼석이나 클릭해도 뜨는 임시 설명이에요!";
        if (clickCount > 1 )
        {
            clickCount = 0;
            select.transform.parent = jewelManager.transform;
            select.transform.localPosition = selectPos;
            if (gameObject.transform.childCount < 2)
            {
                sdStr = "선택된 영혼석이 없어요!";
            }
        }
        jewelManager.clickBtn = gameObject;       
        sdL.text = sdStr;
    }

    public void SaveSlotSoulNumber()
    {
        //for (int i = 0; i < slotSoulNum.Length; i++)
        //{
        //    PlayerPrefs.SetInt("SlotSoulNum000"+i,slotSoulNum[i]);
        //}
    }
    public void LoadedSlotSoulNumber()
    {
    //    for (int i = 0; i < slotSoulNum.Length; i++)
    //    {
    //        slotSoulNum[i] = PlayerPrefs.GetInt("SlotSoulNum000" + i, slotSoulNum[i]);
    //    }
    }
}
