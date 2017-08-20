using UnityEngine;
using System.Collections;
using System;



public class player : MonoBehaviour {

	// Use this for initialization


    public Action onCollection;
    public int  health = 2;
	public float normaljumpSpeed = 10.0f;    //起跳速度

    public float jumpingSpeed = 10.0f;
    public float movingSpeed = 0.0f;     //初始移动速度
    public float normalmovingSpeed = 8f;
    public float fastmovingSpeed = 16f;
	public float Acceleration = 2f;     //移动加速度
    public int timesOfjump = 2;                //几段跳
    public float maxSpeed = 8f;


    public bool playerIsAlive = true;   //player是否存活


	private Rigidbody rb;
    private bool isPressingJimping = false;     //是否按下跳跃键
    private float jumpingDuration = 0.2f;       //一次跳跃持续时间
    private float jumpingTime = 0f;             //一次跳跃已经持续的时间


    private float deadjumptimer = 0;


    
    void OnTriggerEnter(Collider otherCollider)
    {
        
        //判断二段跳条件
        if (otherCollider.gameObject.tag == "Jumpingarea")
        {
            timesOfjump = 2;
            jumpingSpeed = normaljumpSpeed; //恢复正常跳跃速度（强对于踩到弹性跳板而言）
        }
        //收集金币
        if (otherCollider.GetComponent<coin>())
        {
            onCollection();
        }
        //弹跳
   

    }






    void Start()
    {
        
        rb = transform.GetComponent<Rigidbody>();


    }




    void Update()
    {
        rb.AddForce(0, -100, 0); //加快下落速度
        if (playerIsAlive == false)
        {
            transform.GetComponent<BoxCollider>().enabled = false;
            deadjumptimer += Time.deltaTime;
            if ( deadjumptimer < 0.5)
            {

                rb.velocity = new Vector3(0, 10, 0);

            }

        }
        if (playerIsAlive)
        {
            rb.AddForce(0, -100, 0); //加快下落速度
            Debug.Log(health);
            //加速起步，速度达到最大值时匀速运动
            if (movingSpeed < maxSpeed)
            {
                movingSpeed = movingSpeed + Acceleration * Time.deltaTime;
                rb.velocity = new Vector3(movingSpeed, rb.velocity.y, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                maxSpeed = fastmovingSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                maxSpeed = normalmovingSpeed;
            }


            if (movingSpeed >= maxSpeed)
            {
                movingSpeed = maxSpeed;
                rb.velocity = new Vector3(movingSpeed, rb.velocity.y, 0);
            }


            //跳跃




            isPressingJimping = Input.GetMouseButton(0) || Input.GetKey("space");

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                timesOfjump = timesOfjump - 1;

            }


            if (!isPressingJimping)
            {
                jumpingTime = 0;
            }


            if (isPressingJimping && timesOfjump >= 0)
            {

                jumpingTime += Time.deltaTime;
                if (jumpingTime >= jumpingDuration)
                {
                    rb.velocity = new Vector3(movingSpeed, rb.velocity.y, 0);
                }
                else
                {
                    rb.velocity = new Vector3(movingSpeed, jumpingSpeed, 0);

                }



            }




            //死亡判定
            if (health <= 0 || transform.position.y < -8)
            {
                playerIsAlive = false;

            }
        }
    }


/*
 * 自己写的键盘控制移动
	void Update () 
	{
	
		float jampSpeed = 0f;
		float h = Input.GetAxis("Horizontal");
		if (Input.GetKey (KeyCode.RightShift)) 
		{
			h = h * 2;
		}
		if (Input.GetKeyDown(KeyCode.Space) )
		{
			jampSpeed = 2.0f;
			rb.AddForce(0,100,0);
		}
		transform.Translate (0, (1+10*Mathf.Abs(h)) *jampSpeed*Time.deltaTime,0);
		transform.Translate (h*Time.deltaTime, 0, 0);
		
		
	}

*/

}
