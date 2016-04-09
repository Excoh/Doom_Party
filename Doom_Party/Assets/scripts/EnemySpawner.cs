using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy Spawner.
/// 	Spawns everytime N seconds at defined spawnPoint.
/// 	When health reaches zero it will destroy itself.
/// 
/// Angel Diaz
/// </summary>

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 3f;
	public int health = 6;
    public AudioClip spawnClip;
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
	}

	/// <summary>
	/// Spawn an instance of the enemy.
	/// </summary>
    void Spawn ()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
		enemy.GetComponent<EnemyAI>().parentSpawner = this;
        GetComponent<AudioSource>().clip = spawnClip;
        GetComponent<AudioSource>().Play();
    }

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void TakeDamage (int damage) {
		health = health - damage;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
