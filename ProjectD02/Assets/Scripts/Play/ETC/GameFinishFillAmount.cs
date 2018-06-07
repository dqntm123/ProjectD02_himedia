using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishFillAmount : MonoBehaviour {


    public GameObject[] inForMationChang;
    public bool[] finishChang;
    public float finishChangFillAmoutTime;
    public float finshCahangFillAmountResPawn;
    public GameObject stopWatch;

    void Awake()
    {

    }
    void Start ()
    {
        Time.timeScale = 1;
        stopWatch = GameObject.Find("StopWatch");
        stopWatch.GetComponent<StopWatch>().gameFinish = true;
	}

    void Update()
    {
        if(finishChang[0]==true)
        {
            finishChangFillAmoutTime += Time.deltaTime;
            if (finishChangFillAmoutTime >= finshCahangFillAmountResPawn)
            {
                finishChangFillAmoutTime = 0;
                gameObject.GetComponent<UISprite>().fillAmount += 0.05f;
                if (gameObject.GetComponent<UISprite>().fillAmount == 1)
                {
                    inForMationChang[0].SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
        if(finishChang[1]==true)
        {
            finishChangFillAmoutTime += Time.deltaTime;
            if (finishChangFillAmoutTime >= finshCahangFillAmountResPawn)
            {
                finishChangFillAmoutTime = 0;
                gameObject.GetComponent<UISprite>().fillAmount += 0.05f;
                if (gameObject.GetComponent<UISprite>().fillAmount == 1)
                {
                    inForMationChang[1].SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
