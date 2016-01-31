using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnActions : MonoBehaviour {

    GameObject newAction;
    List <GameObject> spawnedActions;

    int aCount = 0;

    float speed = -0.045f;
    float delay = 0f;

    readFile readFile;

	// Use this for initializatio
	void Start () {

        readFile = GetComponent<readFile>();

        spawnedActions = new List<GameObject>();

        delay = int.Parse(readFile.actions[0]);
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

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

                if (spawnedActions[i].transform.position.z < -4.5)
                {
                    Destroy(spawnedActions[i]);
                    spawnedActions.RemoveAt(i);
                    i--;
                }
            }
            else
            {
                spawnedActions.RemoveAt(i);
                i--;
            }
            
        }
    }

	void spawnAction()
	{
        newAction = Instantiate(Resources.Load(readFile.actions[aCount + 1]), new Vector3(1.3f, 0.36f, 1), Quaternion.Euler(90, -90, 0)) as GameObject;
        newAction.transform.localScale += new Vector3(-0.7f, 0, 0);
        newAction.tag = "1";

        spawnedActions.Add(newAction);

        newAction = Instantiate(Resources.Load(readFile.actions[aCount + 1]), new Vector3(-0.83f, 0.36f, 1), Quaternion.Euler(90, -90, 0)) as GameObject;
        newAction.transform.localScale += new Vector3(-0.7f, 0, 0);
        newAction.tag = "2";

        spawnedActions.Add(newAction);

        newAction = Instantiate(Resources.Load(readFile.actions[aCount + 1]), new Vector3(-3.01f, 0.36f, 1), Quaternion.Euler(90, -90, 0)) as GameObject;
        newAction.transform.localScale += new Vector3(-0.7f, 0, 0);
        newAction.tag = "3";

        spawnedActions.Add(newAction);

        newAction = Instantiate(Resources.Load(readFile.actions[aCount + 1]), new Vector3(-5.37f, 0.36f, 1), Quaternion.Euler(90, -90, 0)) as GameObject;
        newAction.transform.localScale += new Vector3(-0.7f, 0, 0);
        newAction.tag = "4";

        spawnedActions.Add(newAction);
    }
}
