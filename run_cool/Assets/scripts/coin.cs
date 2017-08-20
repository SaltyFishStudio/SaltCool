using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	// Use this for initialization
    private GameObject player;

	void Start () {
        
		
	}
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Destroy(transform.gameObject);
        }
    }

    void OnCollection()
    {
 
    }




	// Update is called once per frame
	void Update () {

        if(transform.GetComponent<Transform>())
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player.transform.position.x - transform.position.x > 12f)
        {
            Destroy(transform.gameObject);
        }
		
	}
}
