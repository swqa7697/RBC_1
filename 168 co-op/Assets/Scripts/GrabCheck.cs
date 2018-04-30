using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = gameObject.GetComponentInParent<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		player.canGrab = true;
	}

	void OnTriggerExit2D(Collider2D col){
		player.canGrab = false;
	}


	void OnTriggerStay2D(Collider2D col){
		player.canGrab = true;
	}
}