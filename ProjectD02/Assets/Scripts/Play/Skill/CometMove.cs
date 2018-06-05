using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class CometMove : MonoBehaviour {

    public GameObject cm;
    public GameObject target;

    public void Awake()
    {

        if(gameObject.name=="Comet0")
        {
            target = cm.GetComponent<CometManager>().aoeTargets[0];
        }


        if (gameObject.name == "Comet1")
        {
            target = cm.GetComponent<CometManager>().aoeTargets[1];
        }



        if (gameObject.name == "Comet2")
        {
            target = cm.GetComponent<CometManager>().aoeTargets[2];
        }



    }

    void Start()
    {
        cm = GameObject.Find("CometManager");

        //for (int i = 0; i < cm.GetComponent<CometManager>().aoeTargets.Count; i++)
        //{
        //    target[i] = cm.GetComponent<CometManager>().aoeTargets[i];
        //    transform.parent = target[i].transform;
        //}

    }

	
	void Update ()
    {

      //gameObject.transform.Translate(3 * Time.deltaTime, -5 * Time.deltaTime, 0);

        if (target != null)
        {
            float distance = (target.transform.position - transform.position).magnitude;
        }

    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject, 1);
        }
    }

}
