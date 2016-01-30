using UnityEngine;
using System.Collections;

public class characterAnim : MonoBehaviour {
	
	
	public Animator anim;
	
	// Use this for initialization
	void Start () {
		
		anim = this.GetComponent<Animator>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			
			
			anim.SetBool("Dance", true);
				
				
		} else {
			anim.SetBool("Dance", false);
		}


		if (Input.GetKey (KeyCode.UpArrow)) {

			
			anim.SetBool("React", true);
			
			
		} else {
			anim.SetBool("React", false);
		}
		
	}
}
