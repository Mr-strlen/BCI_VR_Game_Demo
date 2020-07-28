using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterControl : MonoBehaviour {
    float calTime;
    float speed = 1f;
    int step = 2;
    public Transform endPoint;
    public GameObject flow;
    public GameObject drop;
    // Use this for initialization
    void Start () {
        calTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        flow = GameObject.Find("Water_Drop");
        drop = GameObject.Find("Water_hit");
        GameObject controller = GameObject.Find("controller");
        gameController ar = controller.GetComponent<gameController>();
        ParticleSystem waterflow = flow.GetComponent<ParticleSystem>();
        ParticleSystem waterflow2 = drop.GetComponent<ParticleSystem>();
        if (Input.GetMouseButton(0)&&ar.flag ==1)
        {
            waterflow.Play();
            waterflow2.Play();
        }
        if(waterflow.isPlaying&&waterflow2.isPlaying)
        {
            calTime = calTime + Time.deltaTime;
            ar.addFlag(step);
        }
        if (calTime >= 5.0f&calTime<=9.0f)
        {
            
             waterflow.Stop();
             GameObject barrel = GameObject.Find("barrel_water");  
             barrel.gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
             ar.addFlag(3);
            //barrel.transform.position  = Vector3.MoveTowards(transform.position,endPoint.position, speed * Time.deltaTime);
         //   calTime = 0f;
            
            
        }
       /* if(calTime>=7.0f)
        {
            calTime = 0;
        }
        */
  
    }
}
