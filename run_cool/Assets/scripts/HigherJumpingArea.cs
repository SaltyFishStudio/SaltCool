using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherJumpingArea : MonoBehaviour
{

	// Use this for initialization

    void OnTriggerEnter(Collider otherCollider)
    {

        //弹跳
        if (otherCollider.GetComponent<player>())
        {
            otherCollider.GetComponent<player>().timesOfjump = 2;
            float higherjumpSpeed = otherCollider.GetComponent<player>().jumpingSpeed + 10f;
            otherCollider.GetComponent<Rigidbody>().velocity = new Vector3(otherCollider.GetComponent<player>().movingSpeed, higherjumpSpeed, 0);
        }

    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
