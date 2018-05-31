using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class BtnManager : MonoBehaviour {

    public GameObject[] btns;
    public GameObject selector;
    public GameObject[] windows;
    public GameObject bgmMg;
    public GameObject jewelMg;
    public UpDownBtn udbtn;
    
    private void Start()
    {
        MinionBtn();
        udbtn = GameObject.Find("BtnManager").GetComponent<UpDownBtn>();
        jewelMg = GameObject.Find("JewelBtnManager");
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i] = GameObject.Find("Btn" + i);
            btns[i].AddComponent<Btn>();
        }
        for (int i = 0; i < udbtn.rfuILabel.Length; i++)
        {
            if (LevelManager.instanCe.lv[i] == 10)
            {
                udbtn.rfuILabel[i].text = "LV " + "Max";
            }
            else if(LevelManager.instanCe.lv[i]==0)
            {
                udbtn.rfuILabel[i].text = "LOCK";
                udbtn.rfuILabel[i].color = Color.red;
            }
            else if (LevelManager.instanCe.lv[i] != 10)
            {
                udbtn.rfuILabel[i].text = Convert.ToString("LV " + LevelManager.instanCe.lv[i]);
            }
        }
    }
    void Update()
    {
        bgmMg = GameObject.Find("BGMManager");
    }

    public void MinionBtn()
    {
        windows[0].SetActive(true);
        windows[1].SetActive(false);
        //windows[2].SetActive(false);
    }

    public void WeaponBtn()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(true);
        //windows[2].SetActive(false);
    }

    //public void ShopBtn()
    //{
    //    windows[0].SetActive(false);
    //    windows[1].SetActive(false);
    //    windows[2].SetActive(true);
    //}

    public void WolrdBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(2);
    }

    public void LobbyBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(1);
        bgmMg.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[1];
        MusicManager.instance.auDios.Play();
    }
    public void IntroBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(0);
        bgmMg.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[0];
        MusicManager.instance.auDios.Play();
    }
}
