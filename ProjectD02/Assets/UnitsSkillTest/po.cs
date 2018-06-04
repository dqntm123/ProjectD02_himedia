using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class po : MonoBehaviour {

    public float stunTime;
    public float dot;
    public float numberOfTimes=1;
    public GameObject enemy;

	
	void Start () {
		
	}
	
	
	void Update ()
    {
       
    }


    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Enemy")
        {
            enemy = col.gameObject;
            enemy.GetComponent<dot>().sd();
            //StartCoroutine(DotDamage());
           
        }
     

    }

    IEnumerator DotDamage()
    {
        //for (int i = 0; i < numberOfTimes; i++)
        //{
        //    Debug.Log(i+"hi");
        //    yield return new WaitForSeconds(1f);
        //}

        if (dot < stunTime)
        {
            dot += Time.deltaTime;
            if (dot >= numberOfTimes)
            {
                numberOfTimes += 1;
                Debug.Log(numberOfTimes);
            }

            if (dot >= stunTime)
            {
                Destroy(gameObject);
            }
        }
        yield return null;
    }

}
