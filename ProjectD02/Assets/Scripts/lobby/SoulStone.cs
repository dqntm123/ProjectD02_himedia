using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulStone : MonoBehaviour {

    public GameObject jewelPN;
    public GameObject[] jewelChang;
    public bool[] btnIn;
    public int costValue;
    public int soulSkillNumber;
    void Awake()
    {
        jewelPN = GameObject.Find("JewelPanel");
        gameObject.transform.parent = jewelPN.transform;
    }
	void Start ()
    {
        for (int i = 0; i < jewelChang.Length; i++)
        {
            jewelChang[i] = GameObject.Find("Stone" + i);
            if (jewelChang[i].GetComponent<JewelBtn>().stoneIn == false)
            {
                if (btnIn[0] == false)
                {
                    btnIn[0] = true;
                    btnIn[1] = false;
                    jewelChang[i].GetComponent<JewelBtn>().stoneIn = true;
                    jewelChang[i].GetComponent<JewelBtn>().soulItem = gameObject;
                    gameObject.transform.position = jewelChang[i].transform.position;
                    gameObject.transform.parent = jewelChang[i].transform;
                }
            }
        }
    }
	
	void Update ()
    {
		
	}
}
