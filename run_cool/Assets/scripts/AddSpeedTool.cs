using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedTool : MonoBehaviour {






    public float movingY = 1f;


    private GameObject Player;


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


    
    IEnumerator AddSpeedForAWhile()
    {
        
            
        Player.GetComponent<player>().maxSpeed = Player.GetComponent<player>().maxSpeed * 2;
        Player.GetComponent<player>().movingSpeed = Player.GetComponent<player>().maxSpeed;
        for(float timer = 1f; timer >= 0; timer -= Time.deltaTime)  
        {
            yield return 0;  
        }

        Player.GetComponent<player>().maxSpeed = Player.GetComponent<player>().normalmovingSpeed;
        Debug.Log("aaa");
        Destroy(transform.gameObject);
    }







    //player拾取后的作用和销毁
    void OnTriggerEnter(Collider othercollider)
    {
        if (othercollider.tag == "Player")
        {
            //开启加速协程  顺便加速结束后销毁物体，如果一开始就销毁物体，协程会停止，所以检测到碰撞之后先关掉meshRender
            StartCoroutine(AddSpeedForAWhile());
            //如果一开始就销毁物体，协程会停止，所以检测到碰撞之后先关掉meshRender
            transform.GetComponentInChildren<MeshRenderer>().enabled = false;

            
            /*
            float normalspeed = othercollider.GetComponent<player>().maxSpeed;
            othercollider.GetComponent<player>().maxSpeed = othercollider.GetComponent<player>().maxSpeed * 2;
            othercollider.GetComponent<player>().movingSpeed = othercollider.GetComponent<player>().maxSpeed;
            */
        }
    }





	// Use this for initialization
	void Start () {
        Player = GameObject.Find("player");
        StartCoroutine(MovingY(1.0f));
	}
	
	// Update is called once per frame
	void Update () {

        /* 在该加速器不被destory的前提下才会有用
        if (howlongtime > 0)
        {
            howlongtime -= Time.deltaTime;
            Player.GetComponent<player>().maxSpeed = buffspeed;
            Player.GetComponent<player>().movingSpeed = Player.GetComponent<player>().maxSpeed;
            if (howlongtime <= 0)
            {
                Player.GetComponent<player>().maxSpeed = Player.GetComponent<player>().normalmovingSpeed;
            }
        }
        */
        transform.Translate(1 * Time.deltaTime, movingY * Time.deltaTime, 0);
		
	}
}
