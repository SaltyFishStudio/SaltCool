using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {

	// Use this for initialization



    public GameObject Player;
    public GameObject addspeedtool;

    private float timer = 0;

	void Start () {
        Player.GetComponent<player>().onCollection = OnCollection;

	}

    void OnCollection()
    {
        Debug.Log("get coin");
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 
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
                GameOver();
            }
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(addspeedtool,Vector3.zero,Quaternion.identity);
        }




		
	}
}
