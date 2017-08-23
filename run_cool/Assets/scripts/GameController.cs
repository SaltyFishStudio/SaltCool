using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {

	// Use this for initialization



    public GameObject Player;
    public GameObject addspeedtool;
	public GameObject gameEndUI;
	private GameObject tempEndUI;
    private float timer = 0;
	private bool isGameOver=false ;
	void Start () {
        Player.GetComponent<player>().onCollection = OnCollection;

	}

    void OnCollection()
    {
        Debug.Log("get coin");
    }

    void GameOver()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//实例化结束UI，父级设为Canvas
		tempEndUI = Instantiate (gameEndUI);
		tempEndUI.GetComponent <Transform > ().SetParent (GameObject.Find ("Canvas").GetComponent <Transform > (), true);
		isGameOver = true ;
    }

	
	// Update is called once per frame
	void Update () {
        if (Player.GetComponent<player>().playerIsAlive == false)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
            }
            else
            {
				if(isGameOver==false){
				GameOver();
            }
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(addspeedtool,Vector3.zero,Quaternion.identity);
        }




		
	}
}
}
