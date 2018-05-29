using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTarget : MonoBehaviour {

    public int unitcount;
	void Update ()
    {
	    if(LevelManager.instanCe.lv[unitcount]==0)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.transform.parent.GetComponent<getButtonIndex>().clickCt==0)
        {
            gameObject.SetActive(false);
        }
    }
}
