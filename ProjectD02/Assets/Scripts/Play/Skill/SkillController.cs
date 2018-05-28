using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {

    public float speed;
    public float damage;
    public GameObject effect1;
	void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Castle")//만약 태그된게 Castle라면
        {
            Instantiate(effect1, transform.position, transform.rotation);
            Destroy(gameObject);//오브젝트를 파괴
        }
        if (col.gameObject.tag == "Enemy1")//만약 태그된게 Enemy1라면
        {
            
        }
    }
}
