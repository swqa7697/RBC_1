using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float jumpPower = 150f;
	public float maxSpeed = 10f;

	private SpriteRenderer PSR;
	public Sprite[] PS;

    public Sprite localRed1;
    public Sprite localRed2;


	//public GameObject GameOverUI;

	public bool grounded = false;
	public bool canGrab = false;
	public bool grabbing = false;

	private Rigidbody2D rb2d;
	public Rigidbody2D rb2db;
	public GameObject box;

	// Use this for initialization
	void Start () {
		//GameOverUI.SetActive(false);
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		PSR = gameObject.GetComponent<SpriteRenderer>();
     
	}

    public override void OnStartLocalPlayer()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        PSR = gameObject.GetComponent<SpriteRenderer>();

        Debug.Log("IS CALLED");
        Debug.Log(localRed1);
        PSR.sprite = localRed1;

    }

	void FixedUpdate () {

        if (!isLocalPlayer)
            return;

		float h = Input.GetAxis ("Horizontal");
		if (grabbing == true) {
			if (h > 0) {
				h = 0;
			}
		}
		rb2d.velocity = new Vector2 (h * maxSpeed, rb2d.velocity.y);

        if (grabbing == true)
        {
            PSR.color = Color.black;
        }
		if (grabbing == false)
		{
			PSR.color = Color.white;
		}

	}

	void Update () {

       if (!isLocalPlayer)
            return;

		if (Input.GetButtonDown ("Jump")) {
			if (grounded == true) {
				rb2d.AddForce (Vector2.up * jumpPower);
				grounded = false;
			}
		}

		if (Input.GetButtonDown ("Grab")) {
			if (canGrab == true) {
				grabbing = true;
				//box.GetComponent<Rigidbody2D>().isKinematic = true;
				box.transform.SetParent (gameObject.transform);
			}
		}
		if (Input.GetButtonUp ("Grab")) {
			grabbing = false;
			box.transform.SetParent (null);

		}
	}

	void OnCollisionEnter2D(Collision2D col){
		//box.GetComponent<Rigidbody2D>().isKinematic = false;
	}

}
