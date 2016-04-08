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

	private int P1Health = 100;
	//private int P1Score = 0;

	// Use this for initialization
	void Start () {
		ReadyFire = false;
		Delay = 0;
		MyGlobalController.SharedInstance.P1Health = P1Health;
		Physics2D.IgnoreLayerCollision(8, 9);
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Crouch and Sprint Buttons
		if (Input.GetKey ("joystick 1 button 0") | Input.GetKey ("c")) { //change c to right mouse click
			MyGlobalController.SharedInstance.Mode = 1; //Crouch Button
		} else {
			if (Input.GetKey ("joystick 1 button 2")) {
				MyGlobalController.SharedInstance.Mode = 2; //Sprint Button
			} else {
				MyGlobalController.SharedInstance.Mode = 0; //default
			}
		}

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
		if (MyGlobalController.SharedInstance.Mode == 0) {
			transform.position = transform.position + Vector3.up * JoyY * 0.05f;
			transform.position = transform.position + Vector3.right * JoyX * 0.05f;
		} else {
			if (MyGlobalController.SharedInstance.Mode == 2) { //sprint
				transform.position = transform.position + Vector3.up * JoyY * 0.1f;
				transform.position = transform.position + Vector3.right * JoyX * 0.1f;
			}
		}

		if (JoyX > 0.01 | JoyX < -0.01 | JoyY > 0.01 | JoyY < -0.01){
			MyGlobalController.SharedInstance.JoyAngle = Jangle; // put the players angle into a global variable
		}

		// Rotate the player
		transform.localEulerAngles = new Vector3 (0,0,MyGlobalController.SharedInstance.JoyAngle/Mathf.PI*-180);

		// Get the players position for the camera
		MyGlobalController.SharedInstance.P1X = transform.position.x;
		MyGlobalController.SharedInstance.P1Y = transform.position.y;



		// delay the fire rate
		Delay = Delay + 1;

		if (Delay == 10) { // Delay time for the fire rate
			ReadyFire = true;
		}



		// Weapon is ready to fire
		if (ReadyFire == true) {

			//if (Input.GetKey ("joystick 1 button 0") | Input.GetKey ("space")){
			if (Input.GetAxis ("RTrigger J1") >= 0.5f | Input.GetKey ("space")){
				Instantiate (P1Bullet, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity);
				Instantiate (GunSound, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Delay = 0;
				ReadyFire = false;
			}


		} //ready to fire

	} // FixedUpdate






	//Test Damage
	void OnCollisionEnter2D(Collision2D col)
	{
		Physics2D.IgnoreLayerCollision(8, 9);

		
		if (col.gameObject.tag == "Enemy") {
			P1Health = P1Health - 10;
			MyGlobalController.SharedInstance.P1Health = P1Health;
			print (P1Health); // display the players numeric health amount
			if (P1Health <= 0) {
				//Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Destroy(gameObject);
			}

		}

        if (col.gameObject.tag == "Health")
        {
            P1Health += 10;
            print(P1Health);
            MyGlobalController.SharedInstance.P1Health = P1Health;
            if (P1Health > 100) P1Health = 100;
        }
	
	}





}








public class MyGlobalController {
	private static MyGlobalController instance = null;
	public static MyGlobalController SharedInstance {
		get {
			if (instance == null) {
				instance = new MyGlobalController ();
			}
			return instance;
		}
	}
	public float JoyAngle;
	public int P1Health;
	public float P1X;
	public float P1Y;
	public int Mode; //0 default, 1 crouch button, 2 sprint button
}

