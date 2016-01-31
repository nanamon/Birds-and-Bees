using UnityEngine;
using System.Collections;

public class characterAnim : MonoBehaviour {
	
	
	public Animator anim;
	string up,down,right,left;
	bool dead = false;

	
	// Use this for initialization
	void Start () {
		
		anim = this.GetComponent<Animator>();

		if (this.tag == "Player1") {
			up = "UpArrow";
			down = "DownArrow";
		} else if (this.tag == "Player2") {
			up = "W";
			down = "S";
		} else if (this.tag == "Player3") {
			up = "U";
			down = "J";
		}
		else if (this.tag == "Player4") {
			up = "O";
			down = "L";
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {

		if (this.tag == "Woo") {
		//donothing
		}
		else
		{
			if (Input.GetKey ((KeyCode) System.Enum.Parse(typeof(KeyCode), down))) {
				
				

				anim.SetBool("Dance", true);
					
					
			} else {
				anim.SetBool("Dance", false);
			}


		



			if (Input.GetKey ((KeyCode) System.Enum.Parse(typeof(KeyCode), up))) {

				
				anim.SetBool("React", true);
				
				
			} else {
				anim.SetBool("React", false);

			}


		
			if (dead) {
				this.transform.position = Vector3.MoveTowards(this.transform.position,new Vector3(0,0, - 10), 0.01f);

			}
		}

		
	}
}
