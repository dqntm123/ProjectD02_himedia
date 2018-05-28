using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionController : MonoBehaviour {

    public GameObject bgmMG;
    public GameObject effectMg;
    public MusicManager muMg;
    public EffectSoundManager efMg;

	void Start ()
    {
        bgmMG = GameObject.Find("BGMManager");
        effectMg= GameObject.Find("EffectManager");
        muMg = bgmMG.GetComponent<MusicManager>();
        efMg = effectMg.GetComponent<EffectSoundManager>();
        UIButton bguib = gameObject.AddComponent<UIButton>();
        if(bguib.gameObject.name== "BgmPlus")
        {
            bguib.tweenTarget = GameObject.Find("BgmPlus");
            EventDelegate.Set(bguib.onClick, muMg.BgmPlus);
        }
        if (bguib.gameObject.name == "BgmMinus")
        {
            bguib.tweenTarget = GameObject.Find("BgmMinus");
            EventDelegate.Set(bguib.onClick, muMg.BgmMinus);
        }
        if (bguib.gameObject.name == "EffectPlus")
        {
            bguib.tweenTarget = GameObject.Find("EffectPlus");
            EventDelegate.Set(bguib.onClick,efMg.EffectPlus);
        }
        if (bguib.gameObject.name == "EffectMinus")
        {
            bguib.tweenTarget = GameObject.Find("EffectMinus");
            EventDelegate.Set(bguib.onClick, efMg.EffectMinus);
        }
    }
}
