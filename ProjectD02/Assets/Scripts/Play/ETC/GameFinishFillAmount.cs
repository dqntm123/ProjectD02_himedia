using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishFillAmount : MonoBehaviour {


    public GameObject inForMationChang;
    public float finishChangFillAmoutTime;
    public  float finshCahangFillAmountResPawn;
    public GameObject stopWatch;
    public GameObject enemyMg;
    void Start ()
    {
        Time.timeScale = 1;
        stopWatch = GameObject.Find("StopWatch");
        enemyMg = GameObject.Find("EnemyManaer");
        enemyMg.SetActive(false);
        stopWatch.GetComponent<StopWatch>().gameFinish = true;
	}

    void Update()
    {
        finishChangFillAmoutTime += Time.deltaTime;
        if (finishChangFillAmoutTime >= finshCahangFillAmountResPawn)
        {
            finishChangFillAmoutTime = 0;
            gameObject.GetComponent<UISprite>().fillAmount += 0.05f;
            if (gameObject.GetComponent<UISprite>().fillAmount == 1)
            {
                inForMationChang.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
