using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_maker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public Queue<Transform> floorQueue;
    public Transform[] floorPerfab;
    bool isInitialfloor = false;
    public int InitialfloorNum = 10;
    public float InitialDistance = 4;
    public float floorDistance = 1;
    public Transform Runner;
    public float offsetX = 10f;
    public float height = -5f;













    // Update is called once per frame
    void Update ()
    {
        if (!isInitialfloor)
        {
            floorQueue = new Queue<Transform>();
            isInitialfloor = true;
            for (int i = 0; i < InitialfloorNum; i++)
            {

                Transform floor = (Transform)(Instantiate(floorPerfab[0], new Vector3(i * InitialDistance - offsetX, height, 0), Quaternion.identity));
                floorQueue.Enqueue(floor);
            }
        }


        floorDistance = Random.Range(0, 1 + (Time.realtimeSinceStartup >7 ? 7 : Time.realtimeSinceStartup));


        if (Runner.position.x - floorQueue.Peek().position.x > 12f)
        {
            Transform lastfloor = floorQueue.Dequeue();

            Destroy(lastfloor.gameObject);
            int choicebg = Random.Range(0, floorPerfab.Length);
            Vector3 newfloor = new Vector3(floorQueue.ToArray()[floorQueue.Count - 1].position.x + floorDistance + InitialDistance, height, 0);
            Transform newfloorPerfab = (Transform)Transform.Instantiate(floorPerfab[choicebg], newfloor, Quaternion.identity);
            floorQueue.Enqueue(newfloorPerfab);
        }




    }
}
