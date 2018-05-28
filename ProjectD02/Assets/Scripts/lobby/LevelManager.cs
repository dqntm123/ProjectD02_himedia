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
        SaveLv();
    }
    public void SaveLv()
    {
        PlayerPrefs.SetInt("UnitLevel1", lv[0]);
        PlayerPrefs.SetInt("UnitLevel2", lv[1]);
        PlayerPrefs.SetInt("UnitLevel3", lv[2]);
        PlayerPrefs.SetInt("UnitLevel4", lv[3]);
        PlayerPrefs.SetInt("UnitLevel5", lv[4]);
        PlayerPrefs.SetInt("UnitLevel6", lv[5]);
        PlayerPrefs.SetInt("UnitLevel7", lv[6]);
        PlayerPrefs.SetInt("UnitLevel8", lv[7]);
        PlayerPrefs.SetInt("UnitLevel9", lv[8]);
    }
    public void LoadedLv()
    {
        lv[0] = PlayerPrefs.GetInt("UnitLevel1", lv[0]);
        lv[1] = PlayerPrefs.GetInt("UnitLevel2", lv[1]);
        lv[2] = PlayerPrefs.GetInt("UnitLevel3", lv[2]);
        lv[3] = PlayerPrefs.GetInt("UnitLevel4", lv[3]);
        lv[4] = PlayerPrefs.GetInt("UnitLevel5", lv[4]);
        lv[5] = PlayerPrefs.GetInt("UnitLevel6", lv[5]);
        lv[6] = PlayerPrefs.GetInt("UnitLevel7", lv[6]);
        lv[7] = PlayerPrefs.GetInt("UnitLevel8", lv[7]);
        lv[8] = PlayerPrefs.GetInt("UnitLevel9", lv[8]);
    }
}
