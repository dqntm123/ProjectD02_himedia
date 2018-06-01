using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour {

    public Castle castle;
    public StageManager sm;
    public BoxCollider pauseCol;
    public UISprite pauseSp;
    public GameObject bgmmg;

	void Start ()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        pauseCol = GameObject.Find("PauseBtn").GetComponent<BoxCollider>();
        pauseSp = GameObject.Find("PauseBtn").GetComponent<UISprite>();
        StartCoroutine(Round());
        bgmmg = GameObject.Find("BGMManager");
    }
	
	void Update () {
		if(castle.hp <= 0)
        {
            StartCoroutine(RoundEnd());
        }
	}

    IEnumerator Round()
    {
        pauseCol.enabled = false;
        pauseSp.enabled = false;
        UILabel ul = gameObject.GetComponent<UILabel>();
        ul.text = "STAGE "+sm.currentStageNum;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2.0f);
        pauseCol.enabled = true;
        pauseSp.enabled = true;
        Time.timeScale = 1f;       
        ul.enabled = false;        
    }

    IEnumerator RoundEnd()
    {
        UILabel ul = gameObject.GetComponent<UILabel>();
        ul.enabled = true;
        ul.text = "STAGE CLEAR!";
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene(2);
        bgmmg.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[1];
        MusicManager.instance.auDios.Play();
    }
}
