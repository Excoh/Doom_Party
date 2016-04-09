using UnityEngine;
using System.Collections;

public class DoorEntrance : MonoBehaviour {

    public GameObject[] spawnerActivationArray;
    public GameObject[] doorActivationArray;
    public bool player1Stepped = false;
    public bool player2Stepped = false;
    public bool player3Stepped = false;
    public bool player4Stepped = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (other.name.Equals("Player1"))
            {
                player1Stepped = true;
            }
            if (other.name.Equals("Player2"))
            {
                player2Stepped = true;
            }
            if (other.name.Equals("Player3"))
            {
                player3Stepped = true;
            }
            if (other.name.Equals("Player4"))
            {
                player4Stepped = true;
            }
            else if ((player1Stepped == true) && (player2Stepped == true) && (player3Stepped == true) && (player4Stepped == true))
            {
                for (int i = 0; i < spawnerActivationArray.Length; i++)
                {
                    spawnerActivationArray[i].SetActive(true);
                }
                for (int i = 0; i < doorActivationArray.Length; i++)
                {
                    doorActivationArray[i].SetActive(true);
                }
                Destroy(gameObject);
            }
        }
    }
}
