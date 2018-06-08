using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour {

    public Castle castle;
    public StageManager sm;
    public EnemyManager em;
    public BoxCollider pauseCol;
    public UISprite pauseSp;
    public GameObject bgmmg;
    public GameObject information;
    public int[] middleBossStage;
    public int[] bossStage;
    public int stageCheck;
    public bool castleBreak = false;
    public bool someon = false;
    public GameObject boss;
    public bool bossDead = false;
    public GameObject finishChang;
    public GameObject player;
    public GameObject[] bloodFog;
    public GameObject[] enemy;
    public GameObject[] units;
    public int[] stageNum;


    void Start ()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        em = GameObject.Find("EnemyManaer").GetComponent<EnemyManager>();
        pauseCol = GameObject.Find("PauseBtn").GetComponent<BoxCollider>();
        pauseSp = GameObject.Find("PauseBtn").GetComponent<UISprite>();
        StartCoroutine(Round());
        bgmmg = GameObject.Find("BGMManager");
        stageCheck = sm.GetComponent<StageManager>().currentStageNum;
        player = GameObject.Find("Player");
        

    }
	
	void Update ()
    {
        if (castle.hp <= 0)
        {
            castleBreak = true;
        }

        if(player.GetComponent<PlayerController>().hp<=0)
        {
            StartCoroutine(GameOver());
        }

        if(castleBreak==true)
        {
            if (em != null)
            {
                if (stageCheck == middleBossStage[0])
                {
                    bloodFog[0].SetActive(true);
                    EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
                    EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
                    Instantiate(em.GetComponent<EnemyManager>().middleBoss[0], em.transform.position, em.transform.rotation);
                    Destroy(em);
                    someon = true;
                    em = null;
                }

                if (stageCheck == middleBossStage[1])
                {
                    bloodFog[0].SetActive(true);
                    Instantiate(em.GetComponent<EnemyManager>().middleBoss[1], em.transform.position, em.transform.rotation);
                    Destroy(em);
                    someon = true;
                    em = null;
                }

                if (stageCheck == bossStage[0])
                {
                    bloodFog[0].SetActive(true);
                    Instantiate(em.GetComponent<EnemyManager>().boss[0], em.transform.position, em.transform.rotation);
                    Destroy(em);
                    someon = true;
                    em = null;
                }
            }

            if (someon == false)
            {
                StartCoroutine(RoundEnd());
            }

            if(bossDead == true)
            {
                bloodFog[1].SetActive(true);
                bloodFog[0].SetActive(false);
                StartCoroutine(RoundEnd());
            }

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
        em.GetComponent<EnemyManager>().ins = false;
        //for (int i = 0; i < stageNum.Length; i++)
        //{
        //    if (StageManager.instance.currentStageNum == stageNum[i])
        //    {
        //        if (SoulSkillManager.INSTANCE.soulskillNunber[i] <= 0 && SoulSkillManager.INSTANCE.soulskillNunber[i] < 1)
        //        {
        //            SoulSkillManager.INSTANCE.soulskillNunber[i] = 1;
        //            SoulSkillManager.INSTANCE.SaveSoulStone();
        //            information.GetComponent<InforMationValue>().stoneNum = i;
        //        }
        //    }
        //}
        UILabel ul = gameObject.GetComponent<UILabel>();
        ul.enabled = true;
        ul.text = "STAGE CLEAR!";
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<UnitController>().DeadProcess();
        }

        units = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < units.Length; i++)
        {
            units[i].GetComponent<UnitController>().DeadProcess();
        }
        player.GetComponent<PlayerController>().playstate = PlayerController.PLAYSTATE.Win;
        yield return new WaitForSecondsRealtime(2.0f);
        if (StageManager.instance.status[stageCheck - 1] >= 0 && StageManager.instance.status[stageCheck - 1] <3 && StageManager.instance.status[stageCheck] != 4)
        {
            StageManager.instance.status[stageCheck - 1] += 1;
        }
        if (StageManager.instance.status[stageCheck - 1] == 0 && StageManager.instance.status[stageCheck] == 4)
        {
            StageManager.instance.status[stageCheck - 1] += 1;
            StageManager.instance.status[stageCheck] = 0;
        }
        gameObject.SetActive(false);
        finishChang.SetActive(true);
        finishChang.GetComponent<GameFinishFillAmount>().finishChang[0] = true;
        StageManager.instance.SaveSataus();
    }
    IEnumerator GameOver()
    {
        UILabel ul = gameObject.GetComponent<UILabel>();
        ul.enabled = true;
        ul.text = "Game Over!";
        em.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(2.0f);
        gameObject.SetActive(false);
        finishChang.SetActive(true);
        finishChang.GetComponent<GameFinishFillAmount>().finishChang[1] = true;
        StageManager.instance.SaveSataus();
    }
    public void StageScene()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(2);
        bgmmg.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[1];
        MusicManager.instance.auDios.Play();
        MoneyManager.inStance.SaveMoney();
    }
    

}
