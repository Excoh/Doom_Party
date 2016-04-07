using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject[] enemySpawnerArray;
    public bool enemySpawnersExists;
    public int length;

	// Use this for initialization
	void Start () 
    {
		enemySpawnersExists = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
		enemySpawnersExists = (GameObject.Find("Enemy Spawaner") != null);

        if (!enemySpawnersExists)
        {
			Destroy(this.gameObject);
		}
    }
}
