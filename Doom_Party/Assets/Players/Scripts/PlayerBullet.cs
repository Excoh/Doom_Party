using UnityEngine;
using System.Collections;


public class PlayerBullet : MonoBehaviour {
	
	[SerializeField] private GameObject BulletHit;
	[SerializeField] private GameObject Blood;
	[SerializeField] private Timer Lifespan;
	private float speedX;
	private float speedY;
	private float speed;
	private int deleteTime;
	private float angle;
	
	void Start() {
		speedX = 0;
		speedY = 0;
		speed = 0.5f; //bullet speed
		Lifespan.Reset();
		
		if (MyGlobalController4.SharedInstance.Mode == 0) {
			angle = MyGlobalController4.SharedInstance.JoyAngle + Random.Range (-0.06f, 0.06f);
		} else {
			if (MyGlobalController4.SharedInstance.Mode == 2) { //Sprint
				angle = MyGlobalController4.SharedInstance.JoyAngle + Random.Range (-0.2f, 0.2f);
			} else { // Crouch
				angle = MyGlobalController4.SharedInstance.JoyAngle;
			}
		}
		
		//starting distance from the player offset by slight angle
		speedX = Mathf.Sin(angle+0.13f);
		speedY = Mathf.Cos(angle+0.13f);
		transform.position = new Vector3 (transform.position.x + speedX*0.65f-5000.5f, transform.position.y + speedY*0.65f, 0);
		
		//Set velocity based on angle
		speedX = Mathf.Sin(angle);
		speedY = Mathf.Cos(angle);
		transform.localEulerAngles = new Vector3 (0,0,angle/Mathf.PI*-180);
		
		transform.localScale = new Vector3 (1, 3, 1);
		
		// Adjust the speed of the bullets
		speedX = speedX * speed;
		speedY = speedY * speed;
		
	}
	
	
	void FixedUpdate() {
		
		transform.position = new Vector3 (transform.position.x + speedX, transform.position.y + speedY, 0);
		
		if (Lifespan.complete)
			Destroy(gameObject);
		
	}
	
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Wall") {
			Instantiate (BulletHit, new Vector3 (transform.position.x+speedX/2.0f, transform.position.y+speedY/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Player") {
			Instantiate (Blood, new Vector3 (transform.position.x+speedX/2.0f, transform.position.y+speedY/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			Instantiate (Blood, new Vector3 (transform.position.x+speedX/2.0f, transform.position.y+speedY/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
	}
	
	
}