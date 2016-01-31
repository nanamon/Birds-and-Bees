using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class readFile : MonoBehaviour
{
	protected FileInfo theSourceFile = null;
	protected StreamReader reader = null;
	protected string text = " "; // assigned to allow first line to be read below

    public List <string> actions;

    void Start() {
        theSourceFile = new FileInfo("myFile.txt");
        reader = theSourceFile.OpenText();

        while ((text = reader.ReadLine()) != null)
        {
            string textToSplit = (string)text;
            string[] split = textToSplit.Split(new string[] { "," }, StringSplitOptions.None);
            //Console.WriteLine(text);
            //print (text);

            for (int i = 0; i < split.Length; i++)
                actions.Add(split[i]);

        } 

        /*else
        {
            reader.Dispose();
            reader.Close();
            Destroy(this);
        }*/
    }
	
	void Update () {

	}
}