using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private GameObject player;


	// Use this for initialization

    protected virtual void OnTriggerEnter(Collider otherCollider)
    {
        //碰到该物体后扣血
        if (otherCollider.tag == "Player")
        {
            otherCollider.GetComponent<player>().health = otherCollider.GetComponent<player>().health - 1;

            //强制位移
            otherCollider.GetComponent<Rigidbody>().AddForce(new Vector3(-20000, 0, 0)) ;
            //otherCollider.GetComponent<Transform>().position = otherCollider.GetComponent<Transform>().position + new Vector3(-2, 1, 0);
            //暂时失效
            transform.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponentInChildren<CapsuleCollider>().enabled = false;
            //延迟后继续生效

            StartCoroutine(WaitAndSetCollider(2.0f));
            

            

        }
    }
    IEnumerator WaitAndSetCollider(float timer)
    {
        yield return new WaitForSeconds(timer);
        transform.GetComponent<BoxCollider>().enabled = true;
        transform.GetComponentInChildren<CapsuleCollider>().enabled = true;
    }




    protected virtual void OnTriggerStay(Collider otherCollider)
    {

    }

    protected virtual void OnTriggerExit(Collider otherCollider)
    {
        //碰到该物体后扣血
        if (otherCollider.tag == "Player")
        {

            //otherCollider.GetComponent<player>().movingSpeed = 0;

        }
    }







    protected virtual void Start()
    {
        player = GameObject.Find("player");
		
	}
	
	// Update is called once per frame
    protected virtual void Update()
    {
        if (player.transform.position.x - transform.position.x > 10)
        {
            Destroy(transform.gameObject);
        }
		
	}
}
