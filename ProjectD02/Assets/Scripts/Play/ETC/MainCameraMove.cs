using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour {

    public float cameraSpeed;
    public float rightLimit;
    public float leftLimit;
    public enum CAMERASTATE
    {
        NONE,
        RIGHT,
        LEFT
    }
    public CAMERASTATE camerastate;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        switch (camerastate)
        {
            case CAMERASTATE.NONE:

                break;
            case CAMERASTATE.RIGHT:
                transform.Translate(cameraSpeed * Time.deltaTime, 0, 0);//오른쪽이동
                break;
            case CAMERASTATE.LEFT:
                transform.Translate(-cameraSpeed * Time.deltaTime, 0, 0);//왼쪽이동
                break;
            default:
                break;
        }
        if(gameObject.transform.position.x > rightLimit)//만약 오브젝트의 x축이 rightLimit 변수 보다 커진다면
        {
            transform.position=new Vector3(rightLimit, 0,-4);//오브젝트의 포지션을 지정한 값으로 고정시켜라
        }
        if (gameObject.transform.position.x < leftLimit)//만약 오브젝트의 x축이 leftLimit 변수 보다 작아진다면
        {
            transform.position = new Vector3(leftLimit, 0,-4);//오브젝트의 포지션을 지정한 값으로 고정시켜라
        }
    }
}
