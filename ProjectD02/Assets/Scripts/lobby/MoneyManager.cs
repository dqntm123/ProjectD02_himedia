using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour {

    public float goldCount;
    public float soulCount;
    public float[] reinFoceValue;
    //public float reinFoecUpValue;
    public GameObject goldLabel;
    public GameObject soulLabel;
    private static MoneyManager _inStance = null;
    public static MoneyManager inStance
    {
        get
        {
            if (_inStance == null)
            {
                _inStance = FindObjectOfType(typeof(MoneyManager)) as MoneyManager;
            }
            return _inStance;
        }
    }

    void Awake ()
    {
        if (_inStance == null)
            _inStance = this;
        else if (_inStance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
       LoadedMoney();
    }
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.buildIndex==1)
        {
            goldLabel = GameObject.Find("GoldLabel");
            soulLabel = GameObject.Find("SoulLabel");
            goldLabel.GetComponent<UILabel>().text = FoMatCount(goldCount);
            soulLabel.GetComponent<UILabel>().text = FoMatCount(soulCount);
        }
        SaveMoney();
    }
    public void SaveMoney()
    {
        PlayerPrefs.SetFloat("Gold", goldCount);
        PlayerPrefs.SetFloat("Soul", soulCount);
        PlayerPrefs.SetFloat("ReinForceValue1", reinFoceValue[0]);
        PlayerPrefs.SetFloat("ReinForceValue2", reinFoceValue[1]);
        PlayerPrefs.SetFloat("ReinForceValue3", reinFoceValue[2]);
        PlayerPrefs.SetFloat("ReinForceValue4", reinFoceValue[3]);
        PlayerPrefs.SetFloat("ReinForceValue5", reinFoceValue[4]);
        PlayerPrefs.SetFloat("ReinForceValue6", reinFoceValue[5]);
        PlayerPrefs.SetFloat("ReinForceValue7", reinFoceValue[6]);
        PlayerPrefs.SetFloat("ReinForceValue8", reinFoceValue[7]);
        PlayerPrefs.SetFloat("ReinForceValue9", reinFoceValue[8]);
    }
    public void LoadedMoney()
    {
        goldCount = PlayerPrefs.GetFloat("Gold", goldCount);
        soulCount = PlayerPrefs.GetFloat("Soul", soulCount);
        reinFoceValue[0] = PlayerPrefs.GetFloat("ReinForceValue1", reinFoceValue[0]);
        reinFoceValue[1] = PlayerPrefs.GetFloat("ReinForceValue2", reinFoceValue[1]);
        reinFoceValue[2] = PlayerPrefs.GetFloat("ReinForceValue3", reinFoceValue[2]);
        reinFoceValue[3] = PlayerPrefs.GetFloat("ReinForceValue4", reinFoceValue[3]);
        reinFoceValue[4] = PlayerPrefs.GetFloat("ReinForceValue5", reinFoceValue[4]);
        reinFoceValue[5] = PlayerPrefs.GetFloat("ReinForceValue6", reinFoceValue[5]);
        reinFoceValue[6] = PlayerPrefs.GetFloat("ReinForceValue7", reinFoceValue[6]);
        reinFoceValue[7] = PlayerPrefs.GetFloat("ReinForceValue8", reinFoceValue[7]);
        reinFoceValue[8] = PlayerPrefs.GetFloat("ReinForceValue9", reinFoceValue[8]);
    }
    public string FoMatCount(float data)//숫자단위마다 ','을 찍어주는 함수
    {
        return string.Format("{0:#,###0}", data);
    }

    public void AssaGoldDeuck()
    {
        goldCount = PlayerPrefs.GetFloat("Gold", goldCount);
        goldCount += 100;
        PlayerPrefs.SetFloat("Gold", goldCount);
    }

    public void AssaSoulDeuck()
    {
        soulCount = PlayerPrefs.GetFloat("Soul", soulCount);
        soulCount += 10;
        PlayerPrefs.SetFloat("Soul", soulCount);
    }
}
