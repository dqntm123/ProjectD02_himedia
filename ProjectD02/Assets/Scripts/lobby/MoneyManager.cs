using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour {

    public int goldCount;
    public int soulCount;
    //public float getGold;
    //public float getSoul;
    public int[] unitReinFoceValue;
    public int[] stoneReinFoecValue;
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
        for (int i = 0; i < unitReinFoceValue.Length; i++)
        {
            PlayerPrefs.SetInt("UnitReinForceValue" + i, unitReinFoceValue[i]);
        }
        for (int i = 0; i < stoneReinFoecValue.Length; i++)
        {
            PlayerPrefs.SetInt("StoneReinForceValue" + i, stoneReinFoecValue[i]);
        }
    }
    public void LoadedMoney()
    {
        goldCount = PlayerPrefs.GetInt("Gold", goldCount);
        soulCount = PlayerPrefs.GetInt("Soul", soulCount);
        for (int i = 0; i < unitReinFoceValue.Length; i++)
        {
            unitReinFoceValue[i]=PlayerPrefs.GetInt("UnitReinForceValue" + i, unitReinFoceValue[i]);
        }
        for (int i = 0; i < stoneReinFoecValue.Length; i++)
        {
            stoneReinFoecValue[i]=PlayerPrefs.GetInt("StoneReinForceValue" + i, stoneReinFoecValue[i]);
        }
    }
    public string FoMatCount(int data)//숫자단위마다 ','을 찍어주는 함수
    {
        return string.Format("{0:#,###0}", data);
    }

    public void AssaGoldDeuck()
    {
        goldCount = PlayerPrefs.GetInt("Gold", goldCount);
        goldCount += 100;
        PlayerPrefs.SetFloat("Gold", goldCount);
    }

    public void AssaSoulDeuck()
    {
        soulCount = PlayerPrefs.GetInt("Soul", soulCount);
        soulCount += 10;
        PlayerPrefs.SetFloat("Soul", soulCount);
    }
}
