using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSVEP : MonoBehaviour {

	// Use this for initialization
        private float calTime;
        private int switcher;
        private int left;
        private bool blink;
        private float temp;
    private GameObject smallBox;
    //private GameObject button;
    void Awake()
       {
        QualitySettings.vSyncCount = 0;  
        Application.targetFrameRate = 20;

        }
        void Start()
       {
        calTime = 0f;
        //temp = calTime;
        switcher = 0;
        GameObject controller = GameObject.Find("controller");
        gameController ar = controller.GetComponent<gameController>();
        /*if (ar.flag  == 0)
            button  = GameObject.Find("Cube");
        if (ar.flag == 1)
            button  = GameObject.Find("Sphere");
            */
        }
        void FixedUpdate()
    {

            smallBox = GameObject.Find("box");
        if (!smallBox) Destroy(this.gameObject );
        calTime += Time.deltaTime;
        switcher += 1;
        //calTime = calTime + Time.realtimeSinceStartup;
  
        /*if (Time.realtimeSinceStartup*100 % 2 <=1.0f)
            flag = false;
        else
            flag = true;*/
        left = switcher % 2;
        if (left==0) blink = false;
        else blink = true;
        
        this .gameObject.GetComponent<MeshRenderer>().enabled = blink;
        print(calTime);
        print(blink);
            //this.gameObject.SetActive(flag);
 
        }
        }
       

	
