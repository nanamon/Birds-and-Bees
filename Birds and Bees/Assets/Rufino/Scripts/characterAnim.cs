using UnityEngine;
using System.Collections;

public class characterAnim : MonoBehaviour {
	
	
	public Animator anim;
	string up,aBTN,right,left, down;
	bool dead = false;

	
	// Use this for initialization
	void Start () {
		
		anim = this.GetComponent<Animator>();

		if (this.tag == "Player1") {
			up = "B_1";
			aBTN =  "A_1";
		} else if (this.tag == "Player2") {
			up = "B_2";
			aBTN = "A_2";
		} else if (this.tag == "Player3") {
			up = "B_3";
			aBTN = "A_3";
		}
		else if (this.tag == "Player4") {
			up = "B_4";
			aBTN = "A_4";
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {

		if (this.tag == "Woo") {
		//donothing
		}
		else
		{
			if (Input.GetButtonDown(up)) {
				
				

				anim.SetBool("Dance", true);
					
					
			} else {
				anim.SetBool("Dance", false);
			}


		



			if (Input.GetButtonDown(aBTN)) { 

				
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
