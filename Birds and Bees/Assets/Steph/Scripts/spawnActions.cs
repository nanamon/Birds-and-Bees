using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnActions : MonoBehaviour {

    GameObject newAction;
    List <GameObject> spawnedActions;

    int aCount = 0;

    float speed = -0.05f;
    float delay = 0f;

    readFile readFile;

	// Use this for initialization
	void Start () {

        readFile = GetComponent<readFile>();

        spawnedActions = new List<GameObject>();

        delay = int.Parse(readFile.actions[0]);
        
    }
	
	// Update is called once per frame
	void Update () {

        if(aCount + 1 < readFile.actions.Count)
        {
            delay -= 1;

            if( delay < 0)
            {
                spawnAction();

                aCount += 2;

                if(aCount + 1 < readFile.actions.Count)
                    delay = int.Parse(readFile.actions[aCount]);
            }
        }

        for (int i = 0; i < spawnedActions.Count; i++)
        {
            if(spawnedActions[i] != null)
            {
                spawnedActions[i].transform.Translate(speed, 0, 0);

                if (spawnedActions[i].transform.position.x < -11)
                {
                    Destroy(spawnedActions[i]);
                    spawnedActions.RemoveAt(i);
                }
            }
            else
            {
                spawnedActions.RemoveAt(i);
            }
            
        }
    }

	void spawnAction()
	{
        newAction = Instantiate(Resources.Load(readFile.actions[aCount + 1]), new Vector3(11, 0, 0), Quaternion.identity) as GameObject;

        spawnedActions.Add(newAction);
	}
}
