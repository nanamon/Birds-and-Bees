using UnityEngine;
using System.Collections;

public class oneButton : MonoBehaviour {

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
                score = Mathf.Abs( -3 - this.gameObject.transform.position.z );
                GameManager.score[int.Parse(this.gameObject.tag) - 1] =  (0.5f - score) * 100f;
                print((0.5f - score) * 100f);
                Destroy(this.gameObject);
            }
        }
	}
}
