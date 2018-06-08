using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoulSkillManager : MonoBehaviour {

    private static SoulSkillManager _INSTANCE = null;
    public static SoulSkillManager INSTANCE
    {
        get
        {
            if (_INSTANCE == null)
            {
                _INSTANCE = FindObjectOfType(typeof(SoulSkillManager)) as SoulSkillManager;
            }
            return _INSTANCE;
        }
    }
    public List<int> soulskillNunber;
    public List<int> skillCostValue;
    public List<int> stoneReinforce;
    void Start ()
    {
        if (_INSTANCE == null)//_instance가 null일때
            _INSTANCE = this;//_instance를 해당 _instance 로 한다
        else if (_INSTANCE != this)//_instance 생성되있다면
            Destroy(gameObject);//중복으로 생성하지 않게한다
        DontDestroyOnLoad(gameObject);//파괴되지않게 유지한다
        for (int i = 0; i < 3; i++)
        {
            soulskillNunber.Add(-1);
            skillCostValue.Add(-1);
        }
        LoadedSoulStone();
    }
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.buildIndex==1)
        {

        }
    }

    public void SaveSoulStone()
    {
        //Debug.Log("저장");
        for (int i = 0; i < soulskillNunber.Count; i++)
        {
            PlayerPrefs.SetInt("SoulSkillNumber"+i, soulskillNunber[i]);
        }
        for (int i = 0; i < skillCostValue.Count; i++)
        {
            PlayerPrefs.SetInt("SoulCostValue" + i, skillCostValue[i]);
        }
        for (int i = 0; i < stoneReinforce.Count; i++)
        {
            PlayerPrefs.SetInt("StoneReinForces" + i,stoneReinforce[i]);
        }
    }

    public void LoadedSoulStone()
    {
        //Debug.Log("불러옴");
        for (int i = 0; i < soulskillNunber.Count; i++)
        {
            soulskillNunber[i] = PlayerPrefs.GetInt("SoulSkillNumber" + i, soulskillNunber[i]);
        }
        for (int i = 0; i < skillCostValue.Count; i++)
        {
            skillCostValue[i]= PlayerPrefs.GetInt("SoulCostValue" + i, skillCostValue[i]);
        }
        for (int i = 0; i < stoneReinforce.Count; i++)
        {
            stoneReinforce[i]=PlayerPrefs.GetInt("StoneReinForces" + i, stoneReinforce[i]);
        }
    }
}
