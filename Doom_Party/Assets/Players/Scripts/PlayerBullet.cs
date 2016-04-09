using UnityEngine;
using System.Collections;


public class PlayerBullet : MonoBehaviour {
	
	[SerializeField] private GameObject BulletHit;
	[SerializeField] private GameObject Blood;
	private Vector2 Velocity;
	
	public Vector2 velocity { get { return Velocity;} set { Velocity = value; } }
	
	void FixedUpdate() {
		
		transform.position = new Vector3 (transform.position.x + Velocity.x, transform.position.x + Velocity.y, 0.0f);
		
	}
	
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Wall") {
			Instantiate (BulletHit, new Vector3 (transform.position.x+Velocity.x/2.0f, transform.position.y+Velocity.y/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Player") {
			Instantiate (Blood, new Vector3 (transform.position.x+Velocity.x/2.0f, transform.position.y+Velocity.y/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			Instantiate (Blood, new Vector3 (transform.position.x+Velocity.x/2.0f, transform.position.y+Velocity.y/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
	}
	
	
}