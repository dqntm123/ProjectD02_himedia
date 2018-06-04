using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdCtrl2x : MonoBehaviour {

    public GameObject nextBtn;
    public Resume resume;

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        Time.timeScale = 3;
        resume.originalSpd = 3;
        nextBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
