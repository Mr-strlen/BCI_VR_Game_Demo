using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigCrate : MonoBehaviour {
    float calTime;
    float speed;
    float size;
    float cycleTime;
	// Use this for initialization
	void Start () {
        calTime = 0f;
        speed = 1f;
        size = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       GameObject controller = GameObject.Find("controller");
       gameController ar = controller.GetComponent<gameController>();
       GameObject midTree = GameObject.Find("Rakshi_Tree2_2");
       GameObject lagTree = GameObject.Find("Rakshi_Tree2_1");
       //GameObject seeding = GameObject.Find("carrot_plant");
        //  Destroy(seeding.gameObject);
        if (ar.flag == 3)
        {   calTime = calTime + Time.deltaTime;
            if (calTime <= 3.0f)
                midTree.gameObject.GetComponent<MeshRenderer>().enabled = true;
            if(calTime<=5.0f&&calTime>3.0f)
            {
                lagTree.gameObject.GetComponent<MeshRenderer>().enabled = true;
                midTree.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            if(calTime>5.0f&&calTime<=9.0f)
            {
                size = size + speed * Time.deltaTime;
                GameObject apple=GameObject.Find("Apple");
                GameObject pear = GameObject.Find("Pear");
                apple.transform.localScale = new Vector3(size,size,size);
                pear.transform.localScale = new Vector3(size, size, size);

            }
            if(calTime>9.0f)
            {
                cycleTime = cycleTime + Time.fixedDeltaTime;

                if (cycleTime>= 0.04f&cycleTime <=0.08f)
                {

                }
               // if()
                //这两个水果不同频率闪动。
                
            //看到一个之后，出一个particlesystem。然后这玩意掉下去。（左键和右键）
            }

        }
	}
}
