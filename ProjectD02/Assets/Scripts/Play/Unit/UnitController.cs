using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public float speed;
    public float unitHP;
    public float Atk;
    public GameObject enemy;
    public List<GameObject> lookE;
    public enum UNITSTATE
    {
        IDLE,
        MOVE,
        ATTACK,
        DAMAGE,
        KILL,
        DEAD
    }
    public UNITSTATE unitstate;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        switch (unitstate)
        {
            case UNITSTATE.IDLE:

                break;
            case UNITSTATE.MOVE:
                transform.Translate(speed * Time.deltaTime, 0, 0);//왼쪽이동
                break;
            case UNITSTATE.ATTACK:

                break;
            case UNITSTATE.DAMAGE:

                break;

            case UNITSTATE.DEAD:
                Destroy(gameObject);//오브젝트를 파괴한다
                break;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy1")//만약 태그된게 Enemy1이라면
        {
            unitstate = UNITSTATE.DEAD;//unitstate를 DEAD로 바꾼다
        }
        if (col.gameObject.tag == "Castle")//만약 태그된게 Castle라면
        {
            unitstate = UNITSTATE.DEAD;//unitstate를 DEAD로 바꾼다
        }
    }
}
