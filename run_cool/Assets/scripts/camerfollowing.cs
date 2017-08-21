using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerfollowing : MonoBehaviour {

	// Use this for initialization

    public GameObject TargetObject;
    public float followingSpeed = 5f;
    public float offsetX = 0;
    public float offsetY = 2;
    public float offsetZ = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPosition = new Vector3(TargetObject.transform.position.x + offsetX, 
                                         TargetObject.transform.position.y + offsetY,
                                         transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, newPosition, followingSpeed * Time.deltaTime);
	}
}
