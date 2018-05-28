using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject optionWindow;

    public void OptionBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        optionWindow.SetActive(true);
    }

    public void OptionXBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        optionWindow.SetActive(false);
    }
}
