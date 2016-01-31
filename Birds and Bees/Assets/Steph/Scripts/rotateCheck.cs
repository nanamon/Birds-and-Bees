using UnityEngine;
using System.Collections;

public class rotateCheck : MonoBehaviour {

    bool colliding = false;

    float startX;
    float startY;
    float endX;
    float endY;

    float startAngle;
    float endAngle;

    float dist;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.transform.position.z < -2.5f && this.gameObject.transform.position.z > -4.5f)
        {
            startX = Input.GetAxis("L_XAxis_" + this.gameObject.tag);
            startY = Input.GetAxis("L_YAxis_" + this.gameObject.tag);

            startAngle = (Mathf.Atan2(startX, startY)) + 3.14159f;
        }
        else if( this.gameObject.transform.position.z < -2.5)
        {
            endX = Input.GetAxis("L_XAxis_" + this.gameObject.tag);
            endY = Input.GetAxis("L_YAxis_" + this.gameObject.tag);

            endAngle = (Mathf.Atan2(endX, endY)) + 3.14159f;

            dist = (startAngle - endAngle) * Mathf.Rad2Deg;

            if (dist > 30f)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
