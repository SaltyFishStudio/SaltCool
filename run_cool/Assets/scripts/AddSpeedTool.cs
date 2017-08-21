using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedTool : MonoBehaviour {






    public float movingY = 1f;

    //隔段时间转换Y速度方向
    IEnumerator MovingY(float waittime)
    {
        do
        {
            movingY = -1 * movingY;
            yield return (new WaitForSeconds(waittime));
        }
        while (true);
    }


    /*
    IEnumerator AddSpeedForAWhile(float waittime)
    {

    }
    */

    //player拾取后的作用和销毁
    void OnTriggerEnter(Collider othercollider)
    {
        if (othercollider.tag == "Player")
        {
            Destroy(transform.gameObject);
            float normalspeed = othercollider.GetComponent<player>().maxSpeed;
            othercollider.GetComponent<player>().maxSpeed = othercollider.GetComponent<player>().maxSpeed * 2;
            othercollider.GetComponent<player>().movingSpeed = othercollider.GetComponent<player>().maxSpeed;
        }
    }





	// Use this for initialization
	void Start () {
        StartCoroutine(MovingY(1.0f));
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(1 * Time.deltaTime, movingY * Time.deltaTime, 0);
		
	}
}
