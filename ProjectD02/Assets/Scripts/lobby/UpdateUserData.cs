using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUserData : MonoBehaviour
{
    public MoneyManager mm;
    public string updateURL = "http://ldh852.cafe24.com/gameserver/update_user.php";

    private static UpdateUserData _instance = null;
    public static UpdateUserData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(UpdateUserData)) as UpdateUserData;
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateToServer()
    {
        StartCoroutine(UpdateCoroutine());
    }

    IEnumerator UpdateCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("uNum", PlayerPrefs.GetInt("uNum"));
#if UNITY_ANDROID && !UNITY_EDITOR
        form.AddField("GID", PlayerPrefs.GetString("GID"));
#endif
        form.AddField("gold", mm.goldCount);
        form.AddField("soul", mm.soulCount);
        WWW www = new WWW(updateURL, form);
        yield return www;
    }
}
