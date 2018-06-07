using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public GameObject mainCamera;
    public Animator ani;
    public bool rightOn = false;
    public bool leftOn = false;
    public bool isDead = false;
    public Collider diecol;
    public Animation anime;
    public float hp;
    public float maxHp;
    public GameObject Hpbar;
    public GameObject enemyManager;
    public List<GameObject> everys;

    public enum PLAYSTATE
    {
        NONE=0,
        RIGHT,
        LEFT,
        Attack1,
        Attack2,
        Win,
        DEAD
    }
    public PLAYSTATE playstate;

    void Awake()
    {
        
    }

	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera");//시작할때 메인카메라 변수안에 메인카메라 오브젝트를 찾아서 넣는다
        enemyManager = GameObject.Find("EnemyManaer");
        maxHp = hp;
    }
	

	void Update ()
    {
        if(hp<=0)
        {
            hp = 0;
            isDead = true;
            DeadProcess();
        }
        switch (playstate)
        {
            case PLAYSTATE.NONE:
                ani.SetBool("Move", false);
                ani.SetBool("Attack1", false);
                ani.SetBool("Attack2", false);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case PLAYSTATE.RIGHT:
                if(rightOn==false)//만약 rightOn이 false라면
                {
                    ani.SetBool("Move", true);
                    moveSpeed = 0.4f;
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);//오른쪽으로이동
                }
                if (rightOn == true)//만약 rightOn이 true라면
                {
                    leftOn = false;//leftOn은 폴스
                    ani.SetBool("Move", true);
                    moveSpeed = 0.4f;
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);//오른쪽으로이동
                    mainCamera.GetComponent<MainCameraMove>().camerastate = MainCameraMove.CAMERASTATE.RIGHT;//메인카메라에 있는 스크립트에 카메라스테이트를 RIGHT로 바꿔준다
                }
                break;
            case PLAYSTATE.LEFT:
                if(leftOn==false)//만약 leftOn이 false라면
                {
                    ani.SetBool("Move", true);
                    moveSpeed = 0.4f;
                    transform.rotation = new Quaternion(0,-180,0,0);
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);//왼쪽으로이동
                }
                if(leftOn==true)//만약 leftOn이 true라면
                {
                    rightOn = false;//rightOn은 폴스
                    ani.SetBool("Move", true);
                    moveSpeed = 0.4f;
                    transform.rotation = new Quaternion(0, -180, 0, 0);
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);//왼쪽으로이동
                    mainCamera.GetComponent<MainCameraMove>().camerastate = MainCameraMove.CAMERASTATE.LEFT;//메인카메라에 있는 스크립트에 카메라스테이트를 LEFT로 바꿔준다
                }
                break;
            case PLAYSTATE.Attack1:
                ani.SetBool("Attack1", true);
                moveSpeed = 0;
                break;
            case PLAYSTATE.Attack2:
                ani.SetBool("Attack2", true);
                moveSpeed = 0;
                break;
            case PLAYSTATE.Win:
                ani.SetBool("Win", true);
                break;
            case PLAYSTATE.DEAD:

                break;
        }
        if(transform.position.x<-1.75f)//오브젝트 포지션x값이 -1.7보다 작아진다면
        {
            transform.position = new Vector3(-1.75f,transform.position.y,-0.3f);//그 오브젝트의 위치값을 고정한다
        }
        if (transform.position.x >3.75f)//오브젝트 포지션x값이 3.7보다 커진다면
        {
             transform.position = new Vector3(3.75f, transform.position.y, -0.3f);//그 오브젝트의 위치값을 고정한다
        }
        if(isDead==false)
        {
            if(Hpbar.transform.localScale.x<=0)
            {
                Hpbar.transform.localScale = new Vector3(0, 360, 360);
            }
            Hpbar.transform.localScale = new Vector3(hp/maxHp*360,360,360);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Block1")//만약 태그된게 Blcok1이라면
        {
            leftOn = true;//leftOn을 트루로바꾼다
        }
        if (col.gameObject.tag == "Block2")//만약 태그된게 Blcok2이라면
        {
            rightOn = true;//rightOn을 트루로바꾼다
        }
    }
    public void RightMove()
    {
        playstate = PLAYSTATE.RIGHT;//플레이스테이트에 RIGHT로 이동
    }

    public void LeftMove()
    {
        playstate = PLAYSTATE.LEFT;//플레이스테이트에 LEFT로 이동
    }
    public void PlayerIdle()
    {
        playstate = PLAYSTATE.NONE;//플레이스테이트에 NONE로 이동
        mainCamera.GetComponent<MainCameraMove>().camerastate = MainCameraMove.CAMERASTATE.NONE;//메인카메라에 있는 스크립트에 카메라스테이트를 NONE로 바꿔준다
    }
    public void DeadProcess()
    {
        ani.SetBool("Dead", true);
        diecol.enabled = false;
        enemyManager.SetActive(false);
        isDead = true;
    }
}
