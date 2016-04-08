using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject[] enemySpawnerArray;

    // Update is called once per frame
    void Update()
    {
        bool enemySpawnersExists = false;
        for (int i = 0; i < enemySpawnerArray.Length; i++)
        {
            GameObject enemySpawner = enemySpawnerArray[i];
            if (enemySpawner != null)
            {
                enemySpawnersExists = true;
            }
        }

        if (!enemySpawnersExists)
        {
            Destroy(this.gameObject);
        }
    }
}
