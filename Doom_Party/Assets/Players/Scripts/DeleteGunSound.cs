using UnityEngine;
using System.Collections;

public class DeleteGunSound : MonoBehaviour {

	private int deleteTime;

	// Use this for initialization
	void Start () {
		deleteTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

		deleteTime++;
		if (deleteTime > 100){
			Destroy (gameObject);
		}
	
	}
}
