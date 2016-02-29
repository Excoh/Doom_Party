using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public GameObject[] enemySpawnerArray;
    public bool enemyExists;
    public int length;

	// Use this for initialization
	void Start () 
    {
        enemyExists = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        enemyExists = (GameObject.Find("Enemy Spawaner") != null);

        if (enemyExists)
        {
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
}
