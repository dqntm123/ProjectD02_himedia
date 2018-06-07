using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforMationValue : MonoBehaviour {

    public UILabel[] ValueLabel;
    public GameObject stopwatch;
    public GameObject stone;
    public GameObject skillMg;
    void Awake()
    {
        skillMg = GameObject.Find("SkillManager");
        stopwatch = GameObject.Find("StopWatch");
    }
    void Start ()
    {
        ValueLabel[0].text = "Play Time  :  " +stopwatch.GetComponent<StopWatch>().sec.ToString("#,#00.0 sec");
        ValueLabel[1].text = "Get SoulStone  :  ";
        stone.GetComponent<UISprite>().spriteName = skillMg.GetComponent<SkillManager>().skillIcon[SoulSkillManager.INSTANCE.soulskillNunber[1]];
        ValueLabel[2].text = "Total Star   :  " + StageManager.instance.status[StageManager.instance.currentStageNum-1];
        ValueLabel[3].text = "Total Gold  :  " + MoneyManager.inStance.goldCount.ToString()+" Gold";
        ValueLabel[4].text = "Total Soul  :  " + MoneyManager.inStance.soulCount.ToString()+" Soul";
    }
	
	void Update ()
    {
		
	}
}
