using UnityEngine;
using System.Collections;

public class DoorEntrance : MonoBehaviour {

    public GameObject[] spawnerActivationArray;
    public GameObject[] doorActivationArray;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
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
