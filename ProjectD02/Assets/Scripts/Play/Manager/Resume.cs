using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    public GameObject pausePanel;

    void OnClick()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
