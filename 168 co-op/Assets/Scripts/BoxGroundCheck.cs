using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGroundCheck : MonoBehaviour {

	private Rigidbody2D rb;
	public bool grounded;

	void Start () {
		rb = gameObject.GetComponentInParent<Rigidbody2D> ();
		grounded = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		grounded = true;
	}

	void OnTriggerExit2D(Collider2D col){
		grounded = false;
	}

	void OnTriggerStay2D(Collider2D col){
		grounded = true;
	}

	void Update(){
		if (grounded == true) {
			rb.isKinematic = true;
		}
		if (grounded == false) {
			rb.isKinematic = false;
		}
	}
}
