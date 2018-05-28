using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectSoundManager : MonoBehaviour {

    private static EffectSoundManager _iNstance = null;
    public static EffectSoundManager iNstance
    {
        get
        {
            if (_iNstance == null)
            {
                _iNstance = FindObjectOfType(typeof(EffectSoundManager)) as EffectSoundManager;
            }
            return _iNstance;
        }
    }
    public GameObject effectController;
    public GameObject optionObj;
    public AudioClip[] effectClip;
    public AudioSource audios;
    public float sdValue;
    public float effectVoulme;
    void Start ()
    {
        if (_iNstance == null)//_iNstance null일때
            _iNstance = this;//_iNstance 해당 _iNstance 로 한다
        else if (_iNstance != this)//_iNstance 생성되있다면
            Destroy(gameObject);//중복으로 생성하지 않게한다
        DontDestroyOnLoad(gameObject);//파괴되지않게 유지한다
        audios = gameObject.GetComponent<AudioSource>();
        effectVoulme = gameObject.GetComponent<AudioSource>().volume;
        LoadedEffect();
    }
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if (sc.buildIndex == 0)
        {
            optionObj = GameObject.Find("OptionWindow");
            effectController = GameObject.Find("EffectControl");
            SaveEffect();
            gameObject.GetComponent<AudioSource>().volume = effectVoulme;
            if (optionObj != null)
            {
                effectController.GetComponent<UISlider>().value = sdValue;
            }
        }
    }
    public void EffectPlus()//이펙트소리 증가
    {
        gameObject.GetComponent<AudioSource>().clip = effectClip[0];
        audios.PlayOneShot(audios.clip);
        effectController.GetComponent<UISlider>().value+=0.2f;
        gameObject.GetComponent<AudioSource>().volume += 0.2f;
        sdValue = effectController.GetComponent<UISlider>().value;
        effectVoulme = gameObject.GetComponent<AudioSource>().volume;
    }
    public void EffectMinus()//이펙트소리 감소
    {
        gameObject.GetComponent<AudioSource>().clip = effectClip[0];
        audios.PlayOneShot(audios.clip);
        effectController.GetComponent<UISlider>().value -= 0.2f;
        gameObject.GetComponent<AudioSource>().volume -= 0.2f;
        sdValue = effectController.GetComponent<UISlider>().value;
        effectVoulme = gameObject.GetComponent<AudioSource>().volume;
    }
    public void SaveEffect()
    {
        PlayerPrefs.SetFloat("EFFECTVoulme", sdValue);
        PlayerPrefs.SetFloat("EFFECTSlider", effectVoulme);
    }
    public void LoadedEffect()
    {
        sdValue = PlayerPrefs.GetFloat("EFFECTVoulme", sdValue);
        effectVoulme = PlayerPrefs.GetFloat("EFFECTSlider", effectVoulme);
    }
}
