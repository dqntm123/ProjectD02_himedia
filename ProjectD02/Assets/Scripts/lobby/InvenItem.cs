using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenItem : MonoBehaviour {

    public GameObject[] invenChang;
    public GameObject invenPanel;
    public bool invenIn = false;
    public int sellValue;
    void Start()
    {
        invenPanel = GameObject.Find("InventoryPanel");
        gameObject.transform.parent = invenPanel.transform;//시작하자마자 변수로 선언된 invenPanel 오브젝트안에 자식개체로 들어간다
        for (int i = 0; i < invenChang.Length; i++)
        {
            invenChang[i] = GameObject.Find("Inven" + i);//인벤창을 찾는다
            if (invenChang[i].GetComponent<InvenBtn>().invenItemIn == false)//인벤창의 invenItemIn의 변수 불값이 폴스와같다면
            {
                if (invenIn == false)//이오브젝트의 변수 invenIn의 불값이 폴스와같다면
                {
                    invenChang[i].GetComponent<InvenBtn>().invenItemIn = true; //인벤창의 invenItemIn의 변수 불값을 트루로바꾸고
                    invenIn = true; //이오브젝트의 변수 invenIn의 불값을 트루로한다
                    invenChang[i].GetComponent<InvenBtn>().invenTem = gameObject;//인벤창의 아이템 오브젝트 변수안에 현재의 오브젝트를 집어넣는다
                    gameObject.transform.position = invenChang[i].transform.position;//현재오브젝트의 위치값을 트루로 지정한 인벤창 위치값으로 이동한다
                }
            }
        }
    }

    void Update()
    {

    }
}
