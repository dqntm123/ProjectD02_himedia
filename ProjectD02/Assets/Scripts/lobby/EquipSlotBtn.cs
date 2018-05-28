using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotBtn : MonoBehaviour {

    public JewelBtnManager jewelMg;
    public GameObject item;
    public bool soulIn = false;
    public int equipCount;
    public GameObject sel;
    public Vector3 selPos;
    void Awake()
    {
        jewelMg = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
        sel = GameObject.Find("Selector");
        selPos = sel.transform.localPosition;
    }


    void Update()
    {
        if (sel.transform.parent != gameObject.transform)
        {
            equipCount = 0;
        }
        if (item != null && item.transform.parent != gameObject.transform)
        {
            item = null;
            soulIn = false;
        }
    }
    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        jewelMg.equipBtn[0].SetActive(false);
        jewelMg.equipBtn[1].SetActive(true);
        sel.transform.parent = gameObject.transform;
        sel.transform.position = gameObject.transform.position;
        equipCount += 1;
        if (equipCount > 1)
        {
            equipCount = 0;
            sel.transform.position = selPos;
        }
        jewelMg.releaseBtn = gameObject;
    }
}
