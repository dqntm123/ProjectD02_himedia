using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class UpDownBtn : MonoBehaviour {

    public UILabel[] rfuILabel;//강화수치 라벨
    public ButtonManager btmMg;
    public GameObject gdCostLB;
    private void Start()
    {
        btmMg= GameObject.Find("BtnManager").GetComponent<ButtonManager>();
    }

    void Update()
    {

    }
    public void UpBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        for (int i = 0; i < LevelManager.instanCe.lv.Length; i++)
        {
            if (LevelManager.instanCe.lv[i] >= 10)
            {
                LevelManager.instanCe.lv[i] = 10;
                btmMg.buttons[i].GetComponent<getButtonIndex>().reinForce = true;
            }
            if (btmMg.target==btmMg.buttons[i])
            { 
                if (LevelManager.instanCe.lv[i] <= 10)
                {
                    if (MoneyManager.inStance.reinFoceValue[i] <= MoneyManager.inStance.goldCount && MoneyManager.inStance.goldCount >= 0)
                    //강화값이 MoneyManager 싱글톤의 골드값보다 작거나 같은경우와 MoneyManager 싱글톤 골드값이 0보다 크거나 같을경우 강화시킨다
                    {
                        if(btmMg.buttons[i].GetComponent<getButtonIndex>().reinForce==false)
                        {
                            MoneyManager.inStance.goldCount -= MoneyManager.inStance.reinFoceValue[i];
                            MoneyManager.inStance.reinFoceValue[i] *= 2;
                            LevelManager.instanCe.lv[i] += 1;
                        }
                        gdCostLB.GetComponent<UILabel>().text = MoneyManager.inStance.FoMatCount(MoneyManager.inStance.reinFoceValue[i]);
                        if (LevelManager.instanCe.lv[i] == 10)
                        {
                            gdCostLB.GetComponent<UILabel>().text = "Max";
                        }
                    }
                }
            }
            rfuILabel[i].text = Convert.ToString("LV " + LevelManager.instanCe.lv[i]);
            if (LevelManager.instanCe.lv[i] == 10)
            {
                rfuILabel[i].text = "LV " + "Max";
            }
            if (LevelManager.instanCe.lv[i] == 0)
            {
                rfuILabel[i].text = "LOCK";
                rfuILabel[i].color = Color.red;
            }
        }
    }
    public void ReinForceLabel()
    {

    }
}
