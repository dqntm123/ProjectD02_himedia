using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class StageManager : MonoBehaviour {

    private static StageManager _instance = null;
    public static StageManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(StageManager)) as StageManager;
            }
            return _instance;
        }
    }

    public int currentStageNum;
    public int[] status;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadedSataus();
    }

    void Update ()
    {

    }

    public void Back()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(1);
    }
    public void SaveSataus()
    {
        for (int i = 0; i < status.Length; i++)
        {
            PlayerPrefs.SetInt("StatusNum" + i, status[i]);
        }
    }
    public void LoadedSataus()
    {
        for (int i = 0; i < status.Length; i++)
        {
            status[i] = PlayerPrefs.GetInt("StatusNum" + i, status[i]);
        }
    }
}
