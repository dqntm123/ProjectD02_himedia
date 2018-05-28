using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using MiniJSON;

public class MinionManager : MonoBehaviour {

    private static MinionManager _insTance = null;
    public static MinionManager insTacne
    {
        get
        {
            if (_insTance == null)
            {
                _insTance = FindObjectOfType(typeof(MinionManager)) as MinionManager;
            }
            return _insTance;
        }
    }

    public float Atk;//공격력
    public float Hp;//체력
    public float DPS;
    public float speed;//움직임스피드

     void Awake()
    {
        if (_insTance == null)
            _insTance = this;
        else if (_insTance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        LoadedReinForce();
	}
	
	void Update ()
    {
        SaveReinForce();
    }

   public void LvUp()
    {
        Atk += 10;
        Debug.Log(Atk);
    }
    public void SaveReinForce()
    {
        PlayerPrefs.SetFloat("ATK", Atk);
        PlayerPrefs.SetFloat("HP", Hp);
        PlayerPrefs.SetFloat("Speed", speed);
    }
    public void LoadedReinForce()
    {
        Atk= PlayerPrefs.GetFloat("ATK", Atk);
        Hp = PlayerPrefs.GetFloat("HP", Hp);
        speed = PlayerPrefs.GetFloat("Speed", speed);
    }
}
