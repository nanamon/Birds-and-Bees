using UnityEngine;
using System.Collections;

public class Tiling : MonoBehaviour {

	public float XScale;
	public float YScale;

	// Use this for initialization
	void Start () {

		this.transform.GetComponent<Renderer>().material.mainTextureScale = new Vector2(100 ,100 );
	
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
