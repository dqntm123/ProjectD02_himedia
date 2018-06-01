using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject[] buttons;
    public GameObject selector;
    public GameObject target;
    public GameObject anitarget;
    public GameObject[] upgradeORunlock;
    public GameObject[] unitCOST;
    public List<GameObject> unitIdle;
    public string[] unitName;
    void Start ()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].AddComponent<getButtonIndex>();
        }
        unitIdle[0].SetActive(true);
        unitIdle[0].GetComponent<AniTarget>().parentObj = buttons[0];
        unitIdle[0].transform.parent = buttons[0].transform;
        buttons[0].GetComponent<getButtonIndex>().clickCt = 1;
        target = buttons[0];
    }
    private void Update()
    {
      
    }
}
