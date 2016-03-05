using UnityEngine;
using System.Collections;

public class Player4Controls : MonoBehaviour {

	public GameObject GunSound;
	public GameObject P4Bullet;
	public Rigidbody2D player;

	private bool ReadyFire;
	private int Delay;
	private float Jangle = 0; // Joystick Angle
	private float JoyX = 0;   // Joystick X Axis
	private float JoyY = 0;   // Joystick Y Axis

	// Use this for initialization
	void Start () {
		ReadyFire = false;
		Delay = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Get The Players Input
		JoyX = Input.GetAxis ("Horizontal J4");
		JoyY = Input.GetAxis ("Vertical J4");
		Jangle = Mathf.Atan2 (JoyX, JoyY);

		// Move The Player
		transform.position = transform.position + Vector3.up * JoyY * 0.1f;
		transform.position = transform.position + Vector3.right * JoyX * 0.1f;

		if (JoyX > 0.01 | JoyX < -0.01 | JoyY > 0.01 | JoyY < -0.01){
			MyGlobalAngleController4.SharedInstance.JoyAngle = Jangle; // put the players angle into a global variable
		}



		// delay the fire rate
		Delay = Delay + 1;

		if (Delay == 10) { // Delay time for the fire rate
			ReadyFire = true;
		}



		// Weapon is ready to fire
		if (ReadyFire == true) {

			if (Input.GetKey ("joystick 4 button 0")){
				Instantiate (P4Bullet, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity);
				Instantiate (GunSound, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Delay = 0;
				ReadyFire = false;
			}


		} //ready to fire

	} // FixedUpdate

}








public class MyGlobalAngleController4 {
	private static MyGlobalAngleController4 instance = null;
	public static MyGlobalAngleController4 SharedInstance {
		get {
			if (instance == null) {
				instance = new MyGlobalAngleController4 ();
			}
			return instance;
		}
	}
	public float JoyAngle;
}

