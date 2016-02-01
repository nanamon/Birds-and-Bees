using UnityEngine;
using System.Collections;

public class PlayerLoader : MonoBehaviour {

	int amountofPlayers = 0;



	//prefabs
	public GameObject giraffePrefab, peacockPrefab, hippoPrefab, slothPrefab,ostrichPrefab; 
	//players
	GameObject[] player = new GameObject[4];
	GameObject animaltoWoo;
	bool[] selected = new bool[5];

    // Use this for initialization
    void Start()
    {


        //check the amount of players 
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.players[i] > 0)
                amountofPlayers++;
            //check which one didn't get chosen


        }




        /*Animal Index
		 * Giraffe: 1
		 * Peacock: 2
		 * Hippo: 3
		 * Sloth: 4
		 * Ostrich: 5*/

        //set selections to false
        for (int i = 0; i < amountofPlayers + 1; i++)
        {
            selected[i] = false;
        }

        for (int i = 0; i < amountofPlayers; i++)
        {

            if (GameManager.players[i] == 1)
            {
                player[i] = giraffePrefab;
                selected[0] = true;
            }
            else if (GameManager.players[i] == 2)
            {
                player[i] = peacockPrefab;
                selected[1] = true;
            }
            else if (GameManager.players[i] == 3)
            {
                player[i] = hippoPrefab;
                selected[2] = true;
            }
            else if (GameManager.players[i] == 4)
            {
                player[i] = slothPrefab;
                selected[3] = true;
            }
            else if (GameManager.players[i] == 5)
            {
                player[i] = ostrichPrefab;
                selected[4] = true;
            }

            player[i].tag = "Player" + (i + 1);
            //position the players according to their #
            Instantiate(player[i], new Vector3(1.47f - 2.3f * i, 0.318f, -3.6f), Quaternion.Euler(0, 20, 0));


            //

        }

        //check which player didnt get selected
        int selection = 0;
        for (int i = 0; i < amountofPlayers + 1; i++)
        {


            if (selected[i] == false)
            {
                Debug.Log("Animal to woo is " + (i + 1));
                selection = i;
                GameManager.seducedIndex = i;
            }

        }


        if (selection == 0)
            animaltoWoo = giraffePrefab;
        else if (selection == 1)
            animaltoWoo = peacockPrefab;
        else if (selection == 2)
            animaltoWoo = hippoPrefab;
        else if (selection == 3)
            animaltoWoo = slothPrefab;
        else if (selection == 4)
            animaltoWoo = ostrichPrefab;

        animaltoWoo.tag = "Woo";
        Instantiate(animaltoWoo, new Vector3(-2.5f, 0.3f, 0.5f), Quaternion.Euler(0, 160, 0));
    }

	
	
	
	// Update is called once per frame
	void Update () {




		if(this.GetComponent<AudioSource>().isPlaying == false)
		{
			Application.LoadLevel("End");
		}

	
	}
}
