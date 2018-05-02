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
		if (player.grabbing == false) {
			if (col.gameObject.CompareTag ("box") || col.gameObject.CompareTag ("g_box") || col.gameObject.CompareTag ("stone_box")) {
				player.obj = col.gameObject;
			}

		}

	}

	void OnTriggerExit2D(Collider2D col){
		player.canGrab = false;
		player.obj = null;
	}

	void OnTriggerStay2D(Collider2D col){
		player.canGrab = true;
		if (col.gameObject.CompareTag ("box") || col.gameObject.CompareTag ("g_box") || col.gameObject.CompareTag ("stone_box")) {
			player.obj = col.gameObject;
		}
	}
}