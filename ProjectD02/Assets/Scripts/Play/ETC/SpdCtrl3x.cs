using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdCtrl3x : MonoBehaviour {

    public GameObject nextBtn;
    public Resume resume;

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        Time.timeScale = 1;
        resume.originalSpd = 1;
        nextBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
