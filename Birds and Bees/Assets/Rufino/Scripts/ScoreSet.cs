using UnityEngine;
using System.Collections;

public class ScoreSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	


	}

	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < 4 ; i ++)
		{
			GameManager.score[i] = Mathf.Round(GameManager.score[i]);
		}
	
		if(this.gameObject.name == "score1")
			this.GetComponent<TextMesh>().text = GameManager.score[0].ToString();
		if(this.gameObject.name == "score2")
			this.GetComponent<TextMesh>().text = GameManager.score[1].ToString();
		if(this.gameObject.name == "score3")
			this.GetComponent<TextMesh>().text = GameManager.score[2].ToString();
		if(this.gameObject.name == "score4")
			this.GetComponent<TextMesh>().text = GameManager.score[3].ToString();
	}
}
