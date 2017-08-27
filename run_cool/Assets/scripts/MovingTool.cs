using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//用于统一控制移动的飞行道具的移动属性

public class MovingTool : MonoBehaviour {


    private float movingY = 4f;  //Y轴移动速度
    protected GameObject Player;




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

    // Use this for initialization
    protected virtual void Start()
    {
        Player = GameObject.Find("player");
        //开启该物体上下循环移动的协程，设置该物体朝着一个方向运动的时间
        StartCoroutine(MovingY(2.0f));
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        transform.Translate(-1 * Time.deltaTime, movingY * Time.deltaTime, 0);
    }
}
