using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//继承于MovingTool 便于调节参数
public class AddSpeedTool : MovingTool
{







    private bool IsPlayerGet = false;  


   


    //吃到后 player加速一段时间
    IEnumerator AddSpeedForAWhile()
    {
        
            
        Player.GetComponent<player>().maxSpeed = Player.GetComponent<player>().maxSpeed * 2;
        Player.GetComponent<player>().movingSpeed = Player.GetComponent<player>().maxSpeed;
        //加速时间
        Debug.Log("aaaa");
        for(float timer = 3f; timer >= 0; timer -= Time.deltaTime)  
        {
            yield return 0;  
        }
        //回到正常速度
        
        Player.GetComponent<player>().maxSpeed = Player.GetComponent<player>().normalmovingSpeed;

        Destroy(transform.gameObject);
    }







    //player拾取后的作用和销毁
    void OnTriggerEnter(Collider othercollider)
    {
        if (othercollider.tag == "Player")
        {
            IsPlayerGet = true;
            //开启加速协程  顺便加速结束后销毁物体，如果一开始就销毁物体，协程会停止，所以检测到碰撞之后先关掉meshRender
            StartCoroutine(AddSpeedForAWhile());
            //如果一开始就销毁物体，协程会停止，所以检测到碰撞之后先关掉meshRender
            transform.GetComponentInChildren<MeshRenderer>().enabled = false;


        }
    }





	// Use this for initialization


    protected override void Update()
    {
        base.Update();

        if (Player.transform.position.x - transform.position.x > 10 &&IsPlayerGet == false)
        {
            Destroy(transform.gameObject);
        }
        

    }
}
