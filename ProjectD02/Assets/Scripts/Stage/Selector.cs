using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour {
    public GameObject[] btns;
    public GameObject[] selcet;
    public Dictionary<int, GameObject> num;
    public int[] nu;
   

    void Start ()
    {
        num = new Dictionary<int, GameObject>();

        for (int i = 0; i < nu.Length; i++)
        {
            //btns[i] = GameObject.Find("Btn" + i);
            num.Add(i, GameObject.Find("Btn" + i));
            Debug.Log(num.Keys);
            Debug.Log(num.Values);
        }

        //for (int i = 0; i < selcet.Length; i++)
        //{
        //    selcet[i] = GameObject.Find("Selector" + i);
        //    selcet[i].SetActive(false);
        //}
        
       
    }
	
	
	void Update ()
    {
		
	}

   public void selects()
    {
       
    }
    public void LobbyScene()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(1);
    }
}
