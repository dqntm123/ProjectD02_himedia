using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour {

    public GameObject[] units;//유닛창
    public GameObject[] unitsEnable;//유닛비활성화창
    public GameObject beefMG;
    public GameObject[] unitBtn;
    public float[] unitCost;//유닛코스트값
    public float[] unitCool;//유닛 쿨타임
    public float[] unitResPawn;//유닛리스폰타임
    public bool[] unitEnable;//유닛쿨타임 bool값

    void Start ()
    {
        beefMG = GameObject.Find("BeefManager");//beefMG 오브젝트안에 "BeefManager"를 찾아서 넣는다
        for (int i = 0; i < unitBtn.Length; i++)
        {
            unitBtn[i] = GameObject.Find("UnitSlot"+i);
            if (LevelManager.instanCe.lv[i]>0)
            {
                unitBtn[i].SetActive(true);
            }
            else if(LevelManager.instanCe.lv[i] ==0)
            {
                unitBtn[i].SetActive(false);
            }
        }

	}
	
	void Update ()
    {
       if(unitEnable[0]==true)//유닛쿨타임 배열0번 bool값이 트루라면
        {
            unitCool[0] += Time.deltaTime;
            if(unitCool[0]>=unitResPawn[0]) //0.1초당 2초
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
        if (unitEnable[3] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[3] += Time.deltaTime;
            if (unitCool[3] >= unitResPawn[3])
            {
                unitCool[3] = 0;
                unitsEnable[3].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[3].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[3] = 0;
                unitsEnable[3].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[3] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[3].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
            }
        }

        if (unitEnable[4] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[4] += Time.deltaTime;
            if (unitCool[4] >= unitResPawn[4])
            {
                unitCool[4] = 0;
                unitsEnable[4].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[4].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[4] = 0;
                unitsEnable[4].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[4] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[4].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
            }
        }

        if (unitEnable[5] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[5] += Time.deltaTime;
            if (unitCool[5] >= unitResPawn[2])
            {
                unitCool[5] = 0;
                unitsEnable[5].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[5].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[5] = 0;
                unitsEnable[5].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[5] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[5].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
            }
        }

        if (unitEnable[6] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[6] += Time.deltaTime;
            if (unitCool[6] >= unitResPawn[2])
            {
                unitCool[6] = 0;
                unitsEnable[6].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[6].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[6] = 0;
                unitsEnable[6].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[6] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[6].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
            }
        }

        if (unitEnable[7] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[7] += Time.deltaTime;
            if (unitCool[7] >= unitResPawn[7])
            {
                unitCool[7] = 0;
                unitsEnable[7].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[7].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[7] = 0;
                unitsEnable[7].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[7] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[7].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
            }
        }

        if (unitEnable[8] == true)//유닛쿨타임 해당배열값 bool값이 트루라면
        {
            unitCool[8] += Time.deltaTime;
            if (unitCool[8] >= unitResPawn[7])
            {
                unitCool[8] = 0;
                unitsEnable[8].GetComponent<UISprite>().fillAmount -= 0.05f;//유닛 비활성화 창의 fillAmount값에 0.05을빼준다
            }
            if (unitsEnable[8].GetComponent<UISprite>().fillAmount <= 0)//유닛비활성화창의 fiilAmount값이 0보다 작아지거나 같아진다면 
            {
                unitCool[8] = 0;
                unitsEnable[8].GetComponent<UISprite>().fillAmount = 1;//유닛비활성화창의 fiilAmount값을 1로 바꿔준다
                unitEnable[8] = false;//유닛쿨타임 해당배열값의 bool값을 false로 바꿔주고
                unitsEnable[8].SetActive(false);//유닛비활성화 해당배열값의 오브젝트를 끈다
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
            units[1].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[1];
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
            units[2].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[2];
            unitEnable[2] = true;
            unitsEnable[2].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[2];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[2] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[2].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[2], transform.position, transform.rotation);
        }
    }

    public void Unit4()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[3])
        {
            units[3].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[3];
            unitEnable[3] = true;
            unitsEnable[3].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[3];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[3] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[3].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[3], transform.position, transform.rotation);
        }
    }

    public void Unit5()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[4])
        {
            units[4].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[4];
            unitEnable[4] = true;
            unitsEnable[4].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[4];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[4] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[4].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[4], transform.position, transform.rotation);
        }
    }

    public void Unit6()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[5])
        {
            units[5].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[5];
            unitEnable[5] = true;
            unitsEnable[5].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[2];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[5] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[5].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[5], transform.position, transform.rotation);
        }
    }

    public void Unit7()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[6])
        {
            units[6].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[6];
            unitEnable[6] = true;
            unitsEnable[6].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[6];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[6] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[6].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[6], transform.position, transform.rotation);
        }
    }
    public void Unit8()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[7])
        {
            units[7].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[7];
            unitEnable[7] = true;
            unitsEnable[7].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[7];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[7] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[7].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[7], transform.position, transform.rotation);
        }
    }
    public void Unit9()
    {
        if (beefMG.GetComponent<BeefManager>().beefCount >= unitCost[8])
        {
            units[8].GetComponent<UnitController>().lv = LevelManager.instanCe.lv[8];
            unitEnable[8] = true;
            unitsEnable[8].SetActive(true);
            beefMG.GetComponent<BeefManager>().beefCount -= unitCost[8];
            beefMG.GetComponent<BeefManager>().beefGauge.transform.localScale -= new Vector3(unitCost[8] / beefMG.GetComponent<BeefManager>().beefMax * 360, 0, 0);
            units[8].GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.MOVE;
            Instantiate(units[8], transform.position, transform.rotation);
        }
    }
}
