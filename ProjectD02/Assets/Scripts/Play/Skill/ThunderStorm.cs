using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStorm : MonoBehaviour {

    public Transform player;
    public GameObject[] lightning;

	void Start () {
		
	}
	
	void Update () {
		
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
    }
}
