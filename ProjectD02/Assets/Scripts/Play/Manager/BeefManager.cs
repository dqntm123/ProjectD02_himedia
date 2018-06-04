using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeefManager : MonoBehaviour {

    public UILabel beefText;
    public GameObject beefGauge;
    public float beefTime;
    public float beefRespawnTime;
    public float beefCount;
    public float beefMax;
    public bool beefOn = true;
    void Start()
    {
        
    }

    void Update()
    {
        beefText.text = beefCount.ToString() + "/" + beefMax.ToString();
        if (beefOn == true)//비프온이 트루라면
        {
            beefTime += Time.deltaTime;//비프타임에 계속 초단위시간을 더해줘라
            if (beefTime >= beefRespawnTime)//비프타임이 비프리스폰 타임보다 커지거나 같아진다면
            {
                beefTime = 0;//비프타임은 0으로 되돌리고
                beefCount += 1;//비프카운트에 +1을 해준다
                beefGauge.transform.localScale += new Vector3(1/beefMax*360,0,0);
            }
        }
        if(beefCount<=0)
        {
            beefCount = 0;
        }
        if(beefCount>=90)
        {
            beefCount = 90;
            beefGauge.transform.localScale = new Vector3(360, beefGauge.transform.localScale.y, transform.localScale.z);
        }
        if (beefCount >= beefMax)//비프카운트와 비프맥스의 값이 커지거나 같아진다면
        {
            beefOn = false;//비프온은 폴스로 바꾼다
        }
        else//비프카운트와 비프맥스의 값이 커지거나 같아지지 않는다면
        {
            beefOn = true;//비프온은 트루로 바꾼다
        }
    }
}
