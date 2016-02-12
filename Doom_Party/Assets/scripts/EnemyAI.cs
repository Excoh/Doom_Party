using UnityEngine;
using System.Collections;

/// <summary>
/// Defines the enemy ai behavior.
/// 
/// Angel Diaz
/// </summary>

public class EnemyAI : MonoBehaviour {

	private Transform myTransform;
	int speed = 1;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake () {
		myTransform = transform;
	}

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// TODO get rid of this, just here to temporarily make enemies move as they spawn.
		myTransform.position += myTransform.up * speed * Time.deltaTime;
	}
}
