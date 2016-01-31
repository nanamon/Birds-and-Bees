using UnityEngine;
using System.Collections;

public class buttonCheck : MonoBehaviour {

    float score = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if ( this.gameObject.transform.position.x < -5.5f && this.gameObject.transform.position.x > -6.5f )
        {   
            if (Input.GetButtonDown(this.tag + "1"))
            {
                //print(-6 - this.gameObject.transform.position.x);
                score = Mathf.Abs( -6 - this.gameObject.transform.position.x );
                print((0.5 - score) * 100);
                Destroy(this.gameObject);
            }
        }
	}
}
