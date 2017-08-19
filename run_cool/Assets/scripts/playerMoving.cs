using UnityEngine;
using System.Collections;

public class playerMoving : MonoBehaviour {

	// Use this for initialization

    //public float movingSpeed_fast = 2.0f;


	public float jumpingSpeed = 10.0f;    //起跳速度
    public float movingSpeed = 0.0f;     //初始移动速度
    public float maxSpeed = 8f;
	public float Acceleration = 2f;     //移动加速度
    public int timesOfjump = 2;                //几段跳


	private Rigidbody rb;
    private bool isPressingJimping = false;     //是否按下跳跃键
    private float jumpingDuration = 0.2f;       //一次跳跃持续时间
    private float jumpingTime = 0f;             //一次跳跃已经持续的时间
    void Start () {
		rb = transform.GetComponent<Rigidbody>() ;
        

	}
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "Jumpingarea")
        {
            timesOfjump = 2;
        }
    }
    void Update()
    {
        rb.AddForce(0, -100,0); //加快挑起后的下落速度

        //加速起步，速度达到最大值时匀速运动
        if (movingSpeed < maxSpeed)
        {
            movingSpeed = movingSpeed + Acceleration * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            maxSpeed = maxSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            maxSpeed = maxSpeed * 0.5f;
        }


        if (movingSpeed >= maxSpeed)
        {
            movingSpeed = maxSpeed;
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


        if (isPressingJimping && timesOfjump>=0)
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
        
        rb.velocity = new Vector3(movingSpeed, rb.velocity.y, 0);
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
