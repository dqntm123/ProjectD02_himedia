using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBtn : MonoBehaviour {

    public GameObject selector;
    public GameObject selectorTg;
    public GameObject shopItem;
    public bool shopItemIn = false;
    public int clickCount;
    public ShopManager sm;
    public Vector3 selectorPos;
    public Vector3 myPos;

	void Start ()//인벤토리칸,상점칸에 붙어있는 스크립트
    {
        sm = GameObject.Find("ShopManager").GetComponent<ShopManager>();//변수 sm에다가 ShopManager라는 오브젝트를 찾아서 ShopManager라는 스크립트를 붙인다
        selector = GameObject.Find("selector");
        selectorPos = selector.transform.localPosition;//selectorPos 에다가 selector오브젝트의 로컬포지션값을 넣어준다
        //myPos = gameObject.transform.localPosition;//나의포지션값 저장
    }
	
    void Update()
    {
        if(selector.transform.parent!=gameObject.transform)//셀렉터의 부모개체가 현재 내가 아니라면
        {
            clickCount = 0;//클릭카운터를 0으로 바꾼다
            selectorTg = null;//selectorTg 변수 오브젝트는 null이된다
        }
        if (shopItemIn == false)
        {
            shopItem = null;
        }
    }

	void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        selector.transform.position = gameObject.transform.position;//셀렉터 포지션값에 현재 오브젝트의 포지션값을 넣어준다
        selector.transform.parent = gameObject.transform;//셀렉터 오브젝트를 현재오브젝트의 자식개체로 넣는다
        selectorTg = selector;//selectorTg 변수 오브젝트 안에다가 selector 변수 오브젝트를 넣는다
        sm.shopTarget = gameObject;//sm 스크립트의 shopTarget 변수로선언한 오브젝트안에 현재오브젝트를 담는다
        clickCount += 1;
        if (clickCount>1)//클릭카운터가1보다 커진다면
        {
            clickCount = 0;//클릭카운터는 0으로 바꾸고
            selectorTg = null;//selectorTg 변수 오브젝트는 null이된다
            selector.transform.localPosition = selectorPos;//selector의 로컬포지션값을 처음에 저장된 selectorPos 포지션값으로 되돌린다
        }
    }
}
