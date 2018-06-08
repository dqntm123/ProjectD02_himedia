using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusViewer : MonoBehaviour {

    public GameObject[] bu;
    public float[] atk;
    public float[] hp;
    public string[] range;
    public float[] b_Atk;
    public float[] b_Hp;
    public UILabel[] statValue;
    public string[] values;
    public int[] lv;
    public LevelManager lvm;
    public UILabel valuesView;


    public void Awake()
    {
        lvm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Start()
    {
        
        values[0] = "프리니 : 평범한 마계주민중 하니이며\r\n마계의 최하체로 자신을 보호하기 위해 귀여운 팽귄의 모습을 하고있습니다. \r\n 프리니는 두개의 검을 사용하여 공격합니다.";
        values[1] = "라임 : 흔히 보이는 슬라임종중 하나이며, 슬라임종중 가장 최하위종 공격력은 1.5프리니이다 \r\n 라임은 자신의 점액질을 뱉어서 공격합니다.";
        values[2] = "쿰 :  평범한 마계주민중 하나이며, 마계주민들끼리 이간질하기를 좋아합니다.  \r\n쿰은 강력한 둔기를 사용하여 공격합니다.";
        values[3] = "슬라임 : 흔히 보이는 슬라임종 중 가장 기본적인 종이며, 슬라임 개체중 라임과 최화위 개체순위를 다투며 공격력은 1.5프리니이다.  \r\n슬라임은 자신의 점액질의 탄력을 이용하여 공격합니다.";
        values[4] = "우드골렘 : 마계의 문지기이며 , 공격은 하지 못하나 우드골렘은 굉장히 단단합니다.  \r\n 우드골렘은 단단한 자신의 몸으로 공격을 막습니다.";
        values[5] = "펠린 : 마왕의 측군중 한명이며 , 수인족으로 강력한 신체능력을 보유하고 있습니다.  \r\n 펠린은 강력한 주먹모양의 마나를 날려 공격합니다.";
        values[6] = "버스터 : 마계의 흉악범중 한명이었으나, 마왕에게 잡힌뒤 회귀하여 마왕을 돕고 있습니다.  \r\n 버스터는 강력한 할퀴기를 사용하여 공격합니다.";
        values[7] = "서큐버스 : 마왕의 측군중 한명이며, 서큐버스는 마왕의 측군이지만 상당히 자유롭게 활동하며, 상대방을 자신에게 반하게 할 수 있습니다.  \r\n 서큐버스는 사역마를 사용하여 공격합니다.";
        values[8] = "가디언 : 마왕성의 경비병이며, , 가디언은 마왕에 의해 만들어진 인공생명체이며 마왕의 마나를 받아 강력하나 머리가 좋지 않습니다.  \r\n 가디언은 체내의 마나를 레이저 모양으로 뱉어 공격합니다.";


        for (int i = 0; i < bu.Length; i++)
        {

            lv[i] = lvm.GetComponent<LevelManager>().lv[i];

            atk[i] += b_Atk[i] * lv[i] * 0.1f;
            hp[i] += b_Hp[i] * lv[i] * 0.1f;

           
        }

    }
	
	void Update ()
    {

        for (int i = 0; i < bu.Length; i++)
        {
            lv[i] = lvm.GetComponent<LevelManager>().lv[i];

            if (bu[i].GetComponent<getButtonIndex>().clickCt == 1)
            {
                statValue[0].text = "생명력 : " + hp[i];
                statValue[1].text = "공격력 : " + atk[i];
                statValue[2].text = "사거리 : " + range[i];
                valuesView.text = values[i];
                
            }
        }

        //for (int i = 0; i < lvm.GetComponent<LevelManager>().lv.Length; i++)
        //{
        //    if (lvm.GetComponent<LevelManager>().lv[i] == 0)
        //    {
        //        statValue[0].text = "생명력 : " + "???";
        //        statValue[1].text = "공격력 : " + "???";
        //        statValue[2].text = "사거리 : " + "???";
        //        valuesView.text = "???";
        //    }

        //}


    }

    

    public void Gesan()
    {
        for (int i = 0; i < bu.Length; i++)
        {
            if (bu[i].GetComponent<getButtonIndex>().clickCt == 1)
            {
                atk[i] = 0;
                hp[i] = 0; 

                lv[i] = lvm.GetComponent<LevelManager>().lv[i];
                atk[i] = b_Atk[i] * lv[i] * 0.1f+b_Atk[i];
                hp[i] = b_Hp[i] * lv[i] * 0.1f+ b_Hp[i];
                //Debug.Log(atk[i]);
                //Debug.Log(b_Atk[i]);
                //Debug.Log(lv[i]);
                //Debug.Log(atk[i] = b_Atk[i] * lv[i] * 0.1f+b_Atk[i]);
            }
        }
    }

   
}
