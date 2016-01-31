using UnityEngine;
using System.Collections;

public class buttonCheck : MonoBehaviour {

    float score = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //print(this.gameObject.transform.position.x);

        if ( this.gameObject.transform.position.z < -2.5f && this.gameObject.transform.position.z > -4.5f )
        {
            if (Input.GetButtonDown(this.gameObject.name.Split("("[0])[0] + this.gameObject.tag))
            {
                //print(-6 - this.gameObject.transform.position.x);
                score = Mathf.Abs( -3 - this.gameObject.transform.position.x );
                print((0.5 - score) * 100);
                Destroy(this.gameObject);
            }
        }
	}
}
