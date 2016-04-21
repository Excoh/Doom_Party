using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void tryAgain()
    {
        HealthManager.player1dead = false;
        HealthManager.player2dead = false;
        HealthManager.player3dead = false;
        HealthManager.player4dead = false;
        Application.LoadLevel("Joey's Level");
    }

    public void quit()
    {
        Application.Quit();
    }
}
