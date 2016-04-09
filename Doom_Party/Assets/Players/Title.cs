using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKey) {
			Application.LoadLevel(1); // the scene to be loaded
		}
	
	}
		

}
	

