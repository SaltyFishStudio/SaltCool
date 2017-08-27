using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMaker : MonoBehaviour {

    public GameObject player;

    //public GameObject AddSpeedTool;
    //public GameObject AddHealthTool;

    public List<GameObject> Tools;


    IEnumerator InitializeToolInTime(float frequency)
    {
        do
        {
            yield return (new WaitForSeconds(frequency));
            Debug.Log("add a tool");
            //实例化飞行道具，位置根据当前时刻player的位置而定
            Instantiate(Tools[Random.Range(0, Tools.Count)], new Vector3(player.transform.position.x + 20, 4, 0), Quaternion.identity);
           
        } while (true);
    }



	// Use this for initialization
	void Start () {
        

        //Tools.Add(AddSpeedTool);
        //Tools.Add(AddHealthTool);
        StartCoroutine(InitializeToolInTime(15.0f));
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
