using UnityEngine;
using System.Collections;

public class DoorEntranceScript : MonoBehaviour {

    public GameObject[] checkArray;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        int i = 0;
        if (other.tag == "Player")
        {
            while (i < checkArray.Length)
            {
                checkArray[i].SetActive(true);
                i++;
            }
            Destroy(this);
        }
    }
}
