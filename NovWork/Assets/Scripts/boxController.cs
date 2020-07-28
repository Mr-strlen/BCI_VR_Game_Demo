using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour {
   
    float speed = 6.0f;
    int step = 1;
   
    //Something's wrong.
    void Start () {
        
    }
	// Update is called once per frame
	void Update () {
     GameObject controller = GameObject.Find("controller");
        gameController ar = controller.GetComponent<gameController>(); 
        float height = this.transform.position.y;

		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (translation < 0)
        {
            transform.Translate(0, 0, translation);
            if (height > 1.3)
            {
                Destroy(this.gameObject);
                step = 1;
                ar.addFlag(step);
            }
        }
        
        
	}
}
