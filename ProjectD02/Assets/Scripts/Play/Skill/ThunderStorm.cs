using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStorm : MonoBehaviour {

    public Transform player;
    public GameObject[] lightning;
    public UISprite splash;

    void Awake()
    {
       
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void CastTS()
    {
        StartCoroutine(CastTSCo());
    }

    public IEnumerator CastTSCo()
    {
        Vector3 playerfront0 = new Vector3(player.transform.position.x + 0.8f, player.transform.position.y, player.transform.position.z);
        Vector3 playerfront1 = new Vector3(player.transform.position.x + 1.2f, player.transform.position.y, player.transform.position.z);
        Instantiate(lightning[0], playerfront0, lightning[0].transform.rotation);
        Instantiate(lightning[1], playerfront1, lightning[1].transform.rotation);     
        yield return null;
        splash.alpha = 0.9f;
        float splashTime = 0.6f;
        for (float i = 0.9f; i > 0; i -= 0.01f) 
        {
            splash.alpha -= 0.01f;
            yield return new WaitForSeconds(splashTime/(0.9f/0.01f));            
        }
    }
}
