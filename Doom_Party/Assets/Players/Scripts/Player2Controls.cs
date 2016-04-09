using UnityEngine;
using System.Collections;

public class Player2Controls : MonoBehaviour {

	public GameObject GunSound;
	public GameObject P2Bullet;
	public Rigidbody2D player;
    public AudioClip playerDamageClip;
    public AudioClip[] playerPowerUpClip;
    public AudioClip playerDeathClip;
    public AudioClip shootClip;
    private bool ReadyFire;
	private int Delay;
	private float Jangle = 0; // Joystick Angle
	private float JoyX = 0;   // Joystick X Axis
	private float JoyY = 0;   // Joystick Y Axis

	private int P2Health = 100;
	//private int P2Score = 0;

	// Use this for initialization
	void Start () {
		ReadyFire = false;
		Delay = 0;
		MyGlobalController2.SharedInstance.P2Health = P2Health;
		Physics2D.IgnoreLayerCollision(8, 9);
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Crouch and Sprint Buttons
		if (Input.GetKey ("joystick 2 button 0")) { //change c to right mouse click
			MyGlobalController2.SharedInstance.Mode = 1; //Crouch Button
		} else {
			if (Input.GetKey ("joystick 2 button 2")) {
				MyGlobalController2.SharedInstance.Mode = 2; //Sprint Button
			} else {
				MyGlobalController2.SharedInstance.Mode = 0; //default
			}
		}

		// Get The Players Input
		JoyX = Input.GetAxis ("Horizontal J2");
		JoyY = Input.GetAxis ("Vertical J2");
		Jangle = Mathf.Atan2 (JoyX, JoyY);

		// Move The Player
		if (MyGlobalController2.SharedInstance.Mode == 0) {
			transform.position = transform.position + Vector3.up * JoyY * 0.05f;
			transform.position = transform.position + Vector3.right * JoyX * 0.05f;
		} else {
			if (MyGlobalController2.SharedInstance.Mode == 2) { //sprint
				transform.position = transform.position + Vector3.up * JoyY * 0.1f;
				transform.position = transform.position + Vector3.right * JoyX * 0.1f;
			}
		}

		if (JoyX > 0.01 | JoyX < -0.01 | JoyY > 0.01 | JoyY < -0.01){
			MyGlobalController2.SharedInstance.JoyAngle = Jangle; // put the players angle into a global variable
		}

		// Rotate the player
		transform.localEulerAngles = new Vector3 (0,0,MyGlobalController2.SharedInstance.JoyAngle/Mathf.PI*-180);

		// Get the players position for the camera
		MyGlobalController2.SharedInstance.P2X = transform.position.x;
		MyGlobalController2.SharedInstance.P2Y = transform.position.y;



		// delay the fire rate
		Delay = Delay + 1;

		if (Delay == 10) { // Delay time for the fire rate
			ReadyFire = true;
		}



		// Weapon is ready to fire
		if (ReadyFire == true) {

			//if (Input.GetKey ("joystick 2 button 0")){
			if (Input.GetAxis ("RTrigger J2") >= 0.5f){
				Instantiate (P2Bullet, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity);
				Instantiate (GunSound, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
                GetComponent<AudioSource>().clip = shootClip;
                GetComponent<AudioSource>().Play();
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
			P2Health = P2Health - 1;
			MyGlobalController2.SharedInstance.P2Health = P2Health;
			//print (P2Health); // display the players numeric health amount
			if (P2Health <= 0) {
				//Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Destroy(gameObject);
			}
		}
		*/
        if (col.gameObject.tag == "Enemy")
        {
            P2Health = P2Health - 10;
            MyGlobalController2.SharedInstance.P2Health = P2Health;
            print(P2Health); // display the players numeric health amount
            GetComponent<AudioSource>().clip = playerDamageClip;
            GetComponent<AudioSource>().Play();
            if (P2Health <= 0)
            {
                //Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
            }

        }

        else if (col.gameObject.tag == "Health")
        {
            P2Health += 50;
            MyGlobalController2.SharedInstance.P2Health = P2Health;
            print(P2Health);
            if (P2Health > 100) P2Health = 100;
            Destroy(col.gameObject);
            GetComponent<AudioSource>().clip = playerPowerUpClip[Random.Range(0, playerPowerUpClip.Length - 1)];
            GetComponent<AudioSource>().Play();
        }
	
	}






}








public class MyGlobalController2 {
	private static MyGlobalController2 instance = null;
	public static MyGlobalController2 SharedInstance {
		get {
			if (instance == null) {
				instance = new MyGlobalController2 ();
			}
			return instance;
		}
	}
	public float JoyAngle;
	public int P2Health;
	public float P2X;
	public float P2Y;
	public int Mode; //0 default, 1 crouch button, 2 sprint button
}

