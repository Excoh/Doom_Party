using UnityEngine;
using System.Collections;

public class Player4Controls : MonoBehaviour {

	public GameObject GunSound;
	public GameObject P4Bullet;
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

	private int P4Health = 100;
	//private int P4Score = 0;

	// Use this for initialization
	void Start () {
		ReadyFire = false;
		Delay = 0;
		MyGlobalController4.SharedInstance.P4Health = P4Health;
		Physics2D.IgnoreLayerCollision(8, 9);
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Crouch and Sprint Buttons
		if (Input.GetKey ("joystick 4 button 0")) { //change c to right mouse click
			MyGlobalController4.SharedInstance.Mode = 1; //Crouch Button
		} else {
			if (Input.GetKey ("joystick 4 button 2")) {
				MyGlobalController4.SharedInstance.Mode = 2; //Sprint Button
			} else {
				MyGlobalController4.SharedInstance.Mode = 0; //default
			}
		}

		// Get The Players Input
		JoyX = Input.GetAxis ("Horizontal J4");
		JoyY = Input.GetAxis ("Vertical J4");
		Jangle = Mathf.Atan2 (JoyX, JoyY);

		// Move The Player
		if (MyGlobalController4.SharedInstance.Mode == 0) {
			transform.position = transform.position + Vector3.up * JoyY * 0.05f;
			transform.position = transform.position + Vector3.right * JoyX * 0.05f;
		} else {
			if (MyGlobalController4.SharedInstance.Mode == 2) { //sprint
				transform.position = transform.position + Vector3.up * JoyY * 0.1f;
				transform.position = transform.position + Vector3.right * JoyX * 0.1f;
			}
		}

		if (JoyX > 0.01 | JoyX < -0.01 | JoyY > 0.01 | JoyY < -0.01){
			MyGlobalController4.SharedInstance.JoyAngle = Jangle; // put the players angle into a global variable
		}

		// Rotate the player
		transform.localEulerAngles = new Vector3 (0,0,MyGlobalController4.SharedInstance.JoyAngle/Mathf.PI*-180);

		// Get the players position for the camera
		MyGlobalController4.SharedInstance.P4X = transform.position.x;
		MyGlobalController4.SharedInstance.P4Y = transform.position.y;


		// delay the fire rate
		Delay = Delay + 1;

		if (Delay == 10) { // Delay time for the fire rate
			ReadyFire = true;
		}



		// Weapon is ready to fire
		if (ReadyFire == true) {

			//if (Input.GetKey ("joystick 4 button 0")){
			if (Input.GetAxis ("RTrigger J4") >= 0.5f){
				Instantiate (P4Bullet, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity);
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
		/*
		if (col.gameObject.tag == "Bullet") {
			P4Health = P4Health - 1;
			MyGlobalController4.SharedInstance.P4Health = P4Health;
			//print (P4Health); // display the players numeric health amount
			if (P4Health <= 0) {
				//Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Destroy(gameObject);
			}
		}
		*/
        if (col.gameObject.tag == "Enemy")
        {
            P4Health = P4Health - 10;
            MyGlobalController4.SharedInstance.P4Health = P4Health;
            print(P4Health); // display the players numeric health amount
            GetComponent<AudioSource>().clip = playerDamageClip;
            GetComponent<AudioSource>().Play();
            if (P4Health <= 0)
            {
                //Instantiate (PlayerDeath, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
            }

        }
        else if (col.gameObject.tag == "Health")
        {
            P4Health += 50;
            MyGlobalController4.SharedInstance.P4Health = P4Health;
            print(P4Health);
            if (P4Health > 100) P4Health = 100;
            Destroy(col.gameObject);
            GetComponent<AudioSource>().clip = playerPowerUpClip[Random.Range(0, playerPowerUpClip.Length - 1)];
            GetComponent<AudioSource>().Play();
        }
	}







}








public class MyGlobalController4 {
	private static MyGlobalController4 instance = null;
	public static MyGlobalController4 SharedInstance {
		get {
			if (instance == null) {
				instance = new MyGlobalController4 ();
			}
			return instance;
		}
	}
	public float JoyAngle;
	public int P4Health;
	public float P4X;
	public float P4Y;
	public int Mode; //0 default, 1 crouch button, 2 sprint button
}

