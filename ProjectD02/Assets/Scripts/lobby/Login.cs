using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using SimpleJSON;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Login : MonoBehaviour
{

    public string gameServerURL = "http://wltn9359.cafe24.com/DKA/DKAlogin.php"; //버전체크를 위한 서버URL
    public string verCheckURL = "http://wltn9359.cafe24.com/DKA/Ver.php";//게임서버 접속을 위한 URL
    public GameObject loginBtn;//로그인 버튼
    public GameObject popUpWinodw;//팝업윈도우
    public UILabel popUpWindowText;//팝업윈도우 내 텍스트
    public UILabel logText;//로그를 확인하기 위한 텍스트

    void Start()
    {

        if (Application.internetReachability == 0)//인터넷이 연결이 되어있지 않다면...
        {
            popUpWinodw.SetActive(true);//팝업윈도우 게임 오브젝트 활성화
            popUpWindowText.text = "Could Not Connect Internet ";//팝업윈도우 내 텍스트
            Debug.Log("인터넷 연결 상태를 확인하세요..");
        }

        else // 인터넷에 연결이 되어있다면...
        {
            StartCoroutine(VerCheck());//버전체크 코루틴 호출
        }

    }

    void Update()
    {

    }


    IEnumerator VerCheck() // 버전을 체크하기 위한 코루틴
    {
        WWW www = new WWW(verCheckURL);//http 접속을 위한 새로운 WWW 클래스 생성
        yield return www; // www가 반환될때까지 잠시대기
        if (www.text == Application.version) //www에서 반환된 text가 Application.version 과 같다면...
        {
            loginBtn.SetActive(true); // 로그인 버튼 활성화ON
        }

        else //www에서 반환된 text가 Application.version 과 같지 않다면...
        {
            popUpWinodw.SetActive(true); //팝업윈도우 활성화ON
            popUpWindowText.text = "Version is Not Match "; //팝업윈도우 내 텍스트 전환
        }

    }

    IEnumerator StartLogin() //로그인 과정을 위한 코루틴
    {
        WWWForm form = new WWWForm(); //클라이언트 데이터를 보내기 위한 새로운 폼(WWWform) 생성
        form.AddField("UserNum", PlayerPrefs.GetInt("UserNum"));  //생성된 form에다 Key,value를 필드에 추가     에드폼한 값들은 www로 같이 이동됨
        WWW www = new WWW(gameServerURL, form); //http 접속을 위한 새로운 WWW 클래스 생성
        yield return www; // www가 반환될때까지 잠시대기
        Debug.Log(www.text);
        SetMyGameData(www.text); // www에서 반환된 text를 SetMyGameData()의 인자로 넣어 호출 
        loginBtn.SetActive(false); // 로그인 버튼 비활성화
        Application.LoadLevel(1); //1번씬 로드
    }



    public void SetMyGameData(string data) //www에서 받아온 JSON string 데이터를 파싱하여 PlayerPrefs에 저장하는 함수
    {
        var gameData = JSON.Parse(data);//www에서 받아온 JSON string 데이터를 var로 선언
        PlayerPrefs.SetInt("UserNum", int.Parse(gameData["UserNum"])); //JSON 내 UserID란 key를 가진 value를 int로 변환하여 저장
        PlayerPrefs.SetString("UserNick", gameData["UserNick"]); //JSON 내 UserNick란 key를 가진 value를 저장
        PlayerPrefs.SetInt("UserGold", int.Parse(gameData["UserGold"])); //JSON 내 UserGold란 key를 가진 value를 int로 변환하여 저장
        PlayerPrefs.SetInt("UserCash", int.Parse(gameData["UserCash"])); //JSON 내 UserCash란 key를 가진 value를 int로 변환하여 저장
       
//#if UNITY_ANDROID && !UNITY_EDITOR
//        PlayerPrefs.SetString("Google", Social.localUser.id);
//#endif
        // SimpleJSON.JSONNode[]
    }

    public void Log() // 로그인 버튼을 눌렀을때  StartLogin 코루틴을 호출하기 위한 함수
    {

        //StartCoroutine(GoogleLogin());
        StartCoroutine(StartLogin());
    }

    public void Link() //마켓링크를 열기위한 함수
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Company.Ser&hl=ko&ah=WfUR_gV55B_EGV6ZVcdwFvcfgOY");
    }

//    IEnumerator GoogleLogin()
//    {
//        yield return PlayGamesPlatform.Activate();


//#if UNITY_EDITOR
//        Debug.Log("Unity Editor입니다.");
//        StartCoroutine(StartLogin());
//#endif

//#if UNITY_ANDROID && !UNITY_EDITOR
//        Social.localUser.Authenticate((bool success) =>
//        {

//            if (success)
//            {
//                Debug.Log("로그인 성공");
//                logText.text = "Thank You Login  " + Social.localUser.id+"  "+ Social.localUser.userName;
//                StartCoroutine(StartLogin());

//            }

//            else
//            {
//                Debug.Log("로그인 실패");
//                logText.text = "Login Failed!!!";
//            }

//        });
//#endif
//    }

}
