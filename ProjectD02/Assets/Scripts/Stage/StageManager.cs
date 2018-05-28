using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class StageManager : MonoBehaviour {

    public int currentStageNum;
    public int[] status;
    public UISprite[] stageSprites;
    public UILabel[] stageNum;
    public UILabel starSumLabel;
    public int starSum;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        for (int i = 0; i < status.Length; i++)
        {
            if (status[i] == 0)
            {
                stageSprites[i].spriteName = ("stage_frame_nomal");     //스프라이트 이름으로 상태에 맞는 스프라이트를 찾아옴
                stageNum[i].text = Convert.ToString(i+1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (status[i] == 1)
            {
                stageSprites[i].spriteName = ("stage_frame_bronze");
                stageNum[i].text = Convert.ToString(i+1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (status[i] == 2)
            {
                stageSprites[i].spriteName = ("stage_frame_silver");
                stageNum[i].text = Convert.ToString(i+1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (status[i] == 3)
            {
                stageSprites[i].spriteName = ("stage_frame_gold");
                stageNum[i].text = Convert.ToString(i+1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (status[i] == 4)
            {
                stageSprites[i].spriteName = ("stage_frame_lock");
                stageNum[i].text = (" ");
            }
            //스테이터스가 0이면 스테이지 열림, 4면 잠김, 1~3은 1성 2성 3성.
        }
        for (int i = 0; i < status.Length; i++)
        {
            if (status[i] != 0 && status[i] != 4)
            {
                starSum += status[i];
            }
        }
        starSumLabel.text = Convert.ToString(starSum);
    }

    public void Back()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(1);
    }
}
