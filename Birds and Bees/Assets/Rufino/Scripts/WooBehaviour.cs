using UnityEngine;
using System.Collections;

public class WooBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//winning coordinates

		int whoisWinning = Maximum (GameManager.score);

		GameManager.winnerIndex = (whoisWinning );

		float coordinatetoGo = 0;

		coordinatetoGo = 1.47f - 2.3f * whoisWinning;


		if (this.tag == "Woo") 
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(coordinatetoGo, this.transform.position.y,this.transform.position.z), 0.01f);
		}
	
	}

	int Maximum (float[] myArray)
	{
		int winner = 0;
		float max = myArray [0];

		for (int i = 1; i < myArray.Length; i++) {
			if(myArray[i] > max)
			{
				max = myArray[i];
				winner = i;
			}
		}

		return winner;

	}


			                       


}
