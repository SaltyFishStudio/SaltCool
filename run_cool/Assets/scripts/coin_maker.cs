using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_maker : MonoBehaviour {
    public GameObject coin;
    public GameObject player;
    private List<Vector3> coinPosList = new List<Vector3>();
    private Vector3[] coinPosArray2;
    
    private float playerPos;




    // Use this for initialization
    void Start () {
        //初始化金币阵列1
        for (int i = 0; i < 4; i++)
        {
            coinPosList.Add( new Vector3(i, 0, 0));
        }
     
       

    }
	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position.x;
        Instantiate(coin, coinPosList[0] + new Vector3(playerPos + 10, 10, 0), Quaternion.identity);
        float cointime = 5;

        if (((int)playerPos + 10) % 20 == 0)            //+10的目的是为了不让在开始时，生成很多组金币
        {
            for (int i = 0; i < coinPosList.Count; i++)
            {
                Debug.Log(coinPosList[i]);
                Instantiate(coin, coinPosList[i] + new Vector3(playerPos , 3,0), Quaternion.identity);
            }
            
        }
        


		
	}
}
