using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterSSVEP : MonoBehaviour {
    float calTime;
    public GameObject bucket;
    public GameObject smallBox;
    // Use this for initialization
    void Start () {
        calTime = 0f;
        GameObject controller = GameObject.Find("controller");
        gameController ar = controller.GetComponent<gameController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        bucket = GameObject.Find("barrel_water");
        smallBox = GameObject.Find("box");
        if ((ar.flag ==1)&!smallBox)
        {
            calTime = calTime + Time.fixedDeltaTime;
            if (calTime <= 0.08f)
                bucket .GetComponent<Renderer>().material.color = Color.white ;

            if (calTime > 0.08f)
            {
                bucket .GetComponent<Renderer>().material.color = Color.yellow;
                if (calTime > 0.15f)
                    calTime = 0f;
            }
        }
        else bucket.GetComponent<Renderer>().material.color = Color.white;
    }
}
