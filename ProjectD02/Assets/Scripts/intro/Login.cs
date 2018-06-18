using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using SimpleJSON;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Login : MonoBehaviour
{
    public string gameServerURL = "";
    public GameObject loginBtn;
    public UILabel logText;

    void Start()
    {
        if (Application.internetReachability == 0)
        {
            logText.GetComponentInChildren<UILabel>().text = "Could not connect internet..";
        }
        else
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();
        }
    }

    public void LoginBtn()
    {
        StartCoroutine(GoogleLogin());
    }

    IEnumerator GoogleLogin()
    {
        yield return null;
#if UNITY_EDITOR
        Debug.Log("Editor 환경입니다.");
        StartCoroutine(StartLogin());
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {             
                Debug.Log("로그인 성공!");               
                logText.text = "Login ID: " + Social.localUser.id;
                StartCoroutine(StartLogin());
            }
            else
            {
                Debug.Log("로그인 실패!");              
                logText.text = "Login failed!";
            }
        });
#endif
    }

    IEnumerator StartLogin()
    {
        WWWForm form = new WWWForm();
#if UNITY_ANDROID && !UNITY_EDITOR
        form.AddField("GID", PlayerPrefs.GetString("GID"));
#endif
        form.AddField("uNum", PlayerPrefs.GetInt("uNum"));
        form.AddField("UUID", SystemInfo.deviceUniqueIdentifier);
        WWW www = new WWW(gameServerURL, form);    
        yield return www;  
        Debug.Log(www.text);
        SetMyGameData(www.text);       
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
    }

    public void SetMyGameData(string data)
    {
        var gameData = JSON.Parse(data);
#if UNITY_ANDROID && !UNITY_EDITOR
        PlayerPrefs.SetString("GID", Social.localUser.id);
#endif
        PlayerPrefs.SetInt("uNum", int.Parse(gameData["uNum"]));
    }
}
