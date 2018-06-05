using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStormDmg : MonoBehaviour {

    public float dmg;
    public float shortStunTime;

    private void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "Enemy")
        {            
            other.GetComponent<UnitController>().hP -= dmg;
            other.GetComponent<UnitController>().idleStateMaxTime = shortStunTime;
            other.GetComponent<UnitController>().stun = true;
            other.GetComponent<UnitController>().unitstate = UnitController.UNITSTATE.IDLE;
        }
    }
}
