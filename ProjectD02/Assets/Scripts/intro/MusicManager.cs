using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    private static MusicManager _instance = null;
    public static MusicManager instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = FindObjectOfType(typeof(MusicManager)) as MusicManager;
            }
            return _instance;
        }
    }
    public GameObject bgmController;
    public GameObject optionChang;
    public AudioClip[] bgmClip;
    public AudioSource auDios;
    public float sliderValue;
    public float bgmVoulme;
    void Start ()
    {
        if (_instance == null)//_instance가 null일때
            _instance = this;//_instance를 해당 _instance 로 한다
        else if (_instance != this)//_instance 생성되있다면
            Destroy(gameObject);//중복으로 생성하지 않게한다
        DontDestroyOnLoad(gameObject);//파괴되지않게 유지한다
        auDios = gameObject.GetComponent<AudioSource>();
        //bgmVoulme = gameObject.GetComponent<AudioSource>().volume;
        LoadedBgm();
    }
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if (sc.buildIndex == 0)
        {
            optionChang = GameObject.Find("OptionWindow");
            bgmController = GameObject.Find("BgmControl");
            SaveBgm();
            gameObject.GetComponent<AudioSource>().volume = bgmVoulme;
            if(optionChang!=null)
            {
                bgmController.GetComponent<UISlider>().value = sliderValue;
            }
        }
    }

    public void BgmPlus()//소리증가
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        bgmController.GetComponent<UISlider>().value += 0.2f;
        gameObject.GetComponent<AudioSource>().volume += 0.2f;
        sliderValue = bgmController.GetComponent<UISlider>().value;
        bgmVoulme = gameObject.GetComponent<AudioSource>().volume;
    }
    public void BgmMinus()//소리감소
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        bgmController.GetComponent<UISlider>().value -= 0.2f;
        gameObject.GetComponent<AudioSource>().volume -= 0.2f;
        sliderValue = bgmController.GetComponent<UISlider>().value;
        bgmVoulme = gameObject.GetComponent<AudioSource>().volume;
    }
    public void SaveBgm()
    {
        PlayerPrefs.SetFloat("BGMVoulme", bgmVoulme);
        PlayerPrefs.SetFloat("BGMSlider", sliderValue);
    }
    public void LoadedBgm()
    {
        bgmVoulme = PlayerPrefs.GetFloat("BGMVoulme", bgmVoulme);
        sliderValue= PlayerPrefs.GetFloat("BGMSlider", sliderValue);
    }
}
