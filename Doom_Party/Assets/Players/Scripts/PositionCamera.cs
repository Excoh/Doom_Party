using UnityEngine;
using System.Collections;

public class PositionCamera : MonoBehaviour {

	private Vector3 temp;
	private float distance;
	private float greatestDistance;
	private float CenterP1;
	private float CenterP2;


	// Use this for initialization
	void Start () {
		temp = transform.position;
		temp.x = 0;
		temp.y = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//Overly complicated Code
		/*

		greatestDistance = Mathf.Sqrt (
			(MyGlobalController.SharedInstance.P1X - MyGlobalController2.SharedInstance.P2X)
			* (MyGlobalController.SharedInstance.P1X - MyGlobalController2.SharedInstance.P2X)
			+
			(MyGlobalController.SharedInstance.P1Y - MyGlobalController2.SharedInstance.P2Y)
			* (MyGlobalController.SharedInstance.P1Y - MyGlobalController2.SharedInstance.P2Y)
		);

		//if (distance > greatestDistance) {
			//greatestDistance = distance;
			CenterP1 = 1;
			CenterP2 = 2;
		//}

		distance = Mathf.Sqrt (
			(MyGlobalController.SharedInstance.P1X - MyGlobalController3.SharedInstance.P3X)
			* (MyGlobalController.SharedInstance.P1X - MyGlobalController3.SharedInstance.P3X)
			+
			(MyGlobalController.SharedInstance.P1Y - MyGlobalController3.SharedInstance.P3Y)
			* (MyGlobalController.SharedInstance.P1Y - MyGlobalController3.SharedInstance.P3Y)
		);

		if (distance > greatestDistance) {
			greatestDistance = distance;
			CenterP1 = 1;
			CenterP2 = 3;
		}

		distance = Mathf.Sqrt (
			(MyGlobalController.SharedInstance.P1X - MyGlobalController4.SharedInstance.P4X)
			* (MyGlobalController.SharedInstance.P1X - MyGlobalController4.SharedInstance.P4X)
			+
			(MyGlobalController.SharedInstance.P1Y - MyGlobalController4.SharedInstance.P4Y)
			* (MyGlobalController.SharedInstance.P1Y - MyGlobalController4.SharedInstance.P4Y)
		);

		if (distance > greatestDistance) {
			greatestDistance = distance;
			CenterP1 = 1;
			CenterP2 = 4;
		}

		distance = Mathf.Sqrt (
			(MyGlobalController2.SharedInstance.P2X - MyGlobalController3.SharedInstance.P3X)
			* (MyGlobalController2.SharedInstance.P2X - MyGlobalController3.SharedInstance.P3X)
			+
			(MyGlobalController2.SharedInstance.P2Y - MyGlobalController3.SharedInstance.P3Y)
			* (MyGlobalController2.SharedInstance.P2Y - MyGlobalController3.SharedInstance.P3Y)
		);

		if (distance > greatestDistance) {
			greatestDistance = distance;
			CenterP1 = 2;
			CenterP2 = 3;
		}

		distance = Mathf.Sqrt (
			(MyGlobalController2.SharedInstance.P2X - MyGlobalController4.SharedInstance.P4X)
			* (MyGlobalController2.SharedInstance.P2X - MyGlobalController4.SharedInstance.P4X)
			+
			(MyGlobalController2.SharedInstance.P2Y - MyGlobalController4.SharedInstance.P4Y)
			* (MyGlobalController2.SharedInstance.P2Y - MyGlobalController4.SharedInstance.P4Y)
		);

		if (distance > greatestDistance) {
			greatestDistance = distance;
			CenterP1 = 2;
			CenterP2 = 4;
		}

		distance = Mathf.Sqrt (
			(MyGlobalController3.SharedInstance.P3X - MyGlobalController4.SharedInstance.P4X)
			* (MyGlobalController3.SharedInstance.P3X - MyGlobalController4.SharedInstance.P4X)
			+
			(MyGlobalController3.SharedInstance.P3Y - MyGlobalController4.SharedInstance.P4Y)
			* (MyGlobalController3.SharedInstance.P3Y - MyGlobalController4.SharedInstance.P4Y)
		);

		if (distance > greatestDistance) {
			greatestDistance = distance;
			CenterP1 = 3;
			CenterP2 = 4;
		}


		if (CenterP1 == 1 && CenterP2 == 2){
			CenterP1 = (MyGlobalController.SharedInstance.P1X+MyGlobalController2.SharedInstance.P2X)/2.0f;
			CenterP2 = (MyGlobalController.SharedInstance.P1Y+MyGlobalController2.SharedInstance.P2Y)/2.0f;
		}

		if (CenterP1 == 1 && CenterP2 == 3){
			CenterP1 = (MyGlobalController.SharedInstance.P1X+MyGlobalController3.SharedInstance.P3X)/2.0f;
			CenterP2 = (MyGlobalController.SharedInstance.P1Y+MyGlobalController3.SharedInstance.P3Y)/2.0f;
		}

		if (CenterP1 == 1 && CenterP2 == 4){
			CenterP1 = (MyGlobalController.SharedInstance.P1X+MyGlobalController4.SharedInstance.P4X)/2.0f;
			CenterP2 = (MyGlobalController.SharedInstance.P1Y+MyGlobalController4.SharedInstance.P4Y)/2.0f;
		}

		if (CenterP1 == 2 && CenterP2 == 3){
			CenterP1 = (MyGlobalController2.SharedInstance.P2X+MyGlobalController3.SharedInstance.P3X)/2.0f;
			CenterP2 = (MyGlobalController2.SharedInstance.P2Y+MyGlobalController3.SharedInstance.P3Y)/2.0f;
		}

		if (CenterP1 == 2 && CenterP2 == 4){
			CenterP1 = (MyGlobalController2.SharedInstance.P2X+MyGlobalController4.SharedInstance.P4X)/2.0f;
			CenterP2 = (MyGlobalController2.SharedInstance.P2Y+MyGlobalController4.SharedInstance.P4Y)/2.0f;
		}

		if (CenterP1 == 3 && CenterP2 == 4){
			CenterP1 = (MyGlobalController3.SharedInstance.P3X+MyGlobalController4.SharedInstance.P4X)/2.0f;
			CenterP2 = (MyGlobalController3.SharedInstance.P3Y+MyGlobalController4.SharedInstance.P4Y)/2.0f;
		}




		
		distance = Mathf.Sqrt ( (transform.position.x - CenterP1) * (transform.position.x - CenterP1) + (transform.position.y - CenterP2) * (transform.position.y - CenterP2) )/20.0f;


		CenterP1 = CenterP1 - transform.position.x;
		CenterP2 = CenterP2 - transform.position.y;

		CenterP1 = Mathf.Atan2 (CenterP2, CenterP1);

		temp.x = temp.x + Mathf.Cos (CenterP1) * distance;
		temp.y = temp.y + Mathf.Sin (CenterP1) * distance;


	



*/


		/*
		 
		//temp.x = CenterP1;
		if (temp.x > CenterP1) {
			temp.x = temp.x - 0.1f;
		}
		if (temp.x < CenterP1) {
			temp.x = temp.x + 0.1f;
		}

		if (temp.y > CenterP2) {
			temp.y = temp.y - 0.1f;
		}
		if (temp.y < CenterP2) {
			temp.y = temp.y + 0.1f;
		}

		*/

		//temp.y = CenterP2;


		//Camera Zoom
		greatestDistance = -4 - Mathf.Sqrt((transform.position.x - MyGlobalController.SharedInstance.P1X)*(transform.position.x - MyGlobalController.SharedInstance.P1X) + (transform.position.y - MyGlobalController.SharedInstance.P1Y)*(transform.position.y - MyGlobalController.SharedInstance.P1Y) ) *1.75f;

		distance = -4 - Mathf.Sqrt((transform.position.x - MyGlobalController2.SharedInstance.P2X)*(transform.position.x - MyGlobalController2.SharedInstance.P2X) + (transform.position.y - MyGlobalController2.SharedInstance.P2Y)*(transform.position.y - MyGlobalController2.SharedInstance.P2Y) ) *1.75f;

		if (distance < greatestDistance) {
			greatestDistance = distance;
		}

		distance = -4 - Mathf.Sqrt((transform.position.x - MyGlobalController3.SharedInstance.P3X)*(transform.position.x - MyGlobalController3.SharedInstance.P3X) + (transform.position.y - MyGlobalController3.SharedInstance.P3Y)*(transform.position.y - MyGlobalController3.SharedInstance.P3Y) ) *1.75f;

		if (distance < greatestDistance) {
			greatestDistance = distance;
		}

		distance = -4 - Mathf.Sqrt((transform.position.x - MyGlobalController4.SharedInstance.P4X)*(transform.position.x - MyGlobalController4.SharedInstance.P4X) + (transform.position.y - MyGlobalController4.SharedInstance.P4Y)*(transform.position.y - MyGlobalController4.SharedInstance.P4Y) ) *1.75f;

		if (distance < greatestDistance) {
			greatestDistance = distance;
		}



		temp.z = (temp.z + greatestDistance) / 2.0f;

		//temp.z = -8 - distance*1.75f;

		//Average Cam Position
		temp.x = (MyGlobalController.SharedInstance.P1X + MyGlobalController2.SharedInstance.P2X + MyGlobalController3.SharedInstance.P3X + MyGlobalController4.SharedInstance.P4X) / 4.0f;
		temp.y = (MyGlobalController.SharedInstance.P1Y + MyGlobalController2.SharedInstance.P2Y + MyGlobalController3.SharedInstance.P3Y + MyGlobalController4.SharedInstance.P4Y) / 4.0f;

		transform.position = temp;
		//position.x = 0;
		//transform.position.y = 0;
	}
}
