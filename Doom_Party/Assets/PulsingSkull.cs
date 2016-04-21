using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PulsingSkull : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Image>().color = new Color(1, Mathf.Sin(Time.time * 1.9f * Mathf.PI), Mathf.Sin(Time.time * 1.9f * Mathf.PI));

    }
}
