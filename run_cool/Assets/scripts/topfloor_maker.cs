using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topfloor_maker : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
    public Queue<Transform> topQueue;
    public Transform[] topPerfab;
    bool isInitialtop = false;
    public int InitialtopNum = 8;
    public float InitialDistance = 4f;
    public float height = 5f;
    public Transform Runner;
    private float offsetX = 10f;














    // Update is called once per frame
    void Update ()
    {
        if (!isInitialtop)
        {
            topQueue = new Queue<Transform>();
            isInitialtop = true;
            for (int i = 0; i < InitialtopNum; i++)
            {

                Transform top = (Transform)(Instantiate(topPerfab[0], new Vector3(i * InitialDistance - offsetX, height, 0), Quaternion.identity));
                topQueue.Enqueue(top);
            }
        }
        if (Runner.position.x - topQueue.Peek().position.x > 12f)
        {
            Transform lasttop = topQueue.Dequeue();

            Destroy(lasttop.gameObject);
            int choicebg = Random.Range(0, topPerfab.Length);
            Vector3 newtop = new Vector3(topQueue.ToArray()[topQueue.Count - 1].position.x + InitialDistance, height, 0);
            Transform newtopPerfab = (Transform)Transform.Instantiate(topPerfab[choicebg], newtop, Quaternion.identity);
            topQueue.Enqueue(newtopPerfab);
        }




    }
}
