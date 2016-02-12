using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy Spawner.
/// 	Spawns everytime N seconds at defined spawnPoint.
/// 	When health reaches zero it will destroy itself.
/// 
/// Angel Diaz
/// </summary>

public class Enemy : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform spawnPoint;
	public int health = 100;
    
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	/// <summary>
	/// Update function, called every frame.
	/// </summary>
	void Update () {
		if (health == 0) {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Spawn an instance of the enemy.
	/// </summary>
    void Spawn ()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void TakeDamage (int damage) {
		health = health - damage;
		if (health < 0) {
			health = 0;
		}
	}
}
