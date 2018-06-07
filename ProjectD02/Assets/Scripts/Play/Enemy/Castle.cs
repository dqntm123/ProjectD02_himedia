using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    public float maxHp;
    public float hp;
    public GameObject roundManager;
    public GameObject hpBar;
    private UISlider hpBarUs;
    public GameObject[] enemy;
    public RoundManager rm;

    private void OnTriggerEnter(Collider col)
    {
      
    }

    public void DamageManager()
    {
       
    }

    private void Start()
    {
        hpBarUs = hpBar.GetComponent<UISlider>();
        maxHp = hp;
        rm = GameObject.Find("RoundManager").GetComponent<RoundManager>();
    }

    private void Update()
    {
        hpBarUs.value = hp/maxHp;

        if (hp <= 0)
        {
           if(rm.someon == false)
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].GetComponent<UnitController>().DeadProcess();
                }
            }
           
            //MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            //mr.enabled = false;
            BoxCollider bc = gameObject.GetComponent<BoxCollider>();
            bc.enabled = false;
            Destroy(gameObject);
            //UILabel ul = roundManager.GetComponent<UILabel>();
            //ul.enabled = true;
            //ul.text = "STAGE CLEAR!";
        }
    }
}
