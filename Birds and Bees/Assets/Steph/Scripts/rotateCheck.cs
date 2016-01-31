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

        if (colliding)
        {
            startX = Input.GetAxis("L_XAxis_1");
            startY = Input.GetAxis("L_YAxis_1");

            startAngle = (Mathf.Atan2(startX, startY)) + 3.14159f;

            if (startAngle != 180)
            {
                colliding = false;
            }
            else
                print("derp");
        }

    }

    void OnTriggerEnter2D()
    {
        colliding = true;
    }

    void OnTriggerExit2D()
    {
        endX = Input.GetAxis("L_XAxis_1");
        endY = Input.GetAxis("L_YAxis_1");

        endAngle = (Mathf.Atan2(endX, endY)) + 3.14159f;

        dist = (startAngle - endAngle) * Mathf.Rad2Deg;

        if( dist > 50f )
        {
            Destroy(this.gameObject);
        }
    }
}
