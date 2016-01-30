using UnityEngine;
using System.Collections;

public class rotateCheck : MonoBehaviour {

    bool colliding = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
