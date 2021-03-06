﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_maker : MonoBehaviour {
    public GameObject coin;
    public GameObject player;
    private List<Vector3> coinPosList1 = new List<Vector3>();
    private List<Vector3> coinPosList2 = new List<Vector3>();
    private List<Vector3> coinPosList3 = new List<Vector3>();
    private List<Vector3> coinPosList4 = new List<Vector3>();
    private List<List<Vector3>> coinPosListPerfabs = new List<List<Vector3>>();
    private float playerPos;




    // Use this for initialization
    void Start () {
        //初始化金币阵列1
        for (int i = 0; i < 4; i++)
        {
            coinPosList1.Add( new Vector3(i, 0, 0));
        }
        //初始化金币阵列2
        for (int i = 0; i < 5; i++)
        {
            coinPosList2.Add(new Vector3(i, Mathf.Abs(i - 2) , 0));
        }
        //初始化金币阵列3
        for (int i = 0; i < 9; i++)
        {
            coinPosList3.Add(new Vector3(i, 0.5f * Mathf.Pow(-1,i), 0));
        }
        //初始化金币阵列4
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                coinPosList4.Add(new Vector3(i, j, 0));
            }
        }


        //把金币序列添加进待调用的列表里
        coinPosListPerfabs.Add(coinPosList1);
        coinPosListPerfabs.Add(coinPosList2);
        coinPosListPerfabs.Add(coinPosList3);
        coinPosListPerfabs.Add(coinPosList4);

        StartCoroutine(SetCoinArray());
     
       

    }
    /* 隔段时间生成一次金币  被隔段位移生成一次金币替代
    IEnumerator WaitTime(float frequency)
    {

        for (float timer = 0; timer < frequency; timer = timer + Time.deltaTime)
        {
            yield return 0;
 
        }
 
    }
    */


    //隔段位移生成一次金币
    IEnumerator WaitPlayerMove(float coindistance)
    {

        float thisplayerPos = player.transform.position.x;

        //等待player位置和上面获取的位置之间的距离超过coindistance
        while (player.transform.position.x - thisplayerPos < coindistance)
        {
            yield return 0 ;
        }

    }





    IEnumerator SetCoinArray()
    {

       
     

        do
        {

            playerPos = player.transform.position.x;    //获得当前时间player的x位置
            List<Vector3> coinPosList = coinPosListPerfabs[Random.Range(0, coinPosListPerfabs.Count)];
            float coinPosY = Random.Range(-3.0f, 1.0f); //随机金币阵列的高度
            for (int i = 0; i < coinPosList.Count; i++)
            {

                Instantiate(coin, coinPosList[i] + new Vector3(playerPos + 20, coinPosY, 0), Quaternion.identity);
            }

            yield return (WaitPlayerMove(20.0f));
        }
        while (true);
 
    }



	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position.x;
        
        

        /*
        if (((int)playerPos + 10) % 20 == 0)            //+10的目的是为了不让在开始时，生成很多组金币
        {
            for (int i = 0; i < coinPosList1.Count; i++)
            {
                Debug.Log(coinPosList1[i]);
                Instantiate(coin, coinPosList1[i] + new Vector3(playerPos , 3,0), Quaternion.identity);
            }
            
        }
        */
        


		
	}
}
