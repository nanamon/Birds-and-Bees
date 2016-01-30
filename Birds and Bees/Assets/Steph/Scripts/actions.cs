using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class actions : MonoBehaviour {

    string[] actionsList = new string[] { "arrow", "5", "arrow", "60", "arrow", "40" };
    GameObject newAction;
    List <GameObject> spawnedActions;

    int aCount = 0;
    int dCount = 1;

    float speed = 0.05f;
    float delay = 0f;

	// Use this for initialization
	void Start () {
        spawnedActions = new List<GameObject>();

        delay = System.Int32.Parse(actionsList[aCount + 1]);
        
    }
	
	// Update is called once per frame
	void Update () {

        if(aCount + 1 < actionsList.Length)
        {
            delay -= 1;

            if( delay < 0)
            {
                spawnMove();

                aCount += 2;

                if(aCount < actionsList.Length)
                    delay = System.Int32.Parse(actionsList[aCount + 1]);
            }
        }

        for (int i = 0; i < spawnedActions.Count; i++)
        {
            spawnedActions[i].transform.Translate(speed, 0, 0);

            if( spawnedActions[i].transform.position.x > 11)
            {
                Destroy(spawnedActions[i]);
                spawnedActions.RemoveAt(i);
            }
        }
    }

	void spawnMove()
	{
        newAction = Instantiate(Resources.Load(actionsList[aCount]), new Vector3(-10, 0, 0), Quaternion.identity) as GameObject;

        spawnedActions.Add(newAction);
	}
}
