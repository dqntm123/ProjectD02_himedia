using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour {

    public UILabel manaText;
    public GameObject manaGauge;
    public float manaTime;
    public float manaRespawnTime;
    public float manaCount;
    public float manaMax;
    public bool manaOn = true;

    void Start ()
    {

    }
	
	void Update ()
    {
        manaText.text = manaCount.ToString() + "/" + manaMax.ToString();
        if (manaOn == true)//마나온이 트루라면
        {
            manaTime += Time.deltaTime;//마나타임에 계속 초단위시간을 더해줘라
            if (manaTime >= manaRespawnTime)//마나타임이 마나리스폰 타임보다 커지거나 같아진다면
            {
                manaTime = 0;//마나타임은 0으로 되돌리고
                manaCount += 1;//마나카운트에 +1을 해준다
                manaGauge.transform.localScale += new Vector3(1 / manaMax * 360, 0, 0);
            }
        }
        if(manaCount<=0)
        {
            manaCount = 0;
            manaGauge.transform.localScale += new Vector3(0, 0, 0);
        }
        if (manaCount >= manaMax)//마나카운트와 마나맥스의 값이 커지거나 같아진다면
        {
            manaOn = false;//마나온은 폴스로 바꾼다
        }
        else//마나카운트와 마나맥스의 값이 커지거나 같아지지 않는다면
        {
            manaOn = true;//마나온은 트루로 바꾼다
        }
    }
}
