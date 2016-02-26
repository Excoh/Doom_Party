using UnityEngine;
using System.Collections;

public class Player1Controls : MonoBehaviour {

	public GameObject GunSound;
	public GameObject P1Bullet;
	public Rigidbody2D player;

	private bool ReadyFire;
	private int Delay;
	private float Jangle = 0; // Joystick Angle
	private float JoyX = 0;   // Joystick X Axis
	private float JoyY = 0;   // Joystick Y Axis
	private int num;

	// Use this for initialization
	void Start () {
		ReadyFire = false;
		Delay = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Get The Players Input
		JoyX = Input.GetAxis ("Horizontal J1");
		JoyY = Input.GetAxis ("Vertical J1");
		Jangle = Mathf.Atan2 (JoyX, JoyY);


		// Player input ASDW
		num = 0;
		if (Input.GetKey ("w"))
			num = num + 1;
		if (Input.GetKey ("s"))
			num = num + 2;
		if (Input.GetKey ("d"))
			num = num + 4;
		if (Input.GetKey ("a"))
			num = num + 8;

		switch (num) {
		case 1: // up
			JoyX = 0; JoyY = 1;
			Jangle = 0 * Mathf.PI / 180.0f;
			break;
		case 2: // down
			JoyX = 0; JoyY = -1;
			Jangle = 180 * Mathf.PI / 180.0f;
			break;
		case 4: // right
			JoyX = 1; JoyY = 0;
			Jangle = 90 * Mathf.PI / 180.0f;
			break;
		case 5: // up&right
			JoyX = 0.707106781f; JoyY = 0.707106781f;
			Jangle = 45 * Mathf.PI / 180.0f;
			break;
		case 6: // down&right
			JoyX = 0.707106781f; JoyY = -0.707106781f;
			Jangle = 135 * Mathf.PI / 180.0f;
			break;
		case 8: // left
			JoyX = -1; JoyY = 0;
			Jangle = 270 * Mathf.PI / 180.0f;
			break;
		case 9: // up&left
			JoyX = -0.707106781f; JoyY = 0.707106781f;
			Jangle = 315 * Mathf.PI / 180.0f;
			break;
		case 10: // down&left
			JoyX = -0.707106781f; JoyY = -0.707106781f;
			Jangle = 225 * Mathf.PI / 180.0f;
			break;
		default:

			break;

		}







		// Move The Player
		transform.position = transform.position + Vector3.up * JoyY * 0.1f;
		transform.position = transform.position + Vector3.right * JoyX * 0.1f;

		if (JoyX > 0.01 | JoyX < -0.01 | JoyY > 0.01 | JoyY < -0.01){
			MyGlobalAngleController.SharedInstance.JoyAngle = Jangle; // put the players angle into a global variable
		}






		// delay the fire rate
		Delay = Delay + 1;

		if (Delay == 10) { // Delay time for the fire rate
			ReadyFire = true;
		}



		// Weapon is ready to fire
		if (ReadyFire == true) {

			if (Input.GetKey ("joystick 1 button 0") | Input.GetKey ("space")){
				Instantiate (P1Bullet, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity);
				Instantiate (GunSound, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Delay = 0;
				ReadyFire = false;
			}


		} //ready to fire

	} // FixedUpdate

}








public class MyGlobalAngleController {
	private static MyGlobalAngleController instance = null;
	public static MyGlobalAngleController SharedInstance {
		get {
			if (instance == null) {
				instance = new MyGlobalAngleController ();
			}
			return instance;
		}
	}
	public float JoyAngle;
}

