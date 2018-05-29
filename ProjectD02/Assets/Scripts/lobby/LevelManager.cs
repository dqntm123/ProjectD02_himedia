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
        //LoadedLv();
	}
	
	void Update ()
    {
        //SaveLv();
    }
    public void SaveLv()
    {
        PlayerPrefs.SetInt("UNITLevel01", lv[0]);
        PlayerPrefs.SetInt("UNITLevel02", lv[1]);
        PlayerPrefs.SetInt("UNITLevel03", lv[2]);
        PlayerPrefs.SetInt("UNITLevel04", lv[3]);
        PlayerPrefs.SetInt("UNITLevel05", lv[4]);
        PlayerPrefs.SetInt("UNITLevel06", lv[5]);
        PlayerPrefs.SetInt("UNITLevel07", lv[6]);
        PlayerPrefs.SetInt("UNITLevel08", lv[7]);
        PlayerPrefs.SetInt("UNITLevel09", lv[8]);
    }
    public void LoadedLv()
    {
        lv[0] = PlayerPrefs.GetInt("UNITLevel01", lv[0]);
        lv[1] = PlayerPrefs.GetInt("UNITLevel02", lv[1]);
        lv[2] = PlayerPrefs.GetInt("UNITLevel03", lv[2]);
        lv[3] = PlayerPrefs.GetInt("UNITLevel04", lv[3]);
        lv[4] = PlayerPrefs.GetInt("UNITLevel05", lv[4]);
        lv[5] = PlayerPrefs.GetInt("UNITLevel06", lv[5]);
        lv[6] = PlayerPrefs.GetInt("UNITLevel07", lv[6]);
        lv[7] = PlayerPrefs.GetInt("UNITLevel08", lv[7]);
        lv[8] = PlayerPrefs.GetInt("UNITLevel09", lv[8]);
    }
}
