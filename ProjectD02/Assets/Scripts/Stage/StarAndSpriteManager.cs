using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class StarAndSpriteManager : MonoBehaviour {

    public UISprite[] stageSprites;
    public UILabel[] stageNum;
    public UILabel starSumLabel;
    public int starSum;

    void Start ()
    {
        for (int i = 0; i < StageManager.instance.status.Length; i++)
        {
            if (StageManager.instance.status[i] == 0)
            {
                stageSprites[i].spriteName = ("stage_frame_nomal");     //스프라이트 이름으로 상태에 맞는 스프라이트를 찾아옴
                stageNum[i].text = Convert.ToString(i + 1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (StageManager.instance.status[i] == 1)
            {
                stageSprites[i].spriteName = ("stage_frame_bronze");
                stageNum[i].text = Convert.ToString(i + 1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (StageManager.instance.status[i] == 2)
            {
                stageSprites[i].spriteName = ("stage_frame_silver");
                stageNum[i].text = Convert.ToString(i + 1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (StageManager.instance.status[i] == 3)
            {
                stageSprites[i].spriteName = ("stage_frame_gold");
                stageNum[i].text = Convert.ToString(i + 1);
                stageSprites[i].gameObject.AddComponent<GoToStage>();
            }
            if (StageManager.instance.status[i] == 4)
            {
                stageSprites[i].spriteName = ("stage_frame_lock");
                stageNum[i].text = (" ");
            }
            //스테이터스가 0이면 스테이지 열림, 4면 잠김, 1~3은 1성 2성 3성.
            //스테이지 클리어가 될 때마다 status[]안의 숫자를 바꿔줌
            //처음에는 status[0]만 0, 나머지는 4로 설정: 1스테이지만 열림
            //i스테이지 클리어시 StageManager.status[i]를 +1씩 해줌: 한번 깰때마다 3성까지 증가 (3까지만 증가하게 조건을 줘야 함)
            //동시에 StageManager.status[i+1] (다음 스테이지)의 값을 0으로 바꿔서 스테이지를 열어줌 (혹시 모르니 값이 4(잠김) 일때만 동작하도록 조건 걸어줄 것)
            //18스테이지는 마지막 스테이지니 다음 스테이지를 여는 코드가 동작하지 않도록 조건을 추가할 것
        }
        for (int i = 0; i < StageManager.instance.status.Length; i++)
        {
            if (StageManager.instance.status[i] != 0 && StageManager.instance.status[i] != 4)
            {
                starSum += StageManager.instance.status[i];
            }
        }
        starSumLabel.text = Convert.ToString(starSum);
    }
	

	void Update ()
    {
		
	}
}
