using UnityEngine;
using System.Collections;

public class rotateCCW : MonoBehaviour {

    bool colliding = false;

    float startX;
    float startY;
    float endX;
    float endY;

    float startAngle;
    float endAngle;

    bool startHit = false;
    bool endHit = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.transform.position.z < -2.5f && this.gameObject.transform.position.z > -4.5f)
        {

            if(!startHit)
            {
                startX = Input.GetAxis("L_XAxis_" + this.gameObject.tag);
                startY = Input.GetAxis("L_YAxis_" + this.gameObject.tag);

                startAngle = Mathf.Atan2(startX, startY);

                if (startAngle * Mathf.Rad2Deg > 80)
                    startHit = true;
            }
            else
            {
                endX = Input.GetAxis("L_XAxis_" + this.gameObject.tag);
                endY = Input.GetAxis("L_YAxis_" + this.gameObject.tag);

                endAngle = Mathf.Atan2(endX, endY);

                if (endAngle * Mathf.Rad2Deg < -80)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
