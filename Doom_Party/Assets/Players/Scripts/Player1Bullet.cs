using UnityEngine;
using System.Collections;


public class Player1Bullet : MonoBehaviour {

	public GameObject BulletHit;
	public GameObject Blood;
	private float speedX;
	private float speedY;
	private float speed;
	private int deleteTime;
	private int num;
	private float angle;

	void Start() {
		speedX = 0;
		speedY = 0;
		speed = 0.5f; //bullet speed
		deleteTime = 0;

		if (MyGlobalController.SharedInstance.Mode == 0) {
			angle = MyGlobalController.SharedInstance.JoyAngle + Random.Range (-0.06f, 0.06f);
		} else {
			if (MyGlobalController.SharedInstance.Mode == 2) { //Sprint
				angle = MyGlobalController.SharedInstance.JoyAngle + Random.Range (-0.2f, 0.2f);
			} else { // Crouch
				angle = MyGlobalController.SharedInstance.JoyAngle;
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

		//starting distance from the player
		//transform.position = new Vector3 (transform.position.x + speedX*0.45f-5000.5f, transform.position.y + speedY*0.45f, 0);

		// Adjust the speed of the bullets
		speedX = speedX * speed;
		speedY = speedY * speed;

	}


	void FixedUpdate() {

		transform.position = new Vector3 (transform.position.x + speedX, transform.position.y + speedY, 0);

		deleteTime++;
		if (deleteTime > 100){
			Destroy(gameObject);
		}

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
			col.gameObject.GetComponent<EnemyAI>().damage(1);
			Destroy(gameObject);
		}
	}


}