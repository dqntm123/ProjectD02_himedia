using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStage : MonoBehaviour {

    public StageManager sm;
    public int stageNum;
    public GameObject bgmMg;

    private void Start()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        bgmMg = GameObject.Find("BGMManager");
    }

    public void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(3);
        bgmMg.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[2];
        MusicManager.instance.auDios.Play();
        GetStageNum();
    }

    public void GetStageNum()
    {
        string stageName = gameObject.name;
        for (int i = 0; i < 18; i++)
        {
            if (stageName == "Sprite (" + i + ")")      //스프라이트 이름을 기반으로 스테이지 넘버를 가져옴
            {
                stageNum = i+1;
            }
        }
        Debug.Log("Stage Number is :" + stageNum);
        sm.currentStageNum = stageNum;
    }
}
