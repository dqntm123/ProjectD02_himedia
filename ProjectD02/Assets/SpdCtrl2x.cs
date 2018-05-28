using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdCtrl2x : MonoBehaviour {

    public GameObject nextBtn;

    void OnClick()
    {
        Time.timeScale = 3;
        nextBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
