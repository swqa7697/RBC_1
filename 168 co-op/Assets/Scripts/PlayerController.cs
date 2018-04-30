using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float jumpPower = 150f;
	public float maxSpeed = 10f;

	private SpriteRenderer PSR;
	public Sprite[] PS;

	//public GameObject GameOverUI;

	public bool grounded = false;
	public bool canGrab = false;
	public bool grabbing = false;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		//GameOverUI.SetActive(false);
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		PSR = gameObject.GetComponent<SpriteRenderer>();
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2 (h * maxSpeed, rb2d.velocity.y);

		if (grabbing == true) {
			PSR.sprite = PS [1];
		} else {
			PSR.sprite = PS [0];
		}


	}

	void Update () {

		if (Input.GetButtonDown ("Jump")) {
			if (grounded == true) {
				rb2d.AddForce (Vector2.up * jumpPower);
				grounded = false;
			}
		}
		//this is for grabbing        ############################################################
		//if (Input.GetButtonDown ("Grab")) {
		//	if (canGrab == true) {
		//		grabbing = true;
		//		
		//	}
		//}
		//if (Input.GetButtonUp ("Grab")) {
		//	grabbing = false;
		//}
	}

}
