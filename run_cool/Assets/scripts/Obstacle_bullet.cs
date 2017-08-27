using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_bullet : Obstacle {

    private float speed = -5.0f;

	// Use this for initialization
    protected override void Start()
    {
        base.Start();
	}
	
	// Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}
}
