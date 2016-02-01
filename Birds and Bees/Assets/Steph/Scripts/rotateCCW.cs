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
	float score = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.transform.position.z < -2.5f && this.gameObject.transform.position.z > -4.5f)
        {

            if(!startHit)
            {
                startX = Input.GetAxis(this.gameObject.name.Split("-"[0])[0] + "XAxis_" + this.gameObject.tag);
                startY = Input.GetAxis(this.gameObject.name.Split("-"[0])[0] + "YAxis_" + this.gameObject.tag);

                startAngle = Mathf.Atan2(startX, startY);

                if (startAngle * Mathf.Rad2Deg > 70)
                    startHit = true;
            }
            else
            {
                endX = Input.GetAxis(this.gameObject.name.Split("-"[0])[0] + "XAxis_" + this.gameObject.tag);
                endY = Input.GetAxis(this.gameObject.name.Split("-"[0])[0] + "YAxis_" + this.gameObject.tag);

                endAngle = Mathf.Atan2(endX, endY);

                if (endAngle * Mathf.Rad2Deg < -70)
                {

					score = Mathf.Abs( -3 - this.gameObject.transform.position.z );
					GameManager.score[int.Parse(this.gameObject.tag) - 1] +=  (0.5f - score) * 100f;

                    Destroy(this.gameObject);
                }
            }
        }
    }
}
