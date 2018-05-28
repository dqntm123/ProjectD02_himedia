using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;

    void OnClick()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
}
