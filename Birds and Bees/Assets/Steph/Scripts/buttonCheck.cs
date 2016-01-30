using UnityEngine;
using System.Collections;

public class buttonCheck : MonoBehaviour {

    bool colliding = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //Input.GetAxis();

        if(colliding)
        {
            if (Input.GetButtonDown(this.tag + "1"))
            {
                Destroy(this.gameObject);
            }
        }
	}

    void OnTriggerEnter2D()
    {
        colliding = true;
    }

    void OnTriggerExit2D()
    {
        colliding = false;
    }
}
