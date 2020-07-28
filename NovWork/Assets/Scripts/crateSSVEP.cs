using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateSSVEP : MonoBehaviour {
    public GameObject smallBox;
    float time;
	// Use this for initialization
	void Start() { 
    time = 0f;
    }
	
	// Update is called once per frame
	void Update () {
    time += Time.fixedDeltaTime;//12.5Hz

    smallBox = GameObject.Find("box");
    float height = smallBox.transform.position.y;
    //if (!smallBox) Destroy(this.gameObject);
    if (height <= 1.3)
    {
        if (time <= 0.04f)
            smallBox.GetComponent<Renderer>().material.color = Color.green;

        if (time > 0.04f)
        {
            smallBox.GetComponent<Renderer>().material.color = Color.white;
            if (time > 0.07f)
                time = 0f;
        }
    }
    else
        Destroy(smallBox.gameObject);
}
}
