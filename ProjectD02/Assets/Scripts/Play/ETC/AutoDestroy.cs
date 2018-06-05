using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float destroyValue;

	void Start ()
    {
        Destroy(gameObject, destroyValue);
    }
}
