using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private static LevelManager _instanCe = null;
    public static LevelManager instanCe
    {
        get
        {
            if (_instanCe == null)
            {
                _instanCe = FindObjectOfType(typeof(LevelManager)) as LevelManager;
            }
            return _instanCe;
        }
    }
    public int[] lv;
    void Start ()
    {
        if (_instanCe == null)
            _instanCe = this;
        else if (_instanCe != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
       LoadedLv();
	}
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.buildIndex==1)
        {
            SaveLv();
        }
    }
    public void SaveLv()
    {
        for (int i = 0; i < lv.Length; i++)
        {
            PlayerPrefs.SetInt("UNITLEVEL0" + i, lv[i]);
        }
    }
    public void LoadedLv()
    {
        for (int i = 0; i < lv.Length; i++)
        {
            lv[i]=PlayerPrefs.GetInt("UNITLEVEL0" + i, lv[i]);
        }
    }
}
