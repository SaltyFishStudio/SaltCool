using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddASpeedTool : MonoBehaviour {






    public float movingY = 1f;


    IEnumerator MovingY(float waittime)
    {
        do
        {
            movingY = -1 * movingY;
            yield return (new WaitForSeconds(waittime));
        }
        while (true);
    }







	// Use this for initialization
	void Start () {
        StartCoroutine(MovingY(1.0f));
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(1 * Time.deltaTime, movingY * Time.deltaTime, 0);
		
	}
}
