using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    void OnClick()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
}
