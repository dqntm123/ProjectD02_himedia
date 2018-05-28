using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour {


    public GameObject[] shopChang;
    public GameObject shopPanel;
    public bool shopin = false;
    public int buyValue;
    void Start()
    {
        shopPanel = GameObject.Find("ShopPanel");
        gameObject.transform.parent = shopPanel.transform;//시작하자마자 변수로 선언된 shopPanel 오브젝트안에 자식개체로 들어간다
        for (int i = 0; i < shopChang.Length; i++)
        {
            shopChang[i] = GameObject.Find("shop" + i);
            if (shopChang[i].GetComponent<ShopBtn>().shopItemIn == false)//빈 샵아이템창으로 이동하는 부분
            {
                if (shopin == false)
                {
                    shopChang[i].GetComponent<ShopBtn>().shopItemIn = true;
                    shopin = true;
                    shopChang[i].GetComponent<ShopBtn>().shopItem = gameObject;
                    gameObject.transform.position = shopChang[i].transform.position;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
