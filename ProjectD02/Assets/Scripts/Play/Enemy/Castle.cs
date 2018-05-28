using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    public float maxHp;
    public float hp;
    public GameObject roundManager;
    public GameObject hpBar;
    private UISlider hpBarUs;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Skill1")
        {
            hp -= 1;
        }
        if (hp == 0)
        {
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            mr.enabled = false;
            BoxCollider bc = gameObject.GetComponent<BoxCollider>();
            bc.enabled = false;
            UILabel ul = roundManager.GetComponent<UILabel>();
            ul.enabled = true;
            ul.text = "STAGE CLEAR!";
        }
    }

    private void Start()
    {
        hpBarUs = hpBar.GetComponent<UISlider>();
    }

    private void Update()
    {
        hpBarUs.value = hp/maxHp;
    }
}
