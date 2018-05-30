using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour {

    public GameObject[] units;//유닛창
    public GameObject[] unitsEnable;//유닛비활성화창
    public GameObject beefMG;
    public float[] unitCost;//유닛코스트값
    public float[] unitCool;//유닛 쿨타임
    public float[] unitResPawn;//유닛리스폰타임
    public UILabel[] costLabel;
    public bool[] unitEnable;//유닛쿨타임 bool값

    void Start ()
    {
        beefMG = GameObject.Find("BeefManager");//beefMG 오브젝트안에 "BeefManager"를 찾아서 넣는다
	}
	
	void Update ()
    {
       if(unitEnable[0]==true)//유닛쿨타임 배열0번 bool값이 트루라면
        {
            unitCool[0] += Time.deltaTime;
            if(unitCool[0]>=unitResPawn[0])
            {
                unitCool[0] = 0;
                unitsEnable[0].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[0].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[0] = 0;
                unitsEnable[0].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[0] = false;//유닛쿨타임 배열0번의 bool값을 false로 바꿔주고
                unitsEnable[0].SetActive(false);//유닛비활성화 배열0번의 오브젝트를 끈다
            }
        }
        if (unitEnable[1] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[1] += Time.deltaTime;
            if (unitCool[1] >= unitResPawn[1])
            {
                unitCool[1] = 0;
                unitsEnable[1].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[1].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[1] = 0;
                unitsEnable[1].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[1] = false;//유닛쿨타임 해당배열값 bool값을 false로 바꿔주고
                unitsEnable[1].SetActive(false);//유닛비활성화 해당배열값 오브젝트를 끈다
            }
        }
        if (unitEnable[2] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[2] += Time.deltaTime;
            if (unitCool[2] >= unitResPawn[2])
            {
                unitCool[2] = 0;
                unitsEnable[2].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[2].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[2] = 0;
                unitsEnable[2].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[2] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[2].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
            }
        }
    }

    public void Unit1()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[0])//gaugeMG 오브젝트의 스크립트의 변수 비프카운터가 유닛코스트 배열0번 값보다 커지거나 같아진다면
        {
            units[0].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[0];
            unitEnable[0] = true;//유닛쿨타임 배열0번의 bool값을 트루로바꾼다
            unitsEnable[0].SetActive(true);//유닛비활성화창 배열0번의 오브젝트를 켠다
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[0];//변수 비프카운터 값에 유닛코스트배열0번의 값을 뺀다
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[0] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            //units[0].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;//units 배열 0번의 오브젝트의 enemystate를 MOVE로 바꿔준다
            Instantiate(units[0], transform.position, transform.rotation);//units의 배열0번의 오브젝트 생성   
        }
    }
    public void Unit2()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[1])
        {
            unitEnable[1] = true;
            unitsEnable[1].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[1];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[1] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[1].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[1], transform.position, transform.rotation);
        }
    }
    public void Unit3()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[2])
        {
            unitEnable[2] = true;
            unitsEnable[2].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[2];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[2] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[2].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[2], transform.position, transform.rotation);
        }
    }
}
