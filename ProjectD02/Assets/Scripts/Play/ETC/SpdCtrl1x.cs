using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdCtrl1x : MonoBehaviour {

    public GameObject nextBtn;
    public Resume resume;

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        Time.timeScale = 2;
        resume.originalSpd = 2;
        nextBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
