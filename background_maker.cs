using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class background_maker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	public Queue<Transform> bgQueue ;
	public Transform[] bgPerfab;
	bool isInitialbg = false;
	public int InitialbgNum = 2;
	public float InitialDistance = 5;
	public float bgDistance = 0;
	public Transform Runner;

	void Update () 
	{
		if (!isInitialbg) 
		{
			bgQueue = new Queue<Transform>();
			isInitialbg = true;
			for(int i = 0;i < InitialbgNum;i++)
			{
				int choicebg = Random.Range(0,bgPerfab.Length);
				Transform bg = (Transform)(Instantiate (bgPerfab[choicebg],
                                new Vector3(bgDistance+i*InitialDistance,0,0),
                                Quaternion.identity));
				bgQueue.Enqueue(bg);
			}
		}

		if(Runner.position.x - bgQueue.Peek().position.x > 3f)
		{
			Transform lastbg = bgQueue.Dequeue();

			Destroy(lastbg.gameObject);
			int choicebg = Random.Range(0,bgPerfab.Length);
			Vector3 newbg = new Vector3(bgQueue.ToArray()[bgQueue.Count-1].position.x+InitialDistance,0,0);
			Transform newbgPerfab = (Transform)Transform.Instantiate (bgPerfab[choicebg],newbg,Quaternion.identity);
			bgQueue.Enqueue(newbgPerfab);
		}

		
	}

}
