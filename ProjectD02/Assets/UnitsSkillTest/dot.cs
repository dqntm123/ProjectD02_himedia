using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour {

    void Start()
    {
    //    StartCoroutine(DotCo());
    }

    public float hp = 100;
    public float dmg = 10;
    public int times = 10;


    public void sd( )
    {
        StartCoroutine(DotCo());
    }

    public IEnumerator DotCo()
    {
        for (int i = 0; i < times; i++)
        {
            hp -= dmg;
            Debug.Log(hp);
            if (hp == 0)
            {
                Debug.Log("죽음.");
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
