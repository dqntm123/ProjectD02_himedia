using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class getButtonIndex : MonoBehaviour {

    public ButtonManager bm;
    public UpDownBtn udb;
    public GameObject nameLabel;
    public int clickCt = 0;
    public bool reinForce = false;
    private void Start()
    {
        bm = GameObject.Find("BtnManager").GetComponent<ButtonManager>();
        udb = GameObject.Find("BtnManager").GetComponent<UpDownBtn>();
        nameLabel = GameObject.Find("MainLevel");
        nameLabel.GetComponent<UILabel>().text =bm.unitName[0];
    }

    void Update()
    {
        if (bm.target != gameObject)
        {
            clickCt = 0;
        }
    }

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        bm.selector.transform.position = gameObject.transform.position;     //선택 하이라이터를 이동
        clickCt = 1;
        bm.target = gameObject;     //누른 버튼을 타겟으로 지정
        for (int r= 0; r < MoneyManager.inStance.reinFoceValue.Length; r++)
        {
            if (bm.target == bm.buttons[r])
            {
                bm.anitarget = bm.unitIdle[r];
                //if(bm.anitarget==bm.unitIdle[r])
                //{
                //    bm.unitIdle[r].SetActive(true);
                //}
                bm.anitarget.transform.parent = bm.target.transform;
                bm.unitIdle[r].SetActive(true);
                udb.gdCostLB.GetComponent<UILabel>().text = MoneyManager.inStance.FoMatCount(MoneyManager.inStance.reinFoceValue[r]);
                nameLabel.GetComponent<UILabel>().text = bm.unitName[r];
                if (LevelManager.instanCe.lv[r] == 10)
                {
                    udb.gdCostLB.GetComponent<UILabel>().text = "Max";
                }
            }
        }
        //UILabel uILabel = gameObject.GetComponentInChildren<UILabel>();             
        //string str = uILabel.text;
        //LevelManager.instanCe.lv[0] = Convert.ToInt32(str);       //타겟의 자식개체의 라벨을 가져와 정수로 변환해 지정

        //udb.rfuILabel = bm.target.GetComponentInChildren<UILabel>();      //업다운버튼을 누를때 바꿀 라벨을 지정
    }
}
