using UnityEngine;
using System.Collections;

public class Lifespan : MonoBehaviour {

	[SerializeField] private Timer m_Timer;

	// Use this for initialization
	void Start () {
		m_Timer.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Timer.complete){
			Destroy (gameObject);
		}
	
	}
}
