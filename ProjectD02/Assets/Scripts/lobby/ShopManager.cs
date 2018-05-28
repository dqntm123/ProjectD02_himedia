using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public GameObject[] inventoryBtn;
    public GameObject[] shopButton;
    public GameObject shopPanNel;
    public GameObject invenPanNel;
    public GameObject invenTarget;
    public GameObject shopTarget;
    public GameObject buy;
    public GameObject sell;
    public GameObject undo;

	void Awake ()
    {
        for (int i = 0; i < inventoryBtn.Length; i++)//선언한 변수안에 i 만큼 찾아서 게속 넣어준다
        {
            inventoryBtn[i] = GameObject.Find("Inven" + i);
            inventoryBtn[i].AddComponent<InvenBtn>();//ShopBtn이라는 스크립트를 추가해준다
        }
        for (int a = 0; a < shopButton.Length; a++)
        {
            shopButton[a] = GameObject.Find("shop" + a);
            shopButton[a].AddComponent<ShopBtn>();
        }
        buy = GameObject.Find("Buy");
        sell = GameObject.Find("Sell");
        undo = GameObject.Find("Undo");
        shopPanNel = GameObject.Find("ShopPanel");
        invenPanNel = GameObject.Find("InventoryPanel");
    }
    void Update()
    {

    }
    public void BuyBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (shopTarget!=null)//변수 오브젝트 shopTarget 이 null이 아니라면
        {
            if (shopTarget.GetComponent<ShopBtn>().clickCount == 1 && shopTarget.GetComponent<ShopBtn>().shopItem != null)
            //만약 shopTarget 의 스크립트 ShopBtn 인트 변수 clickCount 이 null이 아니라면 그리고 오브젝트 변수 shopItem 이 null이 아니라면
            {
                Debug.Log("살꺼!!");
                if (MoneyManager.inStance.soulCount >= shopTarget.GetComponent<ShopBtn>().shopItem.GetComponent<ShopItem>().buyValue)
                //인트 변수 soulCount 값보다 해당아이템 인트 변수 buyValue 값이 크거나 같을때
                {
                    MoneyManager.inStance.goldCount -= shopTarget.GetComponent<ShopBtn>().shopItem.GetComponent<ShopItem>().buyValue;
                    //MoneyManager 싱글톤의 인트 변수 goldCount 값에다가 아이템의 인트 변수 buyValue 값을 뺀다
                    MoneyManager.inStance.SaveMoney();//골드값을 저장
                    shopTarget.GetComponent<ShopBtn>().shopItemIn = false;//불값으로 선언한 shopItemIn 을 false로 바꾼다
                    for (int a = 0; a < inventoryBtn.Length; a++)
                    {
                        inventoryBtn[a] = GameObject.Find("Inven" + a);//인벤창을 찾는다
                        if (inventoryBtn[a].GetComponent<InvenBtn>().invenItemIn == false)//인벤창의 inventoryBtn의 변수 불값이 폴스와같다면
                        {
                            if(shopTarget.GetComponent<ShopBtn>().shopItem.GetComponent<ShopItem>().shopin==true)
                            //샵아이템의 변수 shopin의 bool값이 트루라면
                            {
                                inventoryBtn[a].GetComponent<InvenBtn>().invenItemIn = true; //인벤창의 invenItemIn의 변수 불값을 트루로바꾸고
                                shopTarget.GetComponent<ShopBtn>().shopItem.GetComponent<ShopItem>().shopin = false;
                                //샵아이템의 변수 shopin의 bool값을 false로 바꾼다
                                inventoryBtn[a].GetComponent<InvenBtn>().invenTem = shopTarget.GetComponent<ShopBtn>().shopItem;
                                //인벤창의 아이템 오브젝트 변수안에 shopItem의 오브젝트를 집어넣는다
                                shopTarget.GetComponent<ShopBtn>().shopItemIn = false;//샵버튼의 변수 shopItemIn 불값을 false로 바꾼다
                                shopTarget.GetComponent<ShopBtn>().shopItem.transform.parent = invenPanNel.transform;
                                //현재오브젝트의 부모객체를  변수 invenPanNel 오브젝트의 자식개체로 이동한다 
                                shopTarget.GetComponent<ShopBtn>().shopItem.transform.position = inventoryBtn[a].transform.position;
                                //shopItem 의 포지션을 해당 트루값인 inventoryBtn 오브젝트로 이동한다
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("못산다!!");
        }
    }
    public void SellBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (invenTarget!=null)//변수 오브젝트 invenTarget 이 null이 아니라면
        {
            if (invenTarget.GetComponent<InvenBtn>().clickCount == 1 && invenTarget.GetComponent<InvenBtn>().invenTem != null)
            //만약 invenTarget 의 스크립트 InvenBtn에 인트변수 clickCount 값이 1과 같다면 그리고 오브젝트 변수 invenTem 이 null이 아니라면
            {
                Debug.Log("팔꺼!!");
                MoneyManager.inStance.goldCount += invenTarget.GetComponent<InvenBtn>().invenTem.GetComponent<InvenItem>().sellValue;
                //MoneyManager 싱글톤의 인트 변수 goldCount 값에다가 아이템의 인트 변수 sellValue 값을 더한다
                MoneyManager.inStance.SaveMoney();//골드값을 저장
                invenTarget.GetComponent<InvenBtn>().invenItemIn = false;//불값으로 선언한 invenItemIn 을 false로 바꾼다
                Destroy(invenTarget.GetComponent<InvenBtn>().invenTem);//그리고 그아이템을 파괴한다
            }
        }
        else
        {
            Debug.Log("못팔어!!");
        }
    }
    public void UndoBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
    }
}
