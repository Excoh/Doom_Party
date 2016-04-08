using UnityEngine;
using System.Collections;

public class Player3Controls : MonoBehaviour {

	public GameObject GunSound;
	public GameObject P3Bullet;
	public Rigidbody2D player;

	private bool ReadyFire;
	private int Delay;
	private float Jangle = 0; // Joystick Angle
	private float JoyX = 0;   // Joystick X Axis
	private float JoyY = 0;   // Joystick Y Axis

	private int P3Health = 100;
	//private int P3Score = 0;

	// Use this for initialization
	void Start () {
		ReadyFire = false;
		Delay = 0;
		MyGlobalController3.SharedInstance.P3Health = P3Health;
		Physics2D.IgnoreLayerCollision(8, 9);
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Crouch and Sprint Buttons
		if (Input.GetKey ("joystick 3 button 0")) { //change c to right mouse click
			MyGlobalController3.SharedInstance.Mode = 1; //Crouch Button
		} else {
			if (Input.GetKey ("joystick 3 button 2")) {
				MyGlobalController3.SharedInstance.Mode = 2; //Sprint Button
			} else {
				MyGlobalController3.SharedInstance.Mode = 0; //default
			}
		}

		// Get The Players Input
		JoyX = Input.GetAxis ("Horizontal J3");
		JoyY = Input.GetAxis ("Vertical J3");
		Jangle = Mathf.Atan2 (JoyX, JoyY);

		// Move The Player
		if (MyGlobalController3.SharedInstance.Mode == 0) {
			transform.position = transform.position + Vector3.up * JoyY * 0.05f;
			transform.position = transform.position + Vector3.right * JoyX * 0.05f;
		} else {
			if (MyGlobalController3.SharedInstance.Mode == 2) { //sprint
				transform.position = transform.position + Vector3.up * JoyY * 0.1f;
				transform.position = transform.position + Vector3.right * JoyX * 0.1f;
			}
		}

		if (JoyX > 0.01 | JoyX < -0.01 | JoyY > 0.01 | JoyY < -0.01){
			MyGlobalController3.SharedInstance.JoyAngle = Jangle; // put the players angle into a global variable
		}

		// Rotate the player
		transform.localEulerAngles = new Vector3 (0,0,MyGlobalController3.SharedInstance.JoyAngle/Mathf.PI*-180);

		// Get the players position for the camera
		MyGlobalController3.SharedInstance.P3X = transform.position.x;
		MyGlobalController3.SharedInstance.P3Y = transform.position.y;


		// delay the fire rate
		Delay = Delay + 1;

		if (Delay == 10) { // Delay time for the fire rate
			ReadyFire = true;
		}



		// Weapon is ready to fire
		if (ReadyFire == true) {

			//if (Input.GetKey ("joystick 3 button 0")){
			if (Input.GetAxis ("RTrigger J3") >= 0.5f){
				Instantiate (P3Bullet, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity);
				Instantiate (GunSound, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Delay = 0;
				ReadyFire = false;
			}


		} //ready to fire

	} // FixedUpdate






	//Test Damage
	void OnCollisionEnter2D(Collision2D col)
	{
		//Physics2D.IgnoreLayerCollision(8, 9);
		/*
		if (col.gameObject.tag == "Bullet") {
			P3Health = P3Health - 1;
			MyGlobalController3.SharedInstance.P3Health = P3Health;
			//print (P3Health); // display the players numeric health amount
			if (P3Health <= 0) {
				//Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Destroy(gameObject);
			}
		}
		*/
        if (col.gameObject.tag == "Enemy")
        {
            P3Health = P3Health - 10;
            MyGlobalController3.SharedInstance.P3Health = P3Health;
            print(P3Health); // display the players numeric health amount
            if (P3Health <= 0)
            {
                //Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
            }

        }

        else if (col.gameObject.tag == "Health")
        {
            P3Health += 50;
            MyGlobalController3.SharedInstance.P3Health = P3Health;
            print(P3Health);
            if (P3Health > 100) P3Health = 100;
            Destroy(col.gameObject);
        }
	}







}








public class MyGlobalController3 {
	private static MyGlobalController3 instance = null;
	public static MyGlobalController3 SharedInstance {
		get {
			if (instance == null) {
				instance = new MyGlobalController3 ();
			}
			return instance;
		}
	}
	public float JoyAngle;
	public int P3Health;
	public float P3X;
	public float P3Y;
	public int Mode; //0 default, 1 crouch button, 2 sprint button
}

