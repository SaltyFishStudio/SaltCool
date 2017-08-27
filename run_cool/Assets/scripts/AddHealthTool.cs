using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//继承于MovingTool 便于调节参数

public class AddHealthTool : MovingTool
{







    void OnTriggerEnter(Collider othercollider)
    {
        if (othercollider.tag == "Player")
        {
            othercollider.GetComponent<player>().health++;
            Destroy(transform.gameObject);
 
        }
    }

    protected override void Update()
    {
        base.Update();
        if (Player.transform.position.x - transform.position.x > 10)
        {
            Destroy(transform.gameObject);
        }


    }








}
