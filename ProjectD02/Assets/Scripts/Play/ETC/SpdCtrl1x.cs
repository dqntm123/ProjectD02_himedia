using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdCtrl1x : MonoBehaviour {

    public GameObject nextBtn;

	void OnClick()
    {
        Time.timeScale = 2;
        nextBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
