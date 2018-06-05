using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnim : MonoBehaviour
{

    public float speed;

    void Start()
    {

        //dropRate = Random.Range(0, 99);
        //if (dropRate <= 4)
        //{
        //    drop = true;
        //}

        //if (drop == true)
        //{
        //    Instantiate(dropGold, transform.position, transform.rotation);
        //    drop = false;
        //}

    }


    void Update()
    {
        gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        gameObject.GetComponent<TweenAlpha>().enabled = true;
        Destroy(gameObject, 1.3f);
    }
}

