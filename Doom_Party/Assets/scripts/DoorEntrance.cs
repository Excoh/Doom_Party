using UnityEngine;
using System.Collections;

public class DoorEntrance : MonoBehaviour {

    public GameObject[] activationArray;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
			for (int i = 0; i < activationArray.Length; i++)
			{
				activationArray[i].SetActive(true);
			}
            Destroy(gameObject);
        }
    }
}
