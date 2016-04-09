using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	[SerializeField] private GameObject GunSound;
	[SerializeField] private GameObject BulletPrefab;
	[SerializeField] private Rigidbody2D player;
	[SerializeField] private Timer ShootingTimer;
	// The Timer class is like what you were doing with the Delay variable, except it relies on actual time instead of Update calls. And it's easier to manipulate. -Alex.
	[SerializeField] private string CrouchButton, SprintButton;
	[SerializeField] private string HorizontalJoystick, VerticalJoystick;
	[SerializeField] private string FireButton;
	[SerializeField] private float Speed = 0.05f;
	[SerializeField] private int Health = 100;
	[SerializeField] private float BulletSpeed = 0.5f;
	// The [SerializeField] tag exposes a field in the inspector without making it public to other classes. -Alex
	
	private bool ReadyFire { get { return ShootingTimer.complete; } }
//	private float Jangle = 0; // Joystick Angle
//	private float JoyX = 0;   // Joystick X Axis
//	private float JoyY = 0;   // Joystick Y Axis
//	private bool Crouching = false;
//	private bool Sprinting = false;
	
	//private int Score = 0;
	
	void Start () {
		ShootingTimer.Reset();
		Physics2D.IgnoreLayerCollision(8, 9);
	}
	
	void FixedUpdate () {
		bool Crouching = false, Sprinting = false;
		// Crouch and Sprint Buttons
		if (Input.GetKey (CrouchButton)) { //change c to right mouse click
			Crouching = true; Sprinting = false; //Crouch Button
		} else {
			if (Input.GetKey (SprintButton)) {
				Crouching = false; Sprinting = true; //Sprint Button
			} //else {
				//Crouching = false; Sprinting = false; //default
			//}
		}
		
		// Get The Players Input
		float JoyX = Input.GetAxis (HorizontalJoystick);
		float JoyY = Input.GetAxis (VerticalJoystick);
		float Jangle = Mathf.Atan2 (JoyX, JoyY);
		// I'm gonna try putting these in a local variable, since you don't actually reference them outside of this method. -Alex
		
		// Move The Player
		if (Crouching == false && Sprinting == false)
			transform.position = transform.position + new Vector3(JoyX, JoyY, 0) * Speed;
		else if (Sprinting == true)
			transform.position = transform.position + new Vector3(JoyX, JoyY, 0) * Speed * 2.0f;
		
		
		// Rotate the player
		transform.localEulerAngles = new Vector3 (0,0,Jangle/Mathf.PI*-180);
		// Euler angles? That's weird, but I guess it works. -Alex
		
		// Weapon is ready to fire
		if (ReadyFire) {
			//if (Input.GetKey ("joystick 4 button 0")){
			if (Input.GetAxis (FireButton) >= 0.5f){
				PlayerBullet bullet = Instantiate (BulletPrefab, new Vector3 (transform.position.x + 5000.5f, transform.position.y, 0), Quaternion.identity) as PlayerBullet;
				float bulletAngle = Jangle;
				if (Crouching == false)
					if (Sprinting == true)
						bulletAngle += Random.Range (-0.2f, 0.2f);
					else
						bulletAngle += Random.Range (-0.06f, 0.06f);
				bullet.velocity = new Vector2(Mathf.Sin(bulletAngle), Mathf.Cos(bulletAngle)) * BulletSpeed;
				Instantiate (GunSound, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				ShootingTimer.Reset();
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
	}	
}