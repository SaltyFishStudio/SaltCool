using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Maker : MonoBehaviour {



    public GameObject player;

    //public GameObject AddSpeedTool;
    //public GameObject AddHealthTool;

    public GameObject Bullet;


    IEnumerator InitializeToolInTime(float frequency)
    {
        do
        {
            yield return (new WaitForSeconds(frequency));

            Instantiate(Bullet, new Vector3(player.transform.position.x + 20, Random.Range(-4,4), 0), Quaternion.identity);

        } while (true);
    }



    // Use this for initialization
    void Start()
    {


        //Tools.Add(AddSpeedTool);
        //Tools.Add(AddHealthTool);
        StartCoroutine(InitializeToolInTime(3.0f));
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
