using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public static bool player1dead;
    public static bool player2dead;
    public static bool player3dead;
    public static bool player4dead;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(player1dead && player2dead && player3dead && player4dead)
        {
            Application.LoadLevel("game over screen");
        }
	}
}
