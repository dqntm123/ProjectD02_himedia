using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdCtrl3x : MonoBehaviour {

    public GameObject nextBtn;

    void OnClick()
    {
        Time.timeScale = 1;
        nextBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
