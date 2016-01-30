using UnityEngine;
using System.Collections;

public class spawnMoves : MonoBehaviour {

	GameObject arrow;
	GameObject[] moves;

	float speed = 0.05f;

	// Use this for initialization
	void Start () {
		spawnMove ();
	}
	
	// Update is called once per frame
	void Update () {
		//cycle through array to update positions
		arrow.transform.Translate(speed, 0, 0);
	}

	void spawnMove()
	{
		arrow = Instantiate (Resources.Load("arrow"), new Vector3(-10, 0, 0), Quaternion.identity)as GameObject;
	}
}
