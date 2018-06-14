using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    public GameObject pausePanel;
    public float originalSpd = 1;

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        Time.timeScale = originalSpd;
        pausePanel.SetActive(false);
    }
     void Start()
    {
        originalSpd = 1;
    }
}
