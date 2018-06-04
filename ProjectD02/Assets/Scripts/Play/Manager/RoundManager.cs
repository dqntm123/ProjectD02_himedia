using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour {

    public Castle castle;
    public StageManager sm;
    public EnemyManager em;
    public BoxCollider pauseCol;
    public UISprite pauseSp;
    public GameObject bgmmg;
    public int[] middleBossStage;
    public int[] bossStage;
    public int stagetCheck;
    public bool castleBreak = false;
    public bool someon = false;
    public GameObject boss;
    public bool bossDead = false;


	void Start ()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        em = GameObject.Find("EnemyManaer").GetComponent<EnemyManager>();
        pauseCol = GameObject.Find("PauseBtn").GetComponent<BoxCollider>();
        pauseSp = GameObject.Find("PauseBtn").GetComponent<UISprite>();
        StartCoroutine(Round());
        bgmmg = GameObject.Find("BGMManager");
        stagetCheck = sm.GetComponent<StageManager>().currentStageNum;
        

    }
	
	void Update () {

        if(castle.hp <= 0)
        {
            castleBreak = true;
        }

        

        if(castleBreak==true)
        {
            if (em != null)
            {
                if (stagetCheck == middleBossStage[0])
                {
                    Instantiate(em.GetComponent<EnemyManager>().middleBoss[0], em.transform.position, em.transform.rotation);
                    Destroy(em);
                    someon = true;
                    em = null;
                }

                if (stagetCheck == middleBossStage[1])
                {
                    Instantiate(em.GetComponent<EnemyManager>().middleBoss[1], em.transform.position, em.transform.rotation);
                    Destroy(em);
                    someon = true;
                    em = null;
                }

                if (stagetCheck == bossStage[0])
                {
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
