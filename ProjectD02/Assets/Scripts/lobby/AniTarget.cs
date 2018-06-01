using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTarget : MonoBehaviour {

    public int unitCT;
    public GameObject parentObj;
	void Update ()
    {
	    if(LevelManager.instanCe.lv[unitCT]==0)
        {
            gameObject.SetActive(false);
        }
        if(parentObj!=null)
        {
            if (gameObject.transform.parent.GetComponent<getButtonIndex>().clickCt == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
