using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class UnitLock : MonoBehaviour {

    public int[] lockValue;
    public int buyValue;
    public int unitCount;
    public GameObject select;
    public Vector3 selPos;
    public ButtonManager bmg;
    public UpDownBtn udbt;
    public UILabel unitCost;
    public UILabel unitLv;
    public UILabel goldValue;
    public GameObject[] needGold;
    public GameObject target;
    public GameObject udBtn;
	void Start ()
    {
        select = GameObject.Find("Sel");
        selPos = select.transform.localPosition;
        bmg = GameObject.Find("BtnManager").GetComponent<ButtonManager>();
        udbt = GameObject.Find("BtnManager").GetComponent<UpDownBtn>();
        udBtn = GameObject.Find("UpgradeBtn");
    }
	
	void Update ()
    {
       if(LevelManager.instanCe.lv[unitCount]==0)
        {
            gameObject.SetActive(true);
        }
       else if(LevelManager.instanCe.lv[unitCount] >= 0)
        {
            gameObject.SetActive(false);
            unitCost.gameObject.SetActive(true);
        }
	}
    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        for (int i = 0; i < bmg.unitIdle.Count; i++)
        {
            bmg.unitIdle[i].SetActive(false);
        }
        target = gameObject;
        select.transform.position = target.transform.position;
        select.transform.parent = target.transform;
        needGold[0].SetActive(false);
        needGold[1].SetActive(true);
        goldValue.text =" " +buyValue.ToString();
        needGold[1].GetComponent<UIButton>().onClick = new List<EventDelegate>();
        needGold[1].GetComponent<UIButton>().onClick.Add(new EventDelegate(target.GetComponent<UnitLock>().BuyUnitBtn));
    }
    public void BuyUnitBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        target = gameObject;
        MoneyManager.inStance.goldCount -= buyValue;
        target.SetActive(false);
        unitCost.gameObject.SetActive(true);
        LevelManager.instanCe.lv[unitCount] += 1;
        unitLv.text = Convert.ToString("LV " + LevelManager.instanCe.lv[unitCount]);
        unitLv.color = Color.yellow;
        udbt.gdCostLB.GetComponent<UILabel>().text = MoneyManager.inStance.FoMatCount(MoneyManager.inStance.reinFoceValue[unitCount]);
        bmg.target=udbt.btmMg.buttons[unitCount];
        bmg.unitIdle[unitCount].SetActive(true);
        bmg.unitIdle[unitCount].transform.parent= udbt.btmMg.buttons[unitCount].transform;
        bmg.unitIdle[unitCount].GetComponent<AniTarget>().parentObj = udbt.btmMg.buttons[unitCount];
        udbt.btmMg.buttons[unitCount].GetComponent<getButtonIndex>().clickCt += 1;
        udbt.btmMg.buttons[unitCount].GetComponent<getButtonIndex>().nameLabel.GetComponent<UILabel>().text = bmg.unitName[unitCount];
        select.transform.parent = udbt.btmMg.buttons[unitCount].transform;
        if(udBtn.GetComponent<UIButton>().isEnabled==false)
        {
            select.transform.localPosition = selPos;
        }
        else if(udBtn.GetComponent<UIButton>().isEnabled == true)
        {
            select.transform.position = udbt.btmMg.buttons[unitCount].transform.position;
        }
        needGold[0].SetActive(true);
        needGold[1].SetActive(false);
    }
}
