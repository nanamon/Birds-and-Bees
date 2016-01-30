using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class detectInput : MonoBehaviour {

    public List<string> inputList;

    string player = "1";

    public string current = "";

	// Use this for initialization
	void Start () {
        inputList = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {

        //getInputs();

	}

    public void getInputs()
    {
        if (Input.GetButtonDown("A_" + player))
        {
            print("yaaas");
        }
    }
}
