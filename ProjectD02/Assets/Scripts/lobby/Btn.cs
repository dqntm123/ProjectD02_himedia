using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour {

    public GameObject target;
    public GameObject selector;

    void Start ()
    {
        selector = GameObject.Find("BigSelector");
    }
	
    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        selector.transform.position = gameObject.transform.position;
    }


}
