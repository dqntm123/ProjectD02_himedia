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
    void Start ()
    {
        if (_INSTANCE == null)//_instance가 null일때
            _INSTANCE = this;//_instance를 해당 _instance 로 한다
        else if (_INSTANCE != this)//_instance 생성되있다면
            Destroy(gameObject);//중복으로 생성하지 않게한다
        DontDestroyOnLoad(gameObject);//파괴되지않게 유지한다
    }
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.buildIndex==2)
        {

        }
    }
}
