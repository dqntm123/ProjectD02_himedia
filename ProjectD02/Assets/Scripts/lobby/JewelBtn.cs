using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelBtn : MonoBehaviour {

    public JewelBtnManager jewelManager;
    public GameObject soulItem;
    public GameObject select;
    public Vector3 selectPos;
    public bool stoneIn = false;
    public int clickCount;
	void Awake()
    {
        jewelManager = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        select = GameObject.Find("Selector");
        selectPos = select.transform.localPosition;
    }
	

	void Update ()
    {
        if (select.transform.parent != gameObject.transform)
        {
            clickCount = 0;
        }
        if (soulItem!=null&&soulItem.transform.parent != gameObject.transform)
        {
            stoneIn = false;
            soulItem = null;
        }
    }

    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        jewelManager.equipBtn[0].SetActive(true);
        jewelManager.equipBtn[1].SetActive(false);
        select.transform.parent = gameObject.transform;
        select.transform.position = gameObject.transform.position;
        clickCount += 1;
        if(clickCount>1)
        {
            clickCount = 0;
            select.transform.position = selectPos;
        }
        jewelManager.clickBtn = gameObject;
    }
}
