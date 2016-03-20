using UnityEngine;
using System.Collections;

public class Player3Health : MonoBehaviour {

	private int num;
	private Color32 HColor;

	// Use this for initialization
	void Start () {
		HColor.a = 255;
		HColor.r = 0;
		HColor.g = 255;
		HColor.b = 0;
		GetComponent<SpriteRenderer>().color = Color.red;
	}

	// Update is called once per frame
	void Update () {

		//Position the HealthBar Above the players head
		transform.localPosition = new Vector3 (MyGlobalController3.SharedInstance.P3X,MyGlobalController3.SharedInstance.P3Y+0.5f,0);

		//Reduce the size of the health bar based on the amount of health
		transform.localScale = new Vector3 (MyGlobalController3.SharedInstance.P3Health, 1, 1);

		//Change Color Based on the amount of Health : 100% = Green,   50% = Yellow,   0% = Red
		//Red
		num = (int)((-MyGlobalController3.SharedInstance.P3Health + 100) * 5.1f);
		if (num > 255) { num = 255; }
		HColor.r = (byte)num;

		//Green
		num = (int)((MyGlobalController3.SharedInstance.P3Health) * 5.1f);
		if (num > 255) { num = 255; }
		if (num < 0) { num = 0; }
		HColor.g = (byte)num;

		this.GetComponent<SpriteRenderer> ().color = HColor;

	}
}
