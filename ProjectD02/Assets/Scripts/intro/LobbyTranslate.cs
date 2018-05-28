using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyTranslate : MonoBehaviour {

    public GameObject bgmMG;

    void Update()
    {
        bgmMG = GameObject.Find("BGMManager");
    }
    public void LobbyScene()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(1);
        bgmMG.GetComponent<AudioSource>().clip=MusicManager.instance.bgmClip[1];
        MusicManager.instance.auDios.Play();
    }
}
