using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour {

    public int goldCount;
    public int soulCount;
    public int getGold;
    public int getSoul;
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
        PlayerPrefs.SetFloat("GoldValue", goldCount);
        PlayerPrefs.SetFloat("SoulValue", soulCount);
        for (int i = 0; i < unitReinFoceValue.Length; i++)
        {
            PlayerPrefs.SetInt("UnitReinForce" + i, unitReinFoceValue[i]);
        }
        for (int i = 0; i < stoneReinFoecValue.Length; i++)
        {
            PlayerPrefs.SetInt("StoneReinForceValues" + i, stoneReinFoecValue[i]);
        }
    }
    public void LoadedMoney()
    {
        goldCount = PlayerPrefs.GetInt("GoldValue", goldCount);
        soulCount = PlayerPrefs.GetInt("SoulValue", soulCount);
        for (int i = 0; i < unitReinFoceValue.Length; i++)
        {
            unitReinFoceValue[i]=PlayerPrefs.GetInt("UnitReinForce" + i, unitReinFoceValue[i]);
        }
        for (int i = 0; i < stoneReinFoecValue.Length; i++)
        {
            stoneReinFoecValue[i]=PlayerPrefs.GetInt("StoneReinForceValues" + i, stoneReinFoecValue[i]);
        }
    }
    public string FoMatCount(int data)//숫자단위마다 ','을 찍어주는 함수
    {
        return string.Format("{0:#,###0}", data);
    }

    public void AssaGoldDeuck()
    {
        goldCount = PlayerPrefs.GetInt("Gold", goldCount);
        int goldDeuck = 100;
        getGold += goldDeuck;
        goldCount += goldDeuck;
        PlayerPrefs.SetFloat("Gold", goldCount);
    }

    public void AssaSoulDeuck()
    {
        soulCount = PlayerPrefs.GetInt("Soul", soulCount);
        int souldeuck = 10;
        getSoul += souldeuck;
        soulCount += souldeuck;
        PlayerPrefs.SetFloat("Soul", soulCount);
    }
}
